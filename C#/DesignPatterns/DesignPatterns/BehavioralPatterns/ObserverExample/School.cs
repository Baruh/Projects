namespace DesignPatterns.BehavioralPatterns.ObserverExample
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class School
    {
        private ISchoolPsychologist psychologist;
        private IList<Student> allStudents = new List<Student>();
        private IList<WeakStudent> studentsWithLowMark;
               
        public School(IEnumerable<Student> initStudents)
        {
            if (initStudents == null)
            {
                throw new ArgumentNullException("Students cannot be null.");
            }

            this.allStudents = initStudents.ToList();
        }

        public ISchoolPsychologist Psyhologist
        {
            set
            {
                if (value != null)
                {
                    this.psychologist = value;
                } 
            }
        }

        public IEnumerable<WeakStudent> FoundAllWeakStudents()
        {
            return FoundAllWeakStudents(IsFailDefault);
        }

        public IEnumerable<WeakStudent> FoundAllWeakStudents(Func<Student, bool> predicate)
        {
            foreach (var student in this.allStudents)
            {
                if (predicate(student))
                {
                    WeakStudent weakStudent = new  WeakStudent(student.Name, student.Grade) 
                                                    {
                                                         Marks = student.Marks,
                                                    };

                    weakStudent.Attach(this.psychologist);

                    yield return weakStudent;
                }
            }
        }

        private bool IsFailDefault(Student student)
        {
            var average = student.Marks.Average();
            return average < 4.0;
        }
    }
}
