﻿using Meta.Locations;
using SceneManagment;
using UnityEngine;

namespace Meta
{
    public class MetaEntryPoint : EntryPoint
    {
        [SerializeField] private LocationManager _locationManager;

        private const string SCENE_LOADER_TAG = "SceneLoader";

        public override void Run(SceneEntryParams enterParams) {
            _locationManager.Initialize(1, StartLevel);
        }

        private void StartLevel(int location, int level) {
            var sceneLoader = GameObject.FindWithTag(SCENE_LOADER_TAG).GetComponent<SceneLoader>();
            sceneLoader.LoadGameplayScene(new GameEnterParams(location, level));
            
        }
    }
}