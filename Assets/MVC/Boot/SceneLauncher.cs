using System.Collections;
using UnityEngine;
using MVC.Utility;
using MVC.Component;

namespace MVC.Boot
{
    public abstract class SceneLauncher : SingletonBehaviour<SceneLauncher>
    {
        public abstract string SceneName { get; }

        private void Awake()
        {
            StartCoroutine(Initialize());
        }

        private IEnumerator Initialize()
        {
            var sceneLoader = SceneLoader.Instance;
            sceneLoader.LoadScene(SceneName);
            yield return null;
        }

        protected abstract IController[] GetControllers();
    }
}
