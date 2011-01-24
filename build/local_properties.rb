class LocalSettings 
 def create_settings_dictionary()
  settings = {
  	:app_config_template => "app.config.template" ,
  	:path_to_runtime_log4net_config => File.join(%w[artifacts log4net.config.xml]),
  	:asp_net_worker_process => "aspnet_wp.exe",
  	:log_file_name => "prep_log.txt",
  	:log_level => "DEBUG",
  	:xunit_report_file_dir => "artifacts" ,
  	:xunit_report_file_name => "test_report",
  	:xunit_report_type => "text",
  	:xunit_show_test_report => true,
  	:debug => "TRUE",
  }
 end
end
