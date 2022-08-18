using UnityEngine;
using UnityEngine.SceneManagement;
using MVC.Utility;

namespace MVC.Boot
{
    public class SceneLoader : SingletonBehaviour<SceneLoader>
    {
        private bool _isInitialize;
        private string _currentScene;
        public void LoadScene(string sceneName)
        {
            if (!_isInitialize)
            {
                _isInitialize = true;
            }
            else
            {
                UnloadScene();
                _currentScene = sceneName;
                AddScene(sceneName);
            }
        }

        public void AddScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        }

        public void UnloadScene()
        {
            if (!string.IsNullOrEmpty(_currentScene))
            {
                SceneManager.UnloadSceneAsync(_currentScene);
                _currentScene = null;
            }
        }
    }
}
