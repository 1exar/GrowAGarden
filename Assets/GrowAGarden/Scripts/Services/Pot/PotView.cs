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

        public void SetPotSlot(PotSlot pot) => thisPot = pot;
        
        public void PlantSeed(SeedData seed)
        {
            plantedSeed = seed;
            thisPot.Plant(seed);
        }

        public void OnClickPlant()
        {
            _uiManager.ShowPlantWindow(thisPot);
        }

        public void OnClickHarvest()
        {
            thisPot.Harvest();
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