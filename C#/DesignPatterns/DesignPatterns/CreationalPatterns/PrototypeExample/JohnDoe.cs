namespace DesignPatterns.CreationalPatterns.PrototypeExample
{
    public class JohnDoe : IPrototype
    {
        public JohnDoe(string name = "John Doe", int age = 0)
        {
            this.ActualName  = name;
            this.Age = age;
        }

        public string ActualName { get; set; }

        public int Age { get; set; }

        public object Clone()
        {
            var newJohnDoe = new JohnDoe(this.ActualName, this.Age);
            return newJohnDoe;
        }

        public override string ToString()
        {
            return string.Format("Name: {0}, Age: {1}", this.ActualName, this.Age);
        }
    }
}
