using System;
using GrowAGarden.Scripts.Transfer.Items;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace GrowAGarden.Scripts.UI.Windows.Inventory
{
    public class InventoryItemView : MonoBehaviour, IPointerDownHandler
    {
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private Image icon;

        public Action OnClick;
        private IPointerDownHandler _pointerDownHandlerImplementation;

        public void SetSeed(SeedItem data)
        {
            nameText.text = data.SeedData.seedName + " x" + data.Quantity;
            icon.sprite = data.SeedData.icon;
        }

        public void SetFruit(FruitItem data)
        {
            nameText.text = data.SourceSeed.seedName;
            icon.sprite = data.SourceSeed.icon;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnClick?.Invoke();
        }
    }
}