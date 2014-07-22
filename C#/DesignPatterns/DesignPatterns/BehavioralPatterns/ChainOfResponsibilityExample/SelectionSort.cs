namespace DesignPatterns.BehavioralPatterns.ChainOfResponsibilityExample
{
    internal class SelectionSort : Sort
    {
        private const int MAX_SIZE = 30;

        public override void ProcessSort(int[] numbers)
        {
            if (numbers.Length < MAX_SIZE)
            {
                this.InnerSelectionSort(numbers);
            }
            else if (this.NextInChain != null)
            {
                this.NextInChain.ProcessSort(numbers);
            }
        }

        private void InnerSelectionSort(int[] numbers)
        {
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                int index = i;
                var min = numbers[i];
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (min > numbers[j])
                    {
                        min = numbers[j];
                        index = j;
                    }
                }
                // Swap
                if (i != index)
                {
                    numbers[index] = numbers[i];
                    numbers[i] = min;
                }                
            }
        }
    }
}
