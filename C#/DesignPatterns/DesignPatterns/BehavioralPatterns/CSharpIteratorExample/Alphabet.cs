namespace DesignPatterns.BehavioralPatterns.CSharpIteratorExample
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Alphabet : IEnumerable<char>
    {
        private IList<char> alphabet;

        public Alphabet(string initAlphabeta)
        {
            if (!string.IsNullOrWhiteSpace(initAlphabeta))
            {
                this.alphabet = initAlphabeta
                                .Trim()
                                .Distinct()
                                .ToList();
            }
            else
            {
                throw new ArgumentNullException("The alphabeta cannot be null or empty string.");
            }
        }

        public Alphabet(char[] initAlphabeta)
        {
            if (initAlphabeta != null)
            {
                this.alphabet = initAlphabeta
                                .Distinct()
                                .ToList();
            }
            else
            {
                throw new ArgumentNullException("The alphabeta cannot be null array of chars.");
            }
        }

        public IEnumerator<char> GetEnumerator()
        {
            for (int i = 0; i < this.alphabet.Count; i++)
            {
                yield return this.alphabet[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
