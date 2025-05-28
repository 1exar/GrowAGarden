using GrowAGarden.Scripts.Transfer.Items;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GrowAGarden.Scripts.UI.Windows.Inventory
{
    public class InventoryItemView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private Image icon;

        public void SetSeed(SeedItem data)
        {
            nameText.text = data.SeedData.SeedName;
            icon.sprite = data.SeedData.Icon;
        }

        public void SetFruit(FruitItem data)
        {
            nameText.text = data.SourceSeed.SeedName;
            icon.sprite = data.SourceSeed.Icon;
        }
    }
}