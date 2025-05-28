using Cysharp.Threading.Tasks;

namespace GrowAGarden.Scripts.Bootstrap.Interfaces
{
    public interface ISceneLoader
    {
        UniTask LoadSceneAsync(string sceneName);
    }
}