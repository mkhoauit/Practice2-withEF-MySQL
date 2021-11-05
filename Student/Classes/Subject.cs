using StudentEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEF.Classes
{
    public class Subject : ISubject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Teacher { get; set; }
        public bool isDeleted { get; set; }
        public List<StudentClass> StudentClasses { get; set; }
    }
}
