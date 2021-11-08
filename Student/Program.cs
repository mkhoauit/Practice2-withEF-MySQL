using StudentEF.Classes;
using System;
using System.Linq;
using StudentEF.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace StudentEF
{
    class Program
    {
        private static void Main()
        {
            using (var context = new StudentContext())
            {
                //Data Seeding
                context.Database.EnsureCreated();

                //table Student
                //Nguyen Van A
                var testStudent = context.Students.FirstOrDefault(b => b.StudentId == 1);
                if (testStudent != null)
                {
                    Console.WriteLine("Existing Student !!");
                }
                else
                {
                    testStudent = new Student
                    {
                        StudentId = 1,
                        Sex = "Male",
                        StudentName = "Nguyen van A",
                        BirthDate = Convert.ToDateTime("1999-02-13"),

                    };

                    context.Students.Add(testStudent);
                }
                //nguyen Thi B
                var testStudent2 = context.Students.FirstOrDefault(b => b.StudentId == 2);
                if (testStudent2 != null)
                {
                    Console.WriteLine("Existing Student !!");
                }
                else
                {
                    testStudent2 = new Student
                    {
                        StudentId = 2,
                        Sex = "Female",
                        StudentName = "Nguyen Thi B",
                        BirthDate = Convert.ToDateTime("1990-12-13"),

                    };

                    context.Students.Add(testStudent2);
                }
                //Le Thi C
                var testStudent3 = context.Students.FirstOrDefault(b => b.StudentId == 3);
                if (testStudent3 != null)
                {
                    Console.WriteLine("Existing Student !!");
                }
                else
                {
                    testStudent3 = new Student
                    {
                        StudentId = 3,
                        Sex = "Female",
                        StudentName = "Le Thi C",
                        BirthDate = Convert.ToDateTime("1998-07-29"),


                    };

                    context.Students.Add(testStudent3);
                }

                //table Subject
                //math
                var testSubject = context.Subjects.FirstOrDefault(b => b.SubjectId == 1);
                if (testSubject != null)
                {
                    Console.WriteLine("Existing Subject !!");
                }
                else
                {
                    testSubject = new Subject
                    {
                        SubjectId = 1,
                        SubjectName = "Math",
                        Teacher = "Mr.Joe",
                        StudentClasses = new List<StudentClass>

                    {
                      new StudentClass { StudentId=1,SubjectId=1,DateTimeStart= DateTime.Parse("2021-01-01"),DateTimeEnd=DateTime.Parse("2021-07-13")},
                      new StudentClass { StudentId=2,SubjectId=1,DateTimeStart= DateTime.Parse("2021-01-01"),DateTimeEnd=DateTime.Parse("2021-07-13")}

                    }
                    };

                    context.Subjects.Add(testSubject);
                }

                //history
                var testSubject2 = context.Subjects.FirstOrDefault(b => b.SubjectId == 2);
                if (testSubject2 != null)
                {
                    Console.WriteLine("Existing Subject !!");
                }
                else
                {
                    testSubject2 = new Subject
                    {
                        SubjectId = 2,
                        SubjectName = "History",
                        Teacher = "Ms.Mai",
                        StudentClasses = new List<StudentClass>

                    {
                      new StudentClass { StudentId=1,SubjectId=2,DateTimeStart= DateTime.Parse("2021-01-02"),DateTimeEnd=DateTime.Parse("2021-07-14")},
                      new StudentClass { StudentId=2,SubjectId=2,DateTimeStart= DateTime.Parse("2021-01-02"),DateTimeEnd=DateTime.Parse("2021-07-14")},
                       new StudentClass { StudentId=3,SubjectId=2,DateTimeStart= DateTime.Parse("2021-01-02"),DateTimeEnd=DateTime.Parse("2021-07-14")}
                    }
                    };

                    context.Subjects.Add(testSubject2);
                }

                context.SaveChanges();

            }

            using (var db = new StudentContext())
            {
                //main

                var StudentManager = new StudentManager(db);
                uint n;
                Console.WriteLine("Select a number: ");
                Console.WriteLine("1:Add a Student");
                Console.WriteLine("2:Remove a Student");
                Console.WriteLine("3:Find a Student");
                Console.WriteLine("4:Update a Student");
                Console.WriteLine("5:Add a Subject");
                Console.WriteLine("6:Remove a Subject");
                Console.WriteLine("7:Find a Subject");
                Console.WriteLine("8:Update a Subject");
                Console.WriteLine("9:Register a course");
                n = Convert.ToUInt32(Console.ReadLine());

                switch (n)
                {
                    case 1://add a Student
                        Console.WriteLine("Input new StudentId to add:");
                        int idStu = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Input new name Student to add:");
                        string nameStu = Convert.ToString(Console.ReadLine());

                        Console.WriteLine("Input sex of Student to add in [male/female]");
                        string sexStu = Console.ReadLine().sexStudent();

                        Console.WriteLine("Please enter your Student date of birth in DD/MM/YYYY:");
                        DateTime? dateStu = Console.ReadLine().Dob();

                        StudentManager.AddStudent(new Student() { StudentId = idStu, StudentName = nameStu, Sex = sexStu, BirthDate = dateStu });
                        break;

                    case 2://remove a Student
                        Console.WriteLine("Input id Student to remove:");
                        int idStud = Convert.ToInt32(Console.ReadLine());
                        //check student isdeleted 
                        var checkIsdeleted = StudentManager.Find(id: idStud);
                        var checkIsdeleted2 = StudentManager.RemoveStudent(id: idStud, isdeleted: false);
                        if (checkIsdeleted.isDeleted == true||checkIsdeleted2.isDeleted==true) 
                        {
                            Console.WriteLine($"{idStud} Student is deleted!");
                        }

                        checkIsdeleted.isDeleted = true;
                        checkIsdeleted2.isDeleted = true;
                        StudentManager.RemoveStudent(id: idStud, isdeleted: true);
                        break;

                    case 3://find a Student
                        Console.WriteLine("Input id Student to find:");
                        int idSt = Convert.ToInt32(Console.ReadLine());
                        var findSt = StudentManager.Find(id: idSt);
                        //check
                        if (findSt.isDeleted==true) 
                        {
                            Console.WriteLine("Student has been soft deleted");
                        }

                        Console.WriteLine("Here is Student you find:");
                        Console.WriteLine($" Student id: {findSt.StudentId}, Name: {findSt.StudentName}, Sex: {findSt.Sex}, Birthdate: {findSt.BirthDate} ");
                        break;

                    case 4://update student

                        Console.WriteLine("Input id Student:");
                        int x = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Input new name of Student:");
                        string x1 = Convert.ToString(Console.ReadLine());

                        Console.WriteLine("Input sex of Student in [male/female]:");
                        string x3 = Console.ReadLine().sexStudent();

                        Console.WriteLine("Please enter your Student date of birth in DD/MM/YYYY:");
                        DateTime? dateStud = Console.ReadLine().Dob();

                        var x2 = StudentManager.Find(id: x);

                        //update for object
                        x2.StudentId = x;
                        x2.StudentName = x1;
                        x2.Sex = x3;
                        x2.BirthDate = dateStud;

                        //update database
                        StudentManager.UpdateStudent(id: x2.StudentId, student:x2, name:x2.StudentName,datetime:x2.BirthDate);
                        break;

                    case 5://add a subject (id name teacher)
                        Console.WriteLine("Input new id Subject:");
                        int idSub = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Input name Subject:");
                        string nameSub = Convert.ToString(Console.ReadLine());

                        Console.WriteLine($"Input teacher of the {nameSub} Subject:");
                        string nameTeacher = Convert.ToString(Console.ReadLine());

                        StudentManager.AddSubject(new Subject() { SubjectId = idSub, SubjectName = nameSub, Teacher = nameTeacher });
                        break;

                    case 6://remove a subject
                        Console.WriteLine("Input id Subject to remove:");
                        int w = Convert.ToInt32(Console.ReadLine());
                        //check subject isdeleted 
                        var checkIsdeletedSub = StudentManager.FindSubject(id: w);
                        var checkIsdeletedSub2 = StudentManager.RemoveSubject(id: w, isdeleted: false);
                        if (checkIsdeletedSub.isDeleted == true || checkIsdeletedSub2.isDeleted == true)
                        {
                            Console.WriteLine($"{w} Subject is deleted!");
                        }

                        checkIsdeletedSub.isDeleted = true;
                        checkIsdeletedSub2.isDeleted = true;
                        StudentManager.RemoveSubject(id: w, isdeleted: true);
                        break;

                    case 7://find subject
                        Console.WriteLine("Input id Subject to find:");
                        int idSubject = Convert.ToInt32(Console.ReadLine());
                        var findSubject = StudentManager.FindSubject(id: idSubject);
                        //check
                        if (findSubject.isDeleted == true)
                        {
                            Console.WriteLine("Subject has been soft deleted");
                        }

                        Console.WriteLine("Here is Subject you find:");
                        Console.WriteLine($" Subject id: {findSubject.SubjectId}, Name: {findSubject.SubjectName}, Teacher: {findSubject.Teacher}.");
                        break;
                        
                    case 8://update subject
                        Console.WriteLine("Input id Subject:");
                        int sub = Convert.ToInt32(Console.ReadLine());

                        Console.WriteLine("Input new name of Subject:");
                        string nameSubject = Convert.ToString(Console.ReadLine());

                        Console.WriteLine("Input new name Teacher Subject:");
                        string nameT = Convert.ToString(Console.ReadLine());

                        var findSub = StudentManager.FindSubject(id: sub);

                        //update for object
                        findSub.SubjectId = sub;
                        findSub.SubjectName = nameSubject;
                        findSub.Teacher = nameT;

                        //update database
                        StudentManager.UpdateSubject(id: findSub.SubjectId,subject:findSub ,name: findSub.SubjectName, teacher: findSub.Teacher);
                        break;

                    case 9://Register a course
                        Console.WriteLine("Input id Student to register a course:");
                        int sd = Convert.ToInt32(Console.ReadLine());
                        //check id student
                        StudentManager.Find(id: sd);

                        Console.WriteLine("Input id Subject for a course");
                        int sd2 = Convert.ToInt32(Console.ReadLine());
                        //check id subject
                        StudentManager.FindSubject(id: sd2);

                        Console.WriteLine("Please enter your DateStart of course in DD/MM/YYYY:");
                        DateTime? dateCourseStart = Console.ReadLine().Dob();

                        Console.WriteLine("Please enter your DateEnd of course in DD/MM/YYYY:");
                        DateTime? dateCourseEnd = Console.ReadLine().Dob();
                        
                        if (dateCourseEnd < dateCourseStart) 
                        {
                            Console.WriteLine("ERROR!!");
                        }

                        StudentManager.RegisterCourse(new StudentClass() { StudentId = sd, SubjectId = sd2, DateTimeStart = dateCourseStart, DateTimeEnd = dateCourseEnd });
                        break;

                }
                Console.WriteLine("Done");
                Console.WriteLine("Thank you for using ^^");
            
            }
        }

    }
    public static class Extensions
    {
        public static DateTime? Dob(this string strLine)
        {
            DateTime result;
            if (DateTime.TryParseExact(strLine, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AdjustToUniversal, out result))
            {
                return result;
            }
            else
            {
                return null;
            }
        }
        public static string sexStudent(this string strSex)
        {

            if (strSex == "male"|| strSex == "female")
            {
                return strSex;
            }
            else
            {
               
                return null;
            }

        }
    }

}
