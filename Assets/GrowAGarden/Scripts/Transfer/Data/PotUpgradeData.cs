using System;

namespace GrowAGarden.Scripts.Transfer.Data
{
    [Serializable]
    public class PotUpgradeData
    {
        public int PotSlotIndex; // индекс слота/горшка
        public float GrowthSpeedMultiplier = 1f;
        public float MutationChanceMultiplier = 1f;
    }
}