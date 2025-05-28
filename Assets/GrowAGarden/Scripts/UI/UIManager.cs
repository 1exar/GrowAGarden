using GrowAGarden.Scripts.Services.Pot;
using GrowAGarden.Scripts.UI.Windows.Inventory;
using GrowAGarden.Scripts.UI.Windows.Plant;
using UnityEngine;

namespace GrowAGarden.Scripts.UI
{
    public class UIManager : MonoBehaviour, IUIManager
    {
        [Header("Windows")]
        [SerializeField] private PlantWindow plantWindow;
        [SerializeField] private InventoryWindow inventoryWindow;
        
        public PlantWindow ShowPlantWindow(PotSlot potSlot)
        {
            plantWindow.SetPot(potSlot);
            plantWindow.Show();
            return plantWindow;
        }

        public void HidePlantWindow()
        {
            plantWindow.Hide();
        }

        public void ShowInventoryWindow()
        {
            inventoryWindow.Show();
        }

        public void HideInventoryWindow()
        {
            inventoryWindow.Hide();
        }
    }
}