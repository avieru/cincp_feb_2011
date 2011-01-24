class DbDetails 
  attr_reader :initial_catalog,:database_provider,:web_user_account,:server_name, :sql_tools_path, :osql_exe , :osql_connection_string, :database_path, :osql_args_prior_to_file_name
, :config_connectionstring

  def initialize
      initialize_db_details
      initialize_db_storage_details
      initialize_user_accounts
      initilize_osql_settings
      initialize_dot_net_connection_strings

   end

   def initialize_dot_net_connection_strings
      @database_provider = "System.Data.SqlClient"
      @config_connectionstring = "data source=#{@server_name};Integrated Security=SSPI;Initial Catalog=#{@initial_catalog}"
   end

   def initialize_db_storage_details
  	  @database_path = "C:\\tempfiles\\databases"
   end

   def initialize_db_details
      @initial_catalog = Project.name
      @server_name = 'WIN-751NCQCD8RA\\\SQLExpress'
   end

   def initialize_user_accounts
      @web_user_account = "NT Authority\\Network Service"
      @web_account_sql = "#{@web_user_account}, N'#{@web_user_account}'"
   end

   def initilize_osql_settings
      @osql_exe = 'osql'
      @osql_connection_string = "-E \-S #{@server_name}"
      @osql_args_prior_to_file_name = '-b -i'
   end

   def populate(machine_specific_settings_hash)
      machine_specific_settings_hash[:database_path] = @database_path
      machine_specific_settings_hash[:initial_catalog] = @initial_catalog
      machine_specific_settings_hash[:web_user_account] = @web_user_account
      machine_specific_settings_hash[:database_provider] = @database_provider
      machine_specific_settings_hash[:config_connectionstring] = @config_connectionstring 
   end
end
