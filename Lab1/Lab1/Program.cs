using System;
using System.Collections.Generic;
using System.Linq;
using CommandLine;
using NLog;
using Lab1.Models;
using Lab1.Services.Exceptions;
using Lab1.Services.Interfaces;
using Lab1.Services.IOSystem.Readers;
using Lab1.Services.IOSystem.Writers;
using Lab1.Services.Validation;

namespace Lab1
{
    class Program
    {
        public static IReader<Student> Reader { get; set; } = new CsvReader();
        public static ILogger Logger { get; set; } = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            var config = new NLog.Config.LoggingConfiguration();
            var logfile = new NLog.Targets.FileTarget("logfile") { FileName = "file.txt" };
            var logconsole = new NLog.Targets.ConsoleTarget("logconsole");
            config.AddRule(LogLevel.Trace, LogLevel.Fatal, logconsole);
            config.AddRule(LogLevel.Trace, LogLevel.Fatal, logfile);
            NLog.LogManager.Configuration = config;
            Options options = new Options();
            Parser.Default.ParseArguments<Options>(args).WithParsed((Options parsedOptions) => { options = parsedOptions; });
            try
            {
                ValidationProgramArguments.Validation(options);
                if (options.OutputFileFormat.Equals(""))
                {
                    options.OutputFileFormat = "Excel";
                }
                if (!options.OutputFile.EndsWith(".xlsx") && options.OutputFileFormat.Equals("Excel"))
                {
                    options.OutputFile += ".xlsx";
                }
                else if (!options.OutputFile.EndsWith(options.OutputFileFormat.ToLower()))
                {
                    options.OutputFile += "." + options.OutputFileFormat.ToLower();
                }                
                List<string> strList = new List<string>();
                List<Student> file = Reader.Read(options.InputFile, out strList).ToList();
                if (file != null && file.Count != 0)
                {
                    if (options.OutputFileFormat.Equals("JSON"))
                    {
                        JsonWriter writer = new JsonWriter();
                        writer.Write(file, strList, options.OutputFile);
                    }
                    else if (options.OutputFileFormat.Equals("Excel"))
                    {
                        ExcelWriter writer = new ExcelWriter();
                        writer.Write(file, strList, options.OutputFile);
                    }
                    else
                    {
                        throw new IOSystemException("Wrong output format");
                    }
                }
                else if (file == null)
                {
                    throw new IOSystemException("File not found");                    
                }
                else
                {
                    throw new IOSystemException("File don't have any correct line.");
                }
            }
            catch (IOSystemException ex)
            {
                Logger.Error(ex, "Input/Output System exception: " + ex.Message);
            }
            catch (FieldNameException ex)
            {
                Logger.Error(ex, "Field Name Exception: " + ex.Message);
            }
            catch (FIOFieldException ex)
            {
                Logger.Error(ex, "FIO Exception: " + ex.Message);
            }
            catch (MarkFieldException ex)
            {
                Logger.Error(ex, "Mark Exception: " + ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Error(ex, "Unexeptable Exception:" + ex.Message);
                throw;
            }
        }
    }
}
