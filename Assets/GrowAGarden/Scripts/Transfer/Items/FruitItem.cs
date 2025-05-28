using GrowAGarden.Scripts.Transfer.Data;
using GrowAGarden.Scripts.Transfer.Enums;

namespace GrowAGarden.Scripts.Transfer.Items
{
    public class FruitItem
    {
        public SeedData SourceSeed { get; }
        public MutationType Mutation { get; }

        public FruitItem(SeedData seed, MutationType mutation)
        {
            SourceSeed = seed;
            Mutation = mutation;
        }

        public float GetSellValue()
        {
            float baseValue = SourceSeed.BasePrice;
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