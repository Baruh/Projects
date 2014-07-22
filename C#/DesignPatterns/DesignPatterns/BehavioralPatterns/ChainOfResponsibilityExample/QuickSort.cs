namespace DesignPatterns.BehavioralPatterns.ChainOfResponsibilityExample
{
    using System;

    internal class QuickSort : Sort
    {
        private const int MAX_SIZE = 1000000;

        public override void ProcessSort(int[] numbers)
        {
            if (numbers.Length < MAX_SIZE)
            {
                this.InnerQuickSort(numbers, 0, numbers.Length - 1);
            }
            else
            {
                throw new ArgumentOutOfRangeException("Cannot handle so big array.");
            }
        }

        public void InnerQuickSort(int[] numbers, int left, int right)
        {
            int i = left;
            int j = right;
            int pivot = numbers[(left + right) / 2];

            while (i <= j)
            {
                while (numbers[i].CompareTo(pivot) < 0)
                {
                    i++;
                }

                while (numbers[j].CompareTo(pivot) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    // Swap
                    int tmp = numbers[i];
                    numbers[i] = numbers[j];
                    numbers[j] = tmp;

                    i++;
                    j--;
                }
            }

            // Recursive calls
            if (left < j)
            {
                this.InnerQuickSort(numbers, left, j);
            }

            if (i < right)
            {
                this.InnerQuickSort(numbers, i, right);
            }
        }
    }
}
