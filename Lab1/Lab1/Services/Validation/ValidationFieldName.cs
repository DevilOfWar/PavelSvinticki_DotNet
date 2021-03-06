﻿using System.Collections.Generic;
using System.Linq;
using Lab1.Services.Exceptions;
using Lab1.Services.Parsers;

namespace Lab1.Services.Validation
{
    public class ValidationFieldName
    {
        public static void Validate(string fieldNames)
        {
            List<string> list = StudentsCsvParser.ParsePattern(fieldNames).ToList();
            if (list.Count() < 3)
            {
                throw new FieldNameException(" not enouch columns");
            }
            if ((!list[0].Equals("Фамилия") || !list[1].Equals("Имя") || !list[2].Equals("Отчество")) && (!list[0].Equals("Surname") || !list[1].Equals("Name") || !list[2].Equals("Middle Name")))
            {
                throw new FieldNameException(" Wrong name of first 3 columns");
            }
        }
    }
}
