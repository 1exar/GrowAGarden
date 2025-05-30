using System;
using System.Collections.Generic;
using GrowAGarden.Scripts.Services.PlayerData;
using GrowAGarden.Scripts.Services.SeedShop;
using GrowAGarden.Scripts.Transfer.Data;
using TMPro;
using UnityEngine;
using Zenject;

namespace GrowAGarden.Scripts.UI.Windows.SeedShop
{
    public class SeedShopWindow : BaseWindow
    {

        [SerializeField] private TMP_Text timerText;
        [SerializeField] private SeedVariant seedVariantPrefab;

        [SerializeField] private Transform shopParent;
        
        [Inject] private IPlayerDataService _playerDataService;
        [Inject] private SeedShopService _seedShopService;

        private List<SeedVariant> _shopProducts = new();

        private void Start()
        {
            _seedShopService.OnShopUpdated += UpdateShop;
            UpdateShop();
        }

        private void OnDestroy()
        {
            _seedShopService.OnShopUpdated -= UpdateShop;
        }

        private void UpdateShop()
        {
            _shopProducts.ForEach(product => Destroy(product.gameObject));
            
            _shopProducts.Clear();
            
            _seedShopService.CurrentShopSeeds.ForEach(seed =>
            {
                var productVariant = Instantiate(seedVariantPrefab, shopParent).GetComponent<SeedVariant>();
                
                productVariant.Setup(seed);
                _shopProducts.Add(productVariant);
                productVariant.OnBuyButtonClicked += BuySeed;
            });
        }

        private void BuySeed(SeedData seed)
        {
            if (_playerDataService.TrySpendMoney(seed.basePrice))
            {
                _playerDataService.AddSeed(seed);
            }
            else
            {
                Debug.Log("no money");
            }
        }
        
        private void Update()
        {
            timerText.text = $"{TimeSpan.FromSeconds(_seedShopService.RemainingTime).Minutes}:{TimeSpan.FromSeconds(_seedShopService.RemainingTime).Seconds:D2}";
        }
    }
}