using System;
using GrowAGarden.Scripts.Services.SeedShop;
using TMPro;
using UnityEngine;
using Zenject;

namespace GrowAGarden.Scripts.UI.Windows.SeedShop
{
    public class SeedShopWindow : BaseWindow
    {

        [SerializeField] private TMP_Text timerText;
        [Inject] SeedShopService seedShopService;

        public override void Show()
        {
            base.Show();
        }

        private void Update()
        {
            timerText.text = $"{TimeSpan.FromSeconds(seedShopService.RemainingTime).Minutes}:{TimeSpan.FromSeconds(seedShopService.RemainingTime).Seconds:D2}";
        }
    }
}