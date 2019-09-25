using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Grade
    {
        public Grade()
        {
            Classes = new List<Classes>();
            Courses = new List<Course>();
        }

        public long Id { get; set; }

        /// <summary>
        /// 一年级/ 二年级 ...
        /// </summary>
        public string Name { get; set; }

        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 年级所有班级
        /// </summary>
        public ICollection<Course> Courses { get; set; }

        /// <summary>
        /// 年级所有教材
        /// </summary>
        public ICollection<Classes> Classes { get; set; }
    }
}
