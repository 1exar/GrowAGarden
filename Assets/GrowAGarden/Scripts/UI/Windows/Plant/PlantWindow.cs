using System.Collections.Generic;
using GrowAGarden.Scripts.Services.PlayerData;
using GrowAGarden.Scripts.Services.Pot;
using GrowAGarden.Scripts.Transfer.Data;
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
        
        [Inject] private IPlayerDataService _playerDataService;

        private List<InventoryItemView> _inventoryItemViews = new();
        
        private PotSlot _currentPot;

        private SeedData _selectedSeed;
        
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
            if(_selectedSeed != null)
                TryPlant(_selectedSeed);
        }
        
        private void UpdateView()
        {
            foreach (Transform child in itemRoot)
            {
                Destroy(child.gameObject);
            }
            
            foreach (var seed in _playerDataService.Get().seedsInInventory)
            {
                var item = Instantiate(itemPrefab, itemRoot);
                _inventoryItemViews.Add(item);
                item.SetSeed(seed);
                item.OnClick += () =>
                {
                    _selectedSeed = seed.SeedData;
                    _inventoryItemViews.ForEach(i => i.Deselect());
                    item.Select();
                };
            }
        }

        private void TryPlant(SeedData chosen)
        {
            if (_currentPot.Plant(chosen))
            {
                _playerDataService.RemoveSeed(chosen);
            
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