namespace DesignPatterns.BehavioralPatterns.ChainOfResponsibilityExample
{
    internal static class SortCombiner
    {
        public static Sort GetSort()
        {
            // make the chain of invocations
            var selectSort = new SelectionSort();
            var quickSort = new QuickSort();
            selectSort.NextInChain = quickSort;

            return selectSort;
        }
    }
}
