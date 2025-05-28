using UnityEngine;

namespace GrowAGarden.Scripts.Transfer.Config
{
    [CreateAssetMenu(fileName = "PotConfig", menuName = "Configs/PotConfig")]
    public class PotConfig : ScriptableObject
    {
        public int InitialPotCount = 3;
        public float GrowthSpeedMultiplier = 1f;
        public float MutationChance = 0.05f;
    }

}