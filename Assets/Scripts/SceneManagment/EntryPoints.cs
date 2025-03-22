using UnityEngine;

namespace SceneManagment
{
        public abstract class EntryPoint : MonoBehaviour
        {
            public abstract void Run(SceneEntryParams enterParams);
        }
}