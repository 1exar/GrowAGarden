using GrowAGarden.Scripts.Transfer.Data;
using GrowAGarden.Scripts.Transfer.Enums;

namespace GrowAGarden.Scripts.Transfer.Items
{
    public class FruitItem : BaseItem
    {
        public SeedData SourceSeed { get; }
        private MutationType Mutation { get; }

        public FruitItem(SeedData seed, MutationType mutation) : base(0)
        {
            SourceSeed = seed;
            Mutation = mutation;
        }

        public float GetSellValue()
        {
            float baseValue = SourceSeed.basePrice;
            float multiplier = Mutation switch
            {
                MutationType.Golden => 2f,
                MutationType.Rainbow => 3f,
                _ => 1f
            };

            return baseValue * multiplier;
        }
    }
}