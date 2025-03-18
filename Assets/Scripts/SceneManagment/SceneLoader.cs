using System.Collections;
using UnityEditor.Build.Reporting;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace.SceneManagment
{

        public class SceneLoader : MonoBehaviour
        {
            [SerializeField] private GameObject _loadingScreen;

            public void LoadMetaScene(SceneEntryParams enterParams = null) {
                StartCoroutine(LoadAndStartMeta(enterParams));
            }

            public void LoadGameplayScene(SceneEntryParams enterParams = null) {
                StartCoroutine(LoadAndStartGameplay(enterParams));
            }

            private IEnumerator LoadAndStartMeta(SceneEntryParams enterParams = null) {
                _loadingScreen.SetActive(true);

                yield return LoadScene(Scenes.Loader);
                yield return LoadScene(Scenes.MetaScene);
                
                var sceneEntryPoint = FindFirstObjectByType<SceneManagment.EntryPoint>();
                sceneEntryPoint.Run(enterParams);
                
                _loadingScreen.SetActive(false);
            }

            private IEnumerator LoadAndStartGameplay(SceneEntryParams enterParams) {
                _loadingScreen.SetActive(true);

                yield return LoadScene(Scenes.Loader);
                yield return LoadScene(Scenes.LevelScene);

                var sceneEntryPoint = FindFirstObjectByType<SceneManagment.EntryPoint>();
                sceneEntryPoint.Run(enterParams);

                _loadingScreen.SetActive(false);
            }

            private IEnumerator LoadScene(string sceneName) {
                yield return SceneManager.LoadSceneAsync(sceneName);
            }
        }
}