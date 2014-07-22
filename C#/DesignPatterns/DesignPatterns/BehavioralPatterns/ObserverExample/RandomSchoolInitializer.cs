namespace DesignPatterns.BehavioralPatterns.ObserverExample
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;

    internal static class RandomSchoolInitializer
    {
        public static School getRandomSchool()
        {
            var students = GenerateRandomStudents(10);
            var psychologist = new SchoolPsyhologist("Vanq Marionova");
            var school = new School(students);
            school.Psyhologist = psychologist;

            return school;
        }

        private static IEnumerable<Student> GenerateRandomStudents(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var random = new Random();
                var marks = Enumerable
                            .Repeat<Func<int, int, int>>(random.Next, 7)
                            .Select(rnd => rnd(2, 7));

                var grade = Enumerable
                            .Repeat<Func<int, int, int>>(random.Next, 1)
                            .Select(rndGrade => rndGrade(1, 13))
                            .First();

                var name = "Pesho" + (i + 1);
                var student = new Student(name, grade);
                student.Marks = marks;

                Thread.Sleep(15);

                yield return student;
            }
        }
    }
}
