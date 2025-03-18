using UnityEngine;

namespace DefaultNamespace.SceneManagment
{
    public class SceneManagment
    {
        public abstract class EntryPoint : MonoBehaviour
        {
            public abstract void Run(SceneEntryParams enterParams);
        }
    }
}