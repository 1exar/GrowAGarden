using GrowAGarden.Scripts.Services.SeedShop;
using UnityEngine;
using Zenject;

public class SeedShopTestUI : MonoBehaviour
{
    [Inject] private SeedShopService _seedShopService;

    private void OnEnable()
    {
        _seedShopService.OnShopUpdated += OnShopUpdated;
        PrintCurrentShop();
    }

    private void OnDisable()
    {
        _seedShopService.OnShopUpdated -= OnShopUpdated;
    }

    private void OnShopUpdated()
    {
        PrintCurrentShop();
    }

    private void PrintCurrentShop()
    {
        var seeds = _seedShopService.CurrentShopSeeds;
        foreach (var seed in seeds)
        {
            Debug.Log($"- {seed.SeedName} (Редкость: {seed.RarityLevel}, Цена: {seed.BasePrice})");
        }
    }
}