using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class winTrigger : MonoBehaviour {
    public GameObject levelCompleteMsg;
    public AudioSource gong;
    public Text scoreText;
    public Text savingText;
    public Button mainMenu;
    public Button nextLevel;
    public PlayerStats playerStats;
    private bool gameDone = false;
    private int score;
    private int tmp;
    private int growthRate = 50;

    // Trigger a win if the player enters the region
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            levelCompleteMsg.SetActive(true);
            gong.Play();
            StartCoroutine(Close(2)); 
        }
    }

    public IEnumerator Close(float x) {
        yield return new WaitForSeconds(x);
        gameDone = true;
    }

    void Start()
    {
        mainMenu.onClick.AddListener(menu);
        nextLevel.onClick.AddListener(next);
    }

    void Update()
    {
        if(gameDone)
        {
            scoreText.text = "Score: " + score.ToString("0");

            if(score != (1000 * (SavedInfo.life+SavedInfo.shuriken)) && (1000 * (SavedInfo.life + SavedInfo.shuriken)) > score)
            {
                score += growthRate;
                tmp = score;
            }

            if(tmp == (1000 * (SavedInfo.life + SavedInfo.shuriken)))
            {
                tmp++;
                savingText.gameObject.SetActive(true);
                SaveSystem.SavePlayer(playerStats);
            }
        }
    }

    void menu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    void next()
    {
        SceneManager.LoadScene("Level_1");
    }
}
