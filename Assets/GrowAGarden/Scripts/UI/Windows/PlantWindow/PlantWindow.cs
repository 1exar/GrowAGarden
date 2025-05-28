using GrowAGarden.Scripts.Services.InventoryService;
using GrowAGarden.Scripts.Services.Pot;
using GrowAGarden.Scripts.Transfer.Items;
using GrowAGarden.Scripts.UI.Windows.Inventory;
using UnityEngine;
using Zenject;

namespace GrowAGarden.Scripts.UI.Windows.PlantWindow
{
    public class PlantWindow : BaseWindow
    {
        [SerializeField] private Transform itemRoot;
        [SerializeField] private InventoryItemView itemPrefab;
        
        [Inject] private InventoryService _inventoryService;
        
        private PotSlot _currentPot;

        public void SetPot(PotSlot pot)
        {
            _currentPot = pot;
        }

        public override void Show()
        {
            base.Show();
            UpdateView();
        }

        public override void Hide()
        {
            base.Hide();
            _currentPot = null;
        }

        private void UpdateView()
        {
            foreach (Transform child in itemRoot)
            {
                Destroy(child.gameObject);
            }
            
            foreach (var seed in _inventoryService.GetSeeds())
            {
                var item = Instantiate(itemPrefab, itemRoot);
                item.SetSeed(seed);
                item.OnClick += () => OnChoseSeed(seed);
            }
        }

        private void OnChoseSeed(SeedItem chosen)
        {
            _currentPot.Plant(chosen.SeedData);
            _inventoryService.RemoveSeed(chosen);
            
            UpdateView();
        }
    }
}