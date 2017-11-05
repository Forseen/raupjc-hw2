using System;
using System.Linq;
using Hw2_Tests.Assignment1;

namespace Hw2_Tests.Assignment4
{
    public class HomeworkLinqQueries
    {
        public static string[] Linq1(int[] intArray)
        {
            var strings = intArray.GroupBy(x => x)
                .Select(g => new {Value = g.Key, Count = g.Count()})
                .OrderBy(x => x.Value)
                .Select(x => String.Format("Broj {0} ponavlja se {1} puta", x.Value, x.Count))
                .ToArray();

            return strings;
        }
        
        public static University[] Linq2_1(University[] universityArray)
        {
            
            var unis = universityArray.Where(x => x.Students.All(y => y.Gender == Gender.Male)).ToArray();
            return unis;
        }

        public static University[] Linq2_2(University[] universityArray)
        {
            var noOfStudents = universityArray.Select(x => x.Students.Count()).ToArray();
            var average = noOfStudents.Average();
            var unis = universityArray.Where(x => x.Students.Count() < average).ToArray();
            return unis;
        }
        
        public static Student[] Linq2_3(University[] universityArray)
        {
            var students =  universityArray.SelectMany(x => x.Students)
                                           .Distinct()
                                           .ToArray();
            return students;
        }
        
        public static Student[] Linq2_4(University[] universityArray)
        {
            var students = universityArray.Where(x => x.Students.All(y => y.Gender == Gender.Male)
                                                  || x.Students.All(z => z.Gender == Gender.Female))
                                                     .SelectMany(a => a.Students)
                                                     .Distinct()
                                                     .ToArray();
            return students;
        }

        public static Student[] Linq2_5(University[] universityArray)
        {
            var students = universityArray.SelectMany(x => x.Students)
                .GroupBy(y => y)
                .Where(z => z.Count() > 1)
                .Select(z => z.Key)
                .Distinct()
                .ToArray();
            return students;
        }
    }
}