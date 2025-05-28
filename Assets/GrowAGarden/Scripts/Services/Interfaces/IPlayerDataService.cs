using Cysharp.Threading.Tasks;

namespace GrowAGarden.Scripts.Services.Interfaces
{
    public interface IPlayerDataService
    {
        UniTask LoadAsync();
        UniTask SaveAsync();
        Transfer.Data.PlayerData Get();
    }
}