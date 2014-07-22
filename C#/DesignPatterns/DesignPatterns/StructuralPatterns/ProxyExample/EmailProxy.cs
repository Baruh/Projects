namespace DesignPatterns.StructuralPatterns.ProxyExample
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class EmailProxy : IEmail
    {
        private Email realEmail;

        public EmailProxy()
        {
            this.realEmail = new Email();
        }

        private void checkForCorrectness(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException("The use name cannot be null or empty string.");
            }

            if (text.Length < 4 || 30 < text.Length)
            {
                throw new ArgumentException("The username must be between 4 and 30 symbols.");
            }

            if (hasForbiddenSymbols(text))
            {
                throw new ArgumentException("The username cannot contain <, >, :, \", /, \\, |, ?, *");
            }
        }

        private bool hasForbiddenSymbols(string text)
        {
            var isContain = Regex.IsMatch(text, @"([""\\<>:/?*|])");

            return isContain;
        }

        public void GoIn(string username, string password)
        {
            checkForCorrectness(username);
            checkForCorrectness(password);
            this.realEmail.GoIn(username, password);
        }
    }
}
