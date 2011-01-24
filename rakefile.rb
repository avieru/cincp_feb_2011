require 'rake'
require 'rake/clean'
require 'fileutils'
require 'build/project.rb'

['build/tools/Rake','build'].each do|pattern|
  Dir.glob(File.join(File.dirname(__FILE__),pattern,"*.rb")).each do|item|
    puts item
    require item
  end
end

#load settings that differ by machine
database_details = DbDetails.new
local_settings = LocalSettings.new(database_details)

COMPILE_TARGET = 'debug'


template_files = TemplateFileList.new('**/*.template')
template_code_dir = File.join('product','templated_code')


#configuration files
config_files = FileList.new(File.join('product','config','*.template')).select{|fn| ! fn.include?('app.config')}

app_config = TemplateFile.new(File.join('product','config',local_settings[:app_config_template]))

#target folders that can be run from VS
solution_file = "solution.sln"

task :default => ["specs:run"]

task :init  => :clean do
  [Project.specs_dir,Project.report_folder].each{|folder| mkdir folder if ! File.exists?(folder)}
end

desc 'expands all of the template files in the project'
task :expand_all_template_files do
  template_files.generate_all_output_files(local_settings.settings)
end


desc 'compiles the project'
task :compile => :expand_all_template_files do
  MSBuildRunner.compile :compile_target => COMPILE_TARGET, :solution_file => solution_file
end

task :from_ide  do
  app_config.generate_to(File.join(Project.startup_dir,"#{Project.startup_config}"),local_settings.settings)
  Project.spec_assemblies.each do |assembly|
      app_config.generate_to(File.join('artifacts',"#{File.basename(assembly)}.config"),local_settings.settings)
  end

  config_files.each do |file|
    TemplateFile.new(file).generate_to_directories([Project.startup_dir,'artifacts'],local_settings.settings)
  end
end

namespace :specs do
  desc 'view the spec report'
  task :view do
    puts Project.report_folder
    system "start #{Project.report_folder}/#{Project.name}.specs.html"
  end

  desc 'run the specs for the project'
  task :run  => [:init,:compile] do
    Dir.glob(File.join('thirdparty','machine.specifications','*')).each do|file|
      FileUtils.cp(file,'artifacts')
    end
    Project.spec_assemblies.each do |assembly|
        app_config.generate_to(File.join('artifacts',"#{File.basename(assembly)}.config"),local_settings.settings)
    end
    sh "artifacts/mspec.exe", "--html", "#{Project.report_folder}/#{Project.name}.specs.html", "-x", "example", *([] + Project.spec_assemblies)
  end
end

desc "open the solution"
task :sln do
  path = "devenv #{solution_file}"
    Thread.new do
      system path
    end
end
