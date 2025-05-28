using GrowAGarden.Scripts.Services.Pot;
using GrowAGarden.Scripts.UI.Windows.PlantWindow;

namespace GrowAGarden.Scripts.UI
{
    public interface IUIManager
    {
        PlantWindow ShowPlantWindow(PotSlot potSlot);
        void HidePlantWindow();
        
        void ShowInventoryWindow();
        void HideInventoryWindow();
    }
}