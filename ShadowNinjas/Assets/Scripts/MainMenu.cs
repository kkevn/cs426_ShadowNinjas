using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject main;
    public GameObject controls;
    public GameObject controls1;
    public GameObject controls2;
    public GameObject controls3;
    public GameObject cutscene;


    public void StartGame() {
        main.SetActive(false);
        controls.SetActive(false);
        cutscene.SetActive(true);
        //SceneManager.LoadScene("Level_0");
    }

    public void ShowControls() {
        controls3.SetActive(false);
        controls.SetActive(true);
    }

    public void ShowMovement() {
        main.SetActive(false);
        controls1.SetActive(true);
    }

    public void ShowAiming() {
        controls1.SetActive(false);
        controls2.SetActive(true);
    }

    public void ShowLives() {
        controls2.SetActive(false);
        controls3.SetActive(true);
    }

    public void LeaveControls() {
        main.SetActive(true);
        controls.SetActive(false);
        controls1.SetActive(false);
        controls2.SetActive(false);
        controls3.SetActive(false);
    }

    public void ExitGame() {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
