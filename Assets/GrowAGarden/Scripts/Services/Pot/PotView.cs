using GrowAGarden.Scripts.Transfer.Config;
using GrowAGarden.Scripts.Transfer.Data;
using GrowAGarden.Scripts.UI;
using TMPro;
using UnityEngine;
using Zenject;

namespace GrowAGarden.Scripts.Services.Pot
{
    public class PotView : MonoBehaviour
    {
        [SerializeField] private GameObject interactionUI;

        [SerializeField] private TMP_Text seedText;
        [SerializeField] private TMP_Text statusText;
        
        [Inject] private IUIManager _uiManager;
        [Inject] private PotConfig config;
        
        private PotSlot thisPot;
        private SeedData plantedSeed;

        public void SetPotSlot(PotSlot pot) => thisPot = pot;

        private void Update()
        {
            if (thisPot.HasPlant)
            {
                if (thisPot.IsReady)
                {
                    statusText.text = "can be harved";
                }
                else
                {
                    statusText.text = "growing";
                }
            }
            else
            {
                statusText.text = "need seed";
            }
        }

        public void PlantSeed(SeedData seed)
        {
            plantedSeed = seed;
            thisPot.Plant(seed);

            seedText.text = seed.SeedName;
        }

        public void OnClickPlant()
        {
            _uiManager.ShowPlantWindow(thisPot);
        }

        public void OnClickHarvest()
        {
            thisPot.Harvest();
        }

        public void OnClickRemoveSeed()
        {
            thisPot.RemoveSeed();
            seedText.text = "";
            statusText.text = "need seed";
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