namespace DesignPatterns.StructuralPatterns.AdapterExample
{
    using System;

    public class BananaAdapter : IBanana
    {
        private Banana adapteeBanana;
        public BananaAdapter(Banana banana)
        {
            if (banana != null)
            {
                this.adapteeBanana = banana;
            }
            else
            {
                throw new ArgumentNullException("Value cannot be null.");
            }
        }

        public void PrintInfo()
        {
            this.adapteeBanana.ShowAllBananaInformation();
        }
    }
}
