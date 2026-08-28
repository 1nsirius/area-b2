# Диагностика регресса после разбиения сервера на модули

## Ключевое отличие

Монолитная версия работала, потому что все runtime-state были в одном модуле и все функции читали/писали один и тот же объект:
- `_GP_TOKEN_TO_PLAYER_ID`
- `_HOLO_PLAYER_TOKENS`
- `_CHAT_BOOTSTRAP_STATE`
- `_ONLINE_STATE`
- `_CHAT_PLAYER_STATE`
- `_CHAT_PENDING_PUSHES`

После разбиения на `services/*` часть логики была вынесена в отдельные модули, но они создали собственные копии тех же словарей. В результате:
- `services.db` пишет в одно хранилище;
- `run_https_443.py` сообщает о другом хранилище;
- `services.holo` читает третье.

Из-за этого чат и поиск друзей теряют состояние между запросами и между TCP-потоками: один слой видит "пустой" словарь, другой уже записал данные.

## Утверждение, подтверждённое проверкой

До правки:
- `run_https_443._GP_TOKEN_TO_PLAYER_ID` и `services.db._GP_TOKEN_TO_PLAYER_ID` — разные идентификаторы объектов;
- `run_https_443._HOLO_PLAYER_TOKENS` и `services.holo._HOLO_PLAYER_TOKENS` — разные;
- `run_https_443._CHAT_BOOTSTRAP_STATE` и `services.holo.session_manager._CHAT_BOOTSTRAP_STATE` — разные.

Это и есть корень проблемы.

## Правка

Сделать `services.session_manager` каноническим хранилищем state, а `run_https_443.py` и `services/holo.py` подцепить к тем же объектам, а не создавать отдельные копии.

## Проверки после правки

Нужно убедиться, что:
- `id(run_https_443._GP_TOKEN_TO_PLAYER_ID) == id(services.db._GP_TOKEN_TO_PLAYER_ID)`
- `id(run_https_443._HOLO_PLAYER_TOKENS) == id(services.holo.session_manager._HOLO_PLAYER_TOKENS)`
- `holo.chat_bootstrap_mark(...)` отражается в `run_https_443._CHAT_BOOTSTRAP_STATE`

Это даст гарантию, что функциональность будет восстанавливаться без повторного переписывания протокола.
