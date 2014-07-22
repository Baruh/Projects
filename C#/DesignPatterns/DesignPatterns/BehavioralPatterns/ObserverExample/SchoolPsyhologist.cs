namespace DesignPatterns.BehavioralPatterns.ObserverExample
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class SchoolPsyhologist : ISchoolPsychologist
    {
        private IList<WeakStudent> students;

        public string Name { get; private set; }

        public SchoolPsyhologist(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                this.Name = name;
            }
            else
            {
                throw new ArgumentException("The name list cannot be null or empty.");
            }
        }

        public void AddWeakStudent(WeakStudent student)
        {
            if (student != null)
            {
                this.students.Add(student);
            }
            else
            {
                throw new ArgumentNullException("Added student cannot be null.");
            }
        }

        public void Update(WeakStudent student)
        {
            Console.WriteLine("Name: {0}, Gread: {1}", student.Name, student.Grade);
            Console.WriteLine("Marks: {0}", string.Join(", ", student.Marks));
        }
    }
}
