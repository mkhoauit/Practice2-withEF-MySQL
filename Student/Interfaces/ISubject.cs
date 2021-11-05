using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEF.Interfaces
{
    interface ISubject
    {
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public string Teacher { get; set; }
        public bool isDeleted { get; set; }
    }
}
