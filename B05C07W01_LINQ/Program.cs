using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B05C07W01_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new[]
            { 
                new { Id=1,Name="Rahman",Address="Gazipur"},
                new { Id=2,Name="Aman",Address="Mirpur"},
                new { Id=3,Name="Firoz",Address="Rajshahi"},
                new { Id=4,Name="Tasnim",Address="Dhanmondi"},
                new { Id=5,Name="Mehedi",Address="Mirpur"},

            };
            //Query
            var result= from student in students
                        select student;
            Console.Write($" Id \t Name \t Address \n");
            Console.WriteLine("=====================================");
            foreach (var item in result)
            {
                Console.Write($"{item.Id}\t{item.Name}\t{item.Address}\n");
            }

            //method
            Console.WriteLine("===============Method======================");
            students.ToList().ForEach(item => Console.Write($"{item.Id}\t{item.Name}\t{item.Address}\n"));
            Console.WriteLine("===============Order By======================");
            var query = students.ToList();
              query.OrderBy(x => x.Name).ToList().ForEach(item => Console.Write($"{item.Id}\t{item.Name}\t{item.Address}\n"));
            Console.WriteLine($"Total Student :{query.Count}");
            var StudentMarks = new[] {
                new { StudentID=1,Subject="Bangla",Marks=50}, 
                new { StudentID=2,Subject="Math",Marks=40},
                 new { StudentID=1,Subject="English",Marks=30},
                  new { StudentID=2,Subject="Bangla",Marks=50},
                new { StudentID=2,Subject="English",Marks=50}

            };
           var totalMarks= StudentMarks.Where(s=>s.StudentID.Equals(1)).Sum(s=>s.Marks);
            Console.WriteLine( $"Total Marks of Student 1:{ totalMarks}");
            var AvgMarks = StudentMarks.Where(s => s.StudentID.Equals(1)).Average(s => s.Marks);
            Console.WriteLine($"Total Marks of Student 1:{AvgMarks}");
            var MaxMarks = StudentMarks.Max(s => s.Marks);
            Console.WriteLine($"Max Marks of Student :{MaxMarks}");
                Console.WriteLine("First item");
             var obj= students.FirstOrDefault();
            Console.Write($"{obj.Id}\t{obj.Name}\t{obj.Address}\n");
            Console.WriteLine("R------");
            string q = "A";
            var containd = students.Where(s=>s.Name.ToLower().Contains(q.ToLower()));
            containd.ToList().ForEach(item => Console.Write($"{item.Id}\t{item.Name}\t{item.Address}\n"));
            Console.WriteLine("Start with N------");
            var startwith = students.Where(s => s.Name.ToLower().StartsWith(q.ToLower()));
            startwith.ToList().ForEach(item => Console.Write($"{item.Id}\t{item.Name}\t{item.Address}\n"));

            Console.WriteLine("End with N------");
            var endwith = students.Where(s => s.Name.ToLower().EndsWith(q.ToLower()));
            endwith.ToList().ForEach(item => Console.Write($"{item.Id}\t{item.Name}\t{item.Address}\n"));
            Console.WriteLine("Skip---Take---");
     var st=        students.Skip(2).Take(2);
            st.ToList().ForEach(item => Console.Write($"{item.Id}\t{item.Name}\t{item.Address}\n"));

            Console.WriteLine("Join");
            var joinResult = students.Join(StudentMarks, std => std.Id, sm => sm.StudentID,
                   (std, sm) => new { 
                    Name=std.Name,
                    subject=sm.Subject,
                    Marks=sm.Marks
                   }).ToList();
            joinResult.ForEach(item => Console.Write($"{item.Name}\t{item.subject}\t{item.Marks}\n"));

            Console.WriteLine("Left/Group join");
            var gpjoin = students.GroupJoin(StudentMarks,
                sd => sd.Id, sm => sm.StudentID, (sd, grp) => new
                {
                    Name = sd.Name,
                    subject = grp,
                    
                }).ToList();
            foreach(var i in gpjoin)
            {
                Console.WriteLine(i.Name);
                Console.WriteLine("===========");
                foreach(var item in i.subject)
                {
                    Console.Write($"{item.Subject??"N/A"}\t{item.Marks}\n");
                }
            }
            Console.ReadKey();
        }
    }
}
