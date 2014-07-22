namespace DesignPatterns.CreationalPatterns.SingletonExample
{
    using System;

    public class Error
    {
        private string message;
        private DateTime errorDate;

        public void LogError(string msg, DateTime dateTime = new DateTime())
        {
            this.Message = msg;
            this.ErrorDate = dateTime;
        }

        public string Message
        {
            get { return this.message; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Error message cannot be null or empty string.");
                }

                this.message = value;
            }
        }

        public DateTime ErrorDate
        {
            get { return this.errorDate; }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Time cannot be null.");
                }

                this.errorDate = value;
            }
        }

        public override string ToString()
        {
            return string.Format("Message: {0}, Date: {1}", this.message, this.errorDate);
        }
    }
}
