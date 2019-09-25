using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Classes
    {
        public Classes()
        {
            Students = new List<Student>();
        }

        public long Id { get; set; }

        /// <summary>
        /// 一年 2班 / 3班 ...
        /// </summary>
        public string Name { get; set; }
         

        public DateTime CreationTime { get; set; }


        public ICollection<Student> Students { get; set; }

        public long GradeId { get; set; }
        public Grade Grade { get; set; }


    }

}
