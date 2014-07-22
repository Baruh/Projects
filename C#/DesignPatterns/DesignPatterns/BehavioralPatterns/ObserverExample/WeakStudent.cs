namespace DesignPatterns.BehavioralPatterns.ObserverExample
{
    using System;
    using System.Collections.Generic;

    internal class WeakStudent : Student
    {
        private IList<ISchoolPsychologist> psychologists;

        public WeakStudent(string name, int grade)
            : base(name, grade) { }
       
        public override IEnumerable<int> Marks 
        {
            get { return marks; }
            set
            {
                if (value != null)
                {
                    this.marks = value;
                    if (this.psychologists != null)
                    {
                        this.Notify();
                    }
                }
            }
        }

        public void Attach(ISchoolPsychologist psychologist)
        {
            if (this.psychologists == null)
            {
                this.psychologists = new List<ISchoolPsychologist>();
            }

            this.psychologists.Add(psychologist);
        }

        public void Detach(ISchoolPsychologist ISchoolPsychologist)
        {
            if (this.psychologists != null)
            {
                this.psychologists.Remove(ISchoolPsychologist);
            }
        }

        public void Notify()
        {
            foreach (ISchoolPsychologist psychologist in this.psychologists)
            {
                psychologist.Update(this);
            }
        }
    }
}
