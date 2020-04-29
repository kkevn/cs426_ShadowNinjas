using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject main;
    public GameObject controls;
    public GameObject movement;
    public GameObject aiming;
    public GameObject lives;
    public GameObject ammo;
    public GameObject goal;
    public GameObject cutscene;


    public void StartGame() {
        main.SetActive(false);
        controls.SetActive(false);
        cutscene.SetActive(true);
        //SceneManager.LoadScene("Level_0");
    }

    public void ShowControls() {
        goal.SetActive(false);
        controls.SetActive(true);
    }

    public void ShowMovement() {
        main.SetActive(false);
        movement.SetActive(true);
    }

    public void ShowAiming() {
        movement.SetActive(false);
        aiming.SetActive(true);
    }

    public void ShowAmmo() {
        aiming.SetActive(false);
        ammo.SetActive(true);
    }
    public void ShowLives() {
        ammo.SetActive(false);
        lives.SetActive(true);
    }

    public void ShowGoal() {
        lives.SetActive(false);
        goal.SetActive(true);
    }

    public void LeaveControls() {
        main.SetActive(true);
        controls.SetActive(false);
        movement.SetActive(false);
        aiming.SetActive(false);
        lives.SetActive(false);
        ammo.SetActive(false);
        goal.SetActive(false);
    }

    public void ExitGame() {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void GotoCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void LoadLevel()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        SceneManager.LoadScene(data.scene + 1);
    }
}
