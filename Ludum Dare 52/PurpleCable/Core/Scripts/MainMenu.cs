using Godot;

namespace PurpleCable
{
    public class MainMenu : Control
    {
        public override void _Ready()
        {   
            //SceneManager.sceneLoaded += SceneManager_sceneLoaded;
        }

        public void StartGame()
        {
            GoToScene("Main");
        }

        public void ShowCredits()
        {
            GoToScene("Credits");
        }

        public void ShowControls()
        {
            GoToScene("Controls");
        }

        public void ShowSettings()
        {
            GoToScene("Settings");
        }

        public void ShowOptions()
        {
            GoToScene("Options");
        }

        public void GoToMenu()
        {
            GoToScene("Menu");
        }

        public void QuitGame()
        {
            // TODO Godot QuitGame
        }

        public void GoToScene(string sceneName)
        {
            GetTree().ChangeScene(@"res://Scenes/" + sceneName + ".tscn");
        }

        //private void SceneManager_sceneLoaded(PackedScene arg0, LoadSceneMode arg1)
        //{
        //    FadeInOut.FadeIn();
        //}
    }
}
