using GrowAGarden.Scripts.UI.Windows.PlantWindow;

namespace GrowAGarden.Scripts.UI
{
    public interface IUIManager
    {
        PlantWindow ShowPlantWindow();
        void HidePlantWindow();
    }
}