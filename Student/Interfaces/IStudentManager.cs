using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEF.Interfaces
{
    interface IStudentManager
    {
        void AddStudent(IStudent student);
        IStudent RemoveStudent(int id,bool isdeleted);
        void UpdateStudent(int id, IStudent student, string name, DateTime? datetime );
        IStudent Find(int id);
        IStudent FindName(string name);
        void AddSubject(ISubject subject);
        ISubject RemoveSubject(int id,bool isdeleted);
        void UpdateSubject(int id, ISubject subject, string name, string teacher );
        ISubject FindSubject(int id);
        void RegisterCourse(IStudentClass studentClass );
        IStudentClass RemoveCourse(int id, bool isdeleted);
        IStudentClass FindCourse(int id);

    }
}
