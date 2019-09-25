using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Student
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Mail { get; set; }

        public uint Age { get; set; }

        public DateTime CreationTime { get; set; }

        public long ClassesId { get; set; }

        public Classes Classes { get; set; }
    }
}
