using GrowAGarden.Scripts.Services.Pot;
using GrowAGarden.Scripts.Transfer.Config;
using GrowAGarden.Scripts.Transfer.Data;
using UnityEngine;
using Zenject;

public class TestPot : MonoBehaviour
{
    [Inject] private PotService potService;

    [SerializeField] private PotSlot thisPot;
    [SerializeField] private PotConfig potConfig;

    [SerializeField] private SeedData testSeed;
    
    private void Start()
    {
        thisPot = new PotSlot(potConfig);
        potService.AddPot(thisPot);

        thisPot.Plant(testSeed);
    }

    private void Update()
    {
        if(thisPot.IsReady) Debug.Log("can Harvest");
    }

    private void OnMouseDown()
    {
        var fruit = thisPot.Harvest();
        Debug.LogError(fruit.SourceSeed.SeedName);
    }
}
