﻿using CommandLine;

namespace Lab1.Models
{
    public class Options
    {
        [Option('i', "inputFile", Required = true, HelpText = "Path to input file. Not require format in name.")]
        public string InputFile { get; set; }
        [Option('o', "outputFile", Required = true, HelpText = "Path to output file. Not require format in name.")]
        public string OutputFile { get; set; }
        [Option('f', "outputFileFormat", Required = false, HelpText = "Format of output file. Default JSON.")]
        public string OutputFileFormat { get; set; } = "Excel";
    }
}
