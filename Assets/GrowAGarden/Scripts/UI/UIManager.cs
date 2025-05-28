using GrowAGarden.Scripts.UI.Windows.PlantWindow;
using UnityEngine;

namespace GrowAGarden.Scripts.UI
{
    public class UIManager : MonoBehaviour, IUIManager
    {
        [Header("Windows")]
        [SerializeField] private PlantWindow plantWindow;
        
        public PlantWindow ShowPlantWindow()
        {
            plantWindow.Show();
            return plantWindow;
        }

        public void HidePlantWindow()
        {
            plantWindow.Hide();
        }
        
    }
}