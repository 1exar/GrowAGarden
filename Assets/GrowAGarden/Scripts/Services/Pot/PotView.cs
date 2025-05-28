using System;
using GrowAGarden.Scripts.Transfer.Config;
using GrowAGarden.Scripts.Transfer.Data;
using UnityEngine;
using Zenject;

namespace GrowAGarden.Scripts.Services.Pot
{
    public class PotView : MonoBehaviour
    {
        [SerializeField] private GameObject interactionUI;
        
        [Inject] private PotConfig config;
        private PotSlot thisPot;
        private SeedData plantedSeed;
        
        private void Start()
        {
            thisPot = new(config);
            Debug.LogError(config.GrowthSpeedMultiplier);
        }

        public void PlantSeed(SeedData seed)
        {
            plantedSeed = seed;
            thisPot.Plant(seed);
        }

        public void OnTriggerEnter(Collider other)
        {
            interactionUI.SetActive(true);
        }

        public void OnTriggerExit(Collider other)
        {
            interactionUI.SetActive(false);
        }
    }
}