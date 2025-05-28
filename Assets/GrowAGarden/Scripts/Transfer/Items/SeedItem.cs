using GrowAGarden.Scripts.Transfer.Data;

namespace GrowAGarden.Scripts.Transfer.Items
{
    public class SeedItem
    {
        public SeedData SeedData { get; private set; }
        public int Quantity { get; private set; }

        public SeedItem(SeedData data, int quantity)
        {
            SeedData = data;
            Quantity = quantity;
        }

        public void AddQuantity(int amount)
        {
            Quantity += amount;
        }

        public bool RemoveQuantity(int amount)
        {
            if (Quantity < amount) return false;
            Quantity -= amount;
            return true;
        }
    }
}