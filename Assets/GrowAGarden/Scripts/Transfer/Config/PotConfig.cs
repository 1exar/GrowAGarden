using UnityEngine;

namespace GrowAGarden.Scripts.Transfer.Config
{
    [CreateAssetMenu(fileName = "PotConfig", menuName = "Configs/PotConfig")]
    public class PotConfig : ScriptableObject
    {
        public float growthSpeedMultiplier = 1f;
        public float mutationChance = 0.05f;
    }

}