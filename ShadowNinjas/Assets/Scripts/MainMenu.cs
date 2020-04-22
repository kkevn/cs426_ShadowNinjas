using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject main;
    public GameObject controls;
    public GameObject cutscene;


    public void StartGame() {
        main.SetActive(false);
        controls.SetActive(false);
        cutscene.SetActive(true);
        //SceneManager.LoadScene("Level_0");
    }

    public void ShowControls() {
        main.SetActive(false);
        controls.SetActive(true);
    }

    public void LeaveControls() {
        main.SetActive(true);
        controls.SetActive(false);
    }

    public void ExitGame() {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
