using GrowAGarden.Scripts.Services.InventoryService;
using GrowAGarden.Scripts.Services.Pot;
using GrowAGarden.Scripts.Transfer.Data;
using GrowAGarden.Scripts.Transfer.Items;
using UnityEngine;
using Zenject;

public class TestPot : MonoBehaviour
{
    [Inject] private InventoryService _inventoryService;
    [SerializeField] private SeedData tempSeed;
    
    private void Start()
    {
        _inventoryService.AddSeed(new SeedItem(tempSeed,10));
    }
}
