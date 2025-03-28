﻿using UnityEngine;

namespace SceneManagment
{
    public class MainEntryPoints : MonoBehaviour
    {
        private const string SCENE_LOADER_TAG = "SceneLoader";

        public void Awake() {
            if (GameObject.FindGameObjectWithTag(SCENE_LOADER_TAG)) return;
            
            var sceneLoaderPrefab = Resources.Load<SceneLoader>(SCENE_LOADER_TAG);
            var sceneLoader = Instantiate(sceneLoaderPrefab);
            DontDestroyOnLoad(sceneLoader);

            sceneLoader.LoadMetaScene();
        }
    }
}