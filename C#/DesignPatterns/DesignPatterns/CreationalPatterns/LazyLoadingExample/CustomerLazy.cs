namespace DesignPatterns.CreationalPatterns.LazyLoadingExample
{
    using System;

    public class CustomerLazy<T> where T : new()
    {
        private readonly Func<T> initFunction;

        public CustomerLazy()
        {
            this.initFunction = () => new T();
        }

        public CustomerLazy(Func<T> init)
        {
            this.initFunction = init;
        }

        public T Value
        {
            get
            {
                return initFunction();
            }
        }
    }
}
