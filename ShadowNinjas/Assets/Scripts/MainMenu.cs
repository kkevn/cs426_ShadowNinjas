using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void StartGame() {
        SceneManager.LoadScene("Level_0");
    }

    public void ShowControls() {
        Debug.Log("Not yet implemented.");
        //todo
    }

    public void ExitGame() {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
