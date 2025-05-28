namespace GrowAGarden.Scripts.Transfer.Items
{
    public class BaseItem
    {
        public int Quantity { get; private set; }

        public BaseItem(int quantity)
        {
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