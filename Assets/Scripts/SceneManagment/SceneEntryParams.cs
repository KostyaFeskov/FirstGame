namespace SceneManagment
{
    public abstract class SceneEntryParams
    {
        public string SceneName{ get; }

        public SceneEntryParams(string sceneName) {
            SceneName = sceneName;
        }
    }
}