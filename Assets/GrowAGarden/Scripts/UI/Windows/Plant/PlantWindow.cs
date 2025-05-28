using System.Collections.Generic;
using GrowAGarden.Scripts.Services.Inventory;
using GrowAGarden.Scripts.Services.Pot;
using GrowAGarden.Scripts.Transfer.Items;
using GrowAGarden.Scripts.UI.Windows.Inventory;
using UnityEngine;
using Zenject;

namespace GrowAGarden.Scripts.UI.Windows.Plant
{
    public class PlantWindow : BaseWindow
    {
        [SerializeField] private Transform itemRoot;
        [SerializeField] private InventoryItemView itemPrefab;
        
        [Inject] private InventoryService _inventoryService;

        private List<InventoryItemView> _inventoryItemViews = new();
        
        private PotSlot _currentPot;

        private SeedItem selectedItem;
        
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

        public void OnClickPlant()
        {
            if(selectedItem != null)
                TryPlant(selectedItem);
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
                _inventoryItemViews.Add(item);
                item.SetSeed(seed);
                item.OnClick += () =>
                {
                    selectedItem = seed;
                    _inventoryItemViews.ForEach(i => i.Deselect());
                    item.Select();
                };
            }
        }

        private void TryPlant(SeedItem chosen)
        {
            if (_currentPot.Plant(chosen.SeedData))
            {
                _inventoryService.RemoveSeed(chosen);
            
                UpdateView();
                Hide();
            }
            else
            {
                Debug.LogError("cant plant");
            }
        }
    }
}