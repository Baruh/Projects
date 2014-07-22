namespace DesignPatterns.CreationalPatterns.SingletonExample
{
    using System;
    using System.Collections.Generic;

    public sealed class Logger
    {
        private static readonly Logger instance = new Logger();
        private List<Error> errors;

        private Logger()
        {
            this.errors = new List<Error>();
        }

        public static Logger Instance
        {
            get { return instance; }
        }

        public void AddError(Error error)
        {
            if (error != null)
            {
                this.errors.Add(error);
            }

            throw new ArgumentNullException("Error cannot be null.");
        }

        public void AddError(string message, DateTime dateTime = new DateTime())
        {
            var error = new Error();
            error.LogError(message, dateTime);
            this.errors.Add(error);
        }

        public IEnumerable<Error> GetAllErrors
        {
            get
            {
                foreach (var error in this.errors)
                {
                    yield return error;
                }
            }
        }
    }
}
