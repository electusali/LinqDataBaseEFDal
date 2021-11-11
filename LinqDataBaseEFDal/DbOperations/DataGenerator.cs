using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinqDataBaseEFDal.Entities;

namespace LinqDataBaseEFDal.DbOperations
{
    public  class DataGenerator
    {
        public static void Initialize()
        {
            using (var context=new LinqDbContext())
            {
                if (context.Students.Any())
                {
                    return;
                }
                context.Students.AddRange(
                    new Student()
                    {
                        Name="Ali",
                        Surname="Boran",
                        ClassId=1
                    },
                new Student()
                    {
                        Name = "Ali2",
                        Surname = "Boran",
                        ClassId = 1
                    },
                new Student()
                    {
                        Name = "Ali3",
                        Surname = "Boran3",
                        ClassId = 2
                    },
                new Student()
                    {
                        Name = "Ali4",
                        Surname = "Boran4",
                        ClassId = 2
                    }

                    );
                context.SaveChanges();
            }
            
        }
    }
}
