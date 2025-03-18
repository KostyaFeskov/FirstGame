using DefaultNamespace.SceneManagment;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Meta
{
    public class MetaEntryPoint : SceneManagment.SceneManagment.EntryPoint
    {
        [SerializeField] private Button _startLevelButton;

        private const string SCENE_LOADER_TAG = "SceneLoader";

        public override void Run(SceneEntryParams enterParams) {
            _startLevelButton.onClick.AddListener(StartLevel);
        }

        private void StartLevel() {
            var sceneLoader = GameObject.FindWithTag(SCENE_LOADER_TAG).GetComponent<SceneLoader>();
            sceneLoader.LoadGameplayScene();
        }
    }
}