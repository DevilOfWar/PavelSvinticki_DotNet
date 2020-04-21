# Lab1

There is first lab of subject.

Task: Make console programm, what can read .csv files with students data, processing this data and output in one of two format: JSON or Excel. Processing include calculating average marks of every student and by every subject.

Used NuGet packages: CommandLineParser, EPPlus, NLog.

Created classes and interfaces: CsvReader, ExcelWriter, FieldNameException, FIOFieldException, IWriter, IOSystemException, IReader, JsonWriter, MarkFieldExcepiton, Options, Subjects, Student, StudentInfo, StudentsCsvParser, ValidationFieldName, ValidationOfFieldValue, ValidationOfPath, ValidationProgramArgument, ValidationOfModels.

Classes and interfaces discription:

IWriter - interface with method Write than take as arguments collection to output (collection), collection of headers (fieldNames) and path to file (path).
ExcelWriter - class, what realize interface IWriter. Method Write write student FIO, his marks, his average marks, average marks of subjects in .xlsx file. Used EPPlus.
JsonWriter - class, what realize interface IWriter. Method Write serialize only average marks of every student and subject.
IReader - interface with method Read. This method take path to input file (path), list of string to out (fieldNames). It return collection of student (as return value of method) and fieldNames (as out param of method).
CsvReader - class, what relize interface IReader. Realize method Read for collection of Students. Use this class to read information about students from .csv file.
StudentsCsvParser - static class, than convert string to object of class Student. Method ParseStudent take string pattern, parse by ";" or ",", create new object of class Student and use this object as return value. Used in CsvReader.
FieldNameException, FIOFieldException, IOSystemException and MarkFieldException - exception classes, created to easier identification of error.
ValidationFieldName, ValidationOfFieldValue, ValidationProgramArguments and ValidatorOfModels - validation classes, that validate some items. For example, ValidationProgramArguments validate programm arguments, ValidationOfFieldValue - value of field.
Options - model class, that contains programm arguments, like path to input file (property inputFile), path to output file(property outputFile) and output format (property outputFileFormar).
Student - model class, that contains student FIO (properties Name, Surname and MiddleName), marks (property Marks) and average mark (property AverageMark).
StudentInfo - object-to-data class, that contains student FIO (like Student class) and average mark (property AverageGrade).
Subjects - model class, than contains average marks of every subject and average mark of all subjects.

How to work:
Before start, change startup setting of Lab1.exe file. Use -i "path" to set input file path, -o "path" - output file path, and -f "format" - output file type. -i and -o param must be used. If -f not used, programm will use Excel output format. If you want get Json output format, use -f JSON. After change startup settings, start .exe file. In console you can see logs. If you don't have time to read logs now, you can find it in file.txt in programm directory.
