using GrowAGarden.Scripts.Transfer.Data;

namespace GrowAGarden.Scripts.Transfer.Items
{
    public class SeedItem : BaseItem
    {
        public SeedData SeedData { get; private set; }

        public SeedItem(SeedData data, int quantity) : base(quantity)
        {
            itemName = data.name;
            SeedData = data;
        }
    }
}