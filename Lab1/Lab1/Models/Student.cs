﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Lab1.Models
{
    [DataContract]
    public class Student
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string MiddleName { get; set; }

        [DataMember]
        public List<double> Marks { get; set; }

        [IgnoreDataMember]
        public double AverageMark => Marks.Average();

    }
}
