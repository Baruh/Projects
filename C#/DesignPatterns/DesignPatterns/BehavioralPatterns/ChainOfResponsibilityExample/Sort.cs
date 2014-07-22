namespace DesignPatterns.BehavioralPatterns.ChainOfResponsibilityExample
{
    internal abstract class Sort
    {
        public Sort NextInChain { get; set; }

        public abstract void ProcessSort(int[] numbers);
    }
}
