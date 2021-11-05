using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEF.Interfaces
{
    interface IStudentClass
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public DateTime? DateTimeStart { get; set; }
        public DateTime? DateTimeEnd { get; set; }
        public bool isDeleted { get; set; }
    }
}
