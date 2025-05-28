using Cysharp.Threading.Tasks;

namespace GrowAGarden.Scripts.Services.PlayerData
{
    public interface IPlayerDataService
    {
        UniTask LoadAsync();
        UniTask SaveAsync();
        Transfer.Data.PlayerData Get();
    }
}