using Cysharp.Threading.Tasks;
using GrowAGarden.Scripts.Bootstrap.Interfaces;
using UnityEngine.SceneManagement;

namespace GrowAGarden.Scripts.Bootstrap
{
    public class SceneLoader : ISceneLoader
    {
        public async UniTask LoadSceneAsync(string sceneName)
        {
            var load = SceneManager.LoadSceneAsync(sceneName);
            while (!load.isDone)
            {
                await UniTask.Yield();
            }
        }
    }
}