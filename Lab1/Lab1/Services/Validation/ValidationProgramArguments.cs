using System.IO;
using Lab1.Services.Exceptions;
using Lab1.Models;

namespace Lab1.Services.Validation
{
    public static class ValidationProgramArguments
    {
        public static void Validation(Options options)
        {
            if (options.InputFile == null || options.OutputFile == null)
            {
                throw new IOSystemException("Not all requered arguments are found");
            }
            if (!options.InputFile.EndsWith(".csv"))
            {
                throw new IOSystemException("Wrong format of input file");
            }
            else if (!options.OutputFileFormat.Equals("JSON") && !options.OutputFileFormat.Equals("Excel"))
            {
                throw new IOSystemException("Wrong format of output file");
            }
            else if (!File.Exists(options.InputFile))
            {
                throw new IOSystemException("Input file not exist");
            }
        }
    }
}
