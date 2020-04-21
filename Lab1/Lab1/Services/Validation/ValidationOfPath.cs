using Lab1.Services.Exceptions;
using System.IO;

namespace Lab1.Services.Validation
{
    public static class ValidationOfPath
    {
        public static void CsvPathValidation(this string path)
            => ValidatePath(path, ".csv");

        private static void ValidatePath(string path, string format)
        {
            if (!path.EndsWith(format))
                throw new IOSystemException("Incorrect path");
        }

        public static void CheckFileExistance(this string path)
        {
            if (!File.Exists(path))
                throw new IOSystemException("File not found");
        }

    }
}
