JF_CODE = {

	client_app_updatevcstart		= "01000001",			--开始获取版本控制文件
	client_app_updatevcretry		= "01005001",			--获取版本控制文件失败后自动重试
	client_app_updatevcsuccess		= "01000002",			--成功获取版本控制文件
	client_app_updateulstart		= "01010001",			--开始获取更新列表
	client_app_updateulretry		= "01015002",			--更新列表下载失败后自动重试
	client_app_updateulsuccess		= "01010002",			--更新列表下载成功
	client_app_updaterfstart		= "01020001",			--开始更新资源
	client_app_updaterfretry		= "01025001",			--资源更新失败后自动重试
	client_app_updaterfsuccess		= "01020002",			--资源更新完成(包括解压、替换文件全部完成，且本地版本号变更成功)
	client_app_updatevcfailed		= "01009901",			--获取版本控制文件最终失败
	client_app_updateulfailed 		= "01019901",			--更新列表下载失败最终失败
	client_app_updaterffailed 		= "01029901",			--资源更新最终失败

	client_app_outoffcus			= "02010001",			--游戏任何时刻因为各种原因切入后台时上报

	client_shop_click				= "03000001",			--玩家查看某个商品时上报
	client_ads_click 				= "03010001",			--玩家点击广告时上报
	client_ads_load 				= "03010002", 			--玩家广告加载完毕时上报

	client_setting_change			= "04000001",			--玩家改变某个设置时上报
	client_customui_change			= "05000001",			--玩家改变某个按钮布局，且保存时上报
	client_app_err					= "04900001",			--客户端错误信息
	client_sociality_active 		= "06010001", 			--进入活动页面
	client_sociality_share			= "06010002", 			--点击分享

}

JF_TYPE = {
	Update = 1 , 		--更新相关
	Action = 2, 		--用户行为
	ShopView = 3, 		--商店查看
	Error = 4, 			--报错日志
	Ad =5 , 			--广告
	Social=6, 			--社交
}

------------------Store-----------------------------
JF_STORE_TYPE = 0		--当前查看商店页签
JF_STORE_VIEW_SALEID = 0--当前查看的商品ID
JF_STORE_STAYTIME = 0   --当前查看的商品停留时间

