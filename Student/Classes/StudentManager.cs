using StudentEF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEF.Classes
{
    class StudentManager : IStudentManager
    {
        private StudentContext _dbContext;
        public StudentManager(StudentContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void AddStudent(IStudent student)
        {
            var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                //check 
                var existingStudent = _dbContext.Students.SingleOrDefault(s => s.StudentId == student.StudentId);
                if (existingStudent != null)
                {
                    throw new Exception("Existing Student !!");

                }

                _dbContext.Students.Add(student as Student);//ep kieu
                _dbContext.SaveChanges();
                transaction.Commit();


            }
            catch (Exception)
            {
                transaction.Rollback();

            }
        }

        public void AddSubject(ISubject subject)
        {
            var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                //check
                var existingSubject = _dbContext.Subjects.SingleOrDefault(p => p.SubjectId == subject.SubjectId);
                if (existingSubject != null)
                {
                    throw new Exception("Existing Subject !!");
                }

                _dbContext.Subjects.Add(subject as Subject);//ep kieu
                _dbContext.SaveChanges();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }

        }

        public IStudent Find(int id)
        {
            var existingStudent = _dbContext.Students.SingleOrDefault(b => b.StudentId == id);
            if (existingStudent == null)
            {
                Console.WriteLine($"NotExisting Student: {id}!!");
            }

            return existingStudent;

        }

        public IStudentClass FindCourse(int id)
        {
            var existingStudentCourse = _dbContext.StudentClasses.SingleOrDefault(b => b.StudentId == id);
            if (existingStudentCourse == null)
            {
                Console.WriteLine($"NotExisting Student: {id}!!");
            }

            return existingStudentCourse;

        }

        public IStudent FindName(string name)
        {
            var existingStudentName = _dbContext.Students.SingleOrDefault(b => b.StudentName == name);
            if (existingStudentName == null)
            {
                Console.WriteLine($"NotExisting StudentName: {name}!!");
            }

            return existingStudentName;

        } 

        public ISubject FindSubject(int id)
        {
            var existingSubject = _dbContext.Subjects.SingleOrDefault(b => b.SubjectId == id);
            if (existingSubject == null)
            {
                Console.WriteLine($"NotExisting Subject: {id}!!");
            }

            return existingSubject;

        }

        public void RegisterCourse(IStudentClass studentClass)
        {
            var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                //check 
                var existingRegStu = _dbContext.StudentClasses.SingleOrDefault(s => s.StudentId == studentClass.StudentId);
                var exostomgRegSub = _dbContext.StudentClasses.SingleOrDefault(s => s.SubjectId == studentClass.SubjectId);
                if (existingRegStu != null && exostomgRegSub != null)
                {
                    throw new Exception("Existing Register !!");

                }

                _dbContext.StudentClasses.Add(studentClass as StudentClass);//ep kieu
                _dbContext.SaveChanges();
                transaction.Commit();

            }
            catch (Exception)
            {
                transaction.Rollback();

            }

           
        }

        public IStudentClass RemoveCourse(int id, bool isdeleted)
        {
            //check
            var existingRegDel = _dbContext.StudentClasses.SingleOrDefault(p => p.StudentId == id);
            if (existingRegDel == null)
            {
                throw new Exception($"NotExisting Course to soft deleted!!");
            }

            existingRegDel.isDeleted = isdeleted;
            _dbContext.StudentClasses.Update(existingRegDel);
            _dbContext.SaveChanges();
            return existingRegDel;
            
        }

        public IStudent RemoveStudent(int id, bool isdeleted)
        {
            //check
            var existingStudentDel = _dbContext.Students.SingleOrDefault(p => p.StudentId == id);
            if (existingStudentDel == null)
            {
                throw new Exception($"NotExisting Student to soft deleted!!");
            }

            existingStudentDel.isDeleted = isdeleted;
            _dbContext.Students.Update(existingStudentDel);
            _dbContext.SaveChanges();
            return existingStudentDel;
            
        }

        public ISubject RemoveSubject(int id, bool isdeleted)
        {
            //check
            var existingSubjectDel = _dbContext.Subjects.SingleOrDefault(p => p.SubjectId == id);
            if (existingSubjectDel == null)
            {
                throw new Exception($"NotExisting Subject to soft deleted!!");
            }

            existingSubjectDel.isDeleted = isdeleted;
            _dbContext.Subjects.Update(existingSubjectDel);
            _dbContext.SaveChanges();
            return existingSubjectDel;
            
        }

        public void UpdateStudent(int id, IStudent student, string name, DateTime? datetime)
        {
            var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                //check 
                var existingStudent = _dbContext.Students.SingleOrDefault(b => b.StudentId == id);
                if (existingStudent == null)
                {
                    throw new Exception("NotExisting Student !!");

                }

                _dbContext.Students.Update(student as Student);
                _dbContext.SaveChanges();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
            
        }

        public void UpdateSubject(int id, ISubject subject, string name, string teacher)
        {
            var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                //check 
                var existingSubject = _dbContext.Subjects.SingleOrDefault(b => b.SubjectId == id);
                if (existingSubject == null)
                {
                    throw new Exception("NotExisting Subject !!");

                }

                _dbContext.Subjects.Update(subject as Subject);
                _dbContext.SaveChanges();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        
        }
    }
}
