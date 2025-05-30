using System;
using GrowAGarden.Scripts.Transfer.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GrowAGarden.Scripts.UI.Windows.SeedShop
{
    public class SeedVariant : MonoBehaviour
    {

        [SerializeField] private TMP_Text seedName;
        [SerializeField] private TMP_Text seedQunatity;
        [SerializeField] private TMP_Text seedPrice;
        [SerializeField] private TMP_Text seedRarity;
        
        [SerializeField] private Image seedIcon;

        [SerializeField] private Button buyButton;
        
        public Action<SeedData> OnBuyButtonClicked;

        public void Setup(SeedData seed)
        {
            seedName.text = seed.seedName;
            seedPrice.text = seed.basePrice.ToString();
            seedRarity.text = seed.rarityLevel.ToString();
            seedIcon.sprite = seed.icon;
            buyButton.onClick.AddListener(() => OnBuyButtonClicked?.Invoke(seed));
        }

    }
}