using System;
using System.Linq;
using LinqDataBaseEFDal.DbOperations;
using LinqDataBaseEFDal.Entities;

namespace LinqDataBaseEFDal
{
    class Program
    {
        static void Main(string[] args)
        {
            DataGenerator.Initialize();
            LinqDbContext _context = new LinqDbContext();
            var students = _context.Students.ToList<Student>();

            Console.WriteLine("******find*******");
            var student = _context.Students.Where(student1 => student1.StudentId == 1).FirstOrDefault();
            student = _context.Students.Find(2);
            Console.WriteLine(student.Surname);


            Console.WriteLine("******FirstOrDefault*******"); 
            student = _context.Students.Where(student1 => student1.Surname == "Boran").FirstOrDefault();
            Console.WriteLine(student.Surname);
            student = _context.Students.FirstOrDefault(s => s.Surname == "Boran");
            Console.WriteLine(student.Surname);

            Console.WriteLine("******SingleOrDefault*******");
            student = _context.Students.SingleOrDefault(s => s.Name == "Ali");
            Console.WriteLine(student.Name);

            Console.WriteLine("******Tolist*******");
            var studentList = _context.Students.Where(s => s.ClassId == 2).ToList();
            Console.WriteLine(studentList.Count);


            Console.WriteLine("******OrderBy*******");
            students = _context.Students.OrderBy(s => s.StudentId).ToList();
            foreach (var st in students)
            {
                Console.WriteLine(st.StudentId+"-"+st.Name+" "+st.Surname);
            }

            Console.WriteLine("******OrderByDescending*******");
            students = _context.Students.OrderByDescending(s => s.StudentId).ToList();
            foreach (var st in students)
            {
                Console.WriteLine(st.StudentId + "-" + st.Name + " " + st.Surname);
            }

            Console.WriteLine("******Anonymous Object Result*******");
            var anonymousObject = _context.Students
                .Where(x => x.ClassId == 2)
                .Select(x => new
                {
                    Id=x.StudentId,
                    FullName=x.Name+" "+x.Surname
                });
            foreach (var obj in anonymousObject)
            {
                Console.WriteLine(obj.Id + "-" + obj.FullName);
            }

        }
    }
}
