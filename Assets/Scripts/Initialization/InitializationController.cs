using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace QuestSystem.Initialization
{
    public class InitializationController : IInitializable
    {
        public void Initialize()
        {
            Application.targetFrameRate = 60;
            StartInitialization().Forget();
        }

        private async UniTaskVoid StartInitialization()
        {
            await WaitLoadScene();
        }

        private async UniTask WaitLoadScene()
        {
            await SceneManager.LoadSceneAsync(Constants.MainScene).ToUniTask();
        }
    }
}