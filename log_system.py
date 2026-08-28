import logging
import threading
import colorama
from colorama import Fore, Style
import sys
import os

colorama.init()

log_context = threading.local()

class ContextFilter(logging.Filter):
    def filter(self, record):
        record.player_id = getattr(log_context, 'player_id', None)
        record.match_id = getattr(log_context, 'match_id', None)
        return True

class ColoredContextFormatter(logging.Formatter):
    def format(self, record):
        prefix = ""
        if getattr(record, 'match_id', None):
            prefix += f"[Match: {record.match_id}] "
        if getattr(record, 'player_id', None):
            prefix += f"[Player: {record.player_id}] "
            
        original_msg = str(record.msg)
        try:
            enc = getattr(sys.stdout, "encoding", None) or "utf-8"
            safe_msg = original_msg.encode(enc, errors="backslashreplace").decode(enc, errors="replace")
        except Exception:
            safe_msg = original_msg.encode("ascii", errors="backslashreplace").decode("ascii", errors="replace")
        record.msg = f"{prefix}{safe_msg}"
        
        # Colorize based on level
        color = ""
        if record.levelno >= logging.ERROR:
            color = Fore.RED
        elif record.levelno >= logging.WARNING:
            color = Fore.YELLOW
        elif record.levelno >= logging.INFO:
            if "[MATCH" in original_msg or getattr(record, 'match_id', None):
                color = Fore.CYAN
            elif "BATTLE" in original_msg:
                color = Fore.MAGENTA
            else:
                color = Fore.GREEN
                
        formatted = super().format(record)
        record.msg = original_msg # restore
        
        if color:
            return f"{color}{formatted}{Style.RESET_ALL}"
        return formatted

class PlainContextFormatter(logging.Formatter):
    def format(self, record):
        prefix = ""
        if getattr(record, 'match_id', None):
            prefix += f"[Match: {record.match_id}] "
        if getattr(record, 'player_id', None):
            prefix += f"[Player: {record.player_id}] "
            
        original_msg = str(record.msg)
        record.msg = f"{prefix}{original_msg}"
        formatted = super().format(record)
        record.msg = original_msg
        return formatted

def setup_logger(logger_name, log_file_path=None):
    logger = logging.getLogger(logger_name)
    logger.setLevel(logging.INFO)
    logger.addFilter(ContextFilter())
    
    for handler in logger.handlers[:]:
        logger.removeHandler(handler)
        
    console_handler = logging.StreamHandler(sys.stdout)
    console_formatter = ColoredContextFormatter('%(asctime)s %(levelname)s: %(message)s')
    console_handler.setFormatter(console_formatter)
    logger.addHandler(console_handler)
    
    if log_file_path:
        import logging.handlers as handlers
        file_handler = handlers.RotatingFileHandler(
            log_file_path, maxBytes=10*1024*1024, backupCount=5, encoding="utf-8"
        )
        file_formatter = PlainContextFormatter('%(asctime)s %(levelname)s: %(message)s')
        file_handler.setFormatter(file_formatter)
        logger.addHandler(file_handler)
        
    return logger

def set_context(player_id=None, match_id=None):
    if player_id is not None:
        log_context.player_id = player_id
    if match_id is not None:
        log_context.match_id = match_id
        
def clear_context():
    if hasattr(log_context, 'player_id'):
        del log_context.player_id
    if hasattr(log_context, 'match_id'):
        del log_context.match_id

if __name__ == "__main__":
    logger = setup_logger("test_logger")
    logger.info("This is a normal message")
    
    set_context(player_id="100001")
    logger.info("Player logged in")
    
    set_context(match_id="ABCD")
    logger.info("Player fired weapon")
    
    logger.error("Something went wrong!")
    clear_context()
    
    logger.info("Context cleared")
