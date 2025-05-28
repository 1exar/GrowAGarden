using System;
using GrowAGarden.Scripts.Transfer.Config;
using GrowAGarden.Scripts.Transfer.Data;
using GrowAGarden.Scripts.UI;
using UnityEngine;
using Zenject;

namespace GrowAGarden.Scripts.Services.Pot
{
    public class PotView : MonoBehaviour
    {
        [SerializeField] private GameObject interactionUI;
        
        [Inject] private IUIManager _uiManager;
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

        public void OnClickPlant()
        {
            _uiManager.ShowPlantWindow();
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