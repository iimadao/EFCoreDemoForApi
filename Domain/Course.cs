using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Course
    {
        public long Id { get; set; }
        /// <summary>
        /// 语文,数学 
        /// </summary>
        public string Name { get; set; }

        public  DateTime CreationTime { get; set; }

        public Grade Grade { get; set; }
    }
}
