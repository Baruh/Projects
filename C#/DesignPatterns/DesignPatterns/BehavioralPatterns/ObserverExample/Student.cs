namespace DesignPatterns.BehavioralPatterns.ObserverExample
{
    using System;
    using System.Collections.Generic;

    internal class Student
    {
        private string name;
        private int grade;
        protected IEnumerable<int> marks;

        public Student(string name, int grade)
        {
            this.Name = name;
            this.Grade = grade;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.name = value;
                }
                else
                {
                    throw new ArgumentException("Name cannot be null or empty string.");
                }
            }
        }

        public int Grade
        {
            get { return this.grade; }
            set
            {
                if (value > 0)
                {
                    this.grade = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Grade cannot be negative or zero number.");
                }
            }
        }

        public virtual IEnumerable<int> Marks
        {
            get { return marks; }
            set
            {
                if (value != null)
                {
                    this.marks = value;
                }
            }
        }
    }
}
