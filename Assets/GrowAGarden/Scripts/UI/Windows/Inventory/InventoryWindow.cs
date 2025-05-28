using GrowAGarden.Scripts.Services.Inventory;
using GrowAGarden.Scripts.Transfer.Enums;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace GrowAGarden.Scripts.UI.Windows.Inventory
{
    public class InventoryWindow : BaseWindow
    {
        [Inject] private InventoryService _inventoryService;

        [SerializeField] private Button seedsTabButton;
        [SerializeField] private Button fruitsTabButton;
        [SerializeField] private Transform itemRoot;
        [SerializeField] private InventoryItemView itemPrefab;

        private InventoryTab _currentTab = InventoryTab.Fruits;

        private void Awake()
        {
            seedsTabButton.onClick.AddListener(() => SwitchTab(InventoryTab.Seeds));
            fruitsTabButton.onClick.AddListener(() => SwitchTab(InventoryTab.Fruits));
        }

        public override void Show()
        {
            base.Show();
            _inventoryService.OnInventoryChanged += Refresh;
            
            _currentTab = InventoryTab.Fruits;
            
            Refresh();
        }

        public override void Hide()
        {
            base.Hide();
            _inventoryService.OnInventoryChanged -= Refresh;
        }

        private void SwitchTab(InventoryTab tab)
        {
            _currentTab = tab;
            Refresh();
        }

        private void Refresh()
        {
            foreach (Transform child in itemRoot)
            {
                Destroy(child.gameObject);
            }

            if (_currentTab == InventoryTab.Seeds)
            {
                foreach (var seed in _inventoryService.GetSeeds())
                {
                    var item = Instantiate(itemPrefab, itemRoot);
                    item.SetSeed(seed);
                }
            }
            else
            {
                foreach (var fruit in _inventoryService.GetFruits())
                {
                    var item = Instantiate(itemPrefab, itemRoot);
                    item.SetFruit(fruit);
                }
            }
        } 
    }
}