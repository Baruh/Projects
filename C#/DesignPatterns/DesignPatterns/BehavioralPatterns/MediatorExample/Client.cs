namespace DesignPatterns.BehavioralPatterns.MediatorExample
{
    using System;

    internal class Client
    {
        private string fullName;
        private string contractType;
        private string number;
        private DateTime dateOfSigning;
                
        public Client(string initFullName, string initNumber, string initContractType, DateTime startDate)
        {
            this.FullName = initFullName;
            this.Number = initNumber;
            this.ContractType = initContractType;
            this.DateOfSigning = startDate;
        }

        public string FullName
        {
            get { return this.fullName; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.fullName = value;
                }
                else
                {
                    throw new ArgumentException("Name cannot be null or empty string.");
                }

                this.fullName = value;
            }
        }

        public string Number
        {
            get { return this.number; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.number = value;
                }
                else
                {
                    throw new ArgumentException("Number cannot be null or empty string.");
                }

                this.number = value;
            }
        }

        public string ContractType
        {
            get { return this.contractType; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this.contractType = value;
                }
                else
                {
                    throw new ArgumentException("Contract type cannot be null or empty string.");
                }

                this.contractType = value;
            }
        }

        public DateTime DateOfSigning
        {
            get { return this.dateOfSigning; }
            private set
            {
                if (value != null)
                {
                    this.dateOfSigning = value;
                }
                else
                {
                    throw new ArgumentNullException("Date of signing cannot be null.");
                }

                this.dateOfSigning = value;
            }
        }

        public void ReceiveCall(string from)
        {
            Console.WriteLine("{0} calls to {1}", from, this.Number);
        }
    }
}
