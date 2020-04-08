using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loseTrigger : MonoBehaviour
{
    public GameObject levelLoseMsg;

    // Trigger a win if the player enters the region
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            levelLoseMsg.SetActive(true);
            StartCoroutine(Close(3));
        }
    }

    public IEnumerator Close(float x)
    {
        yield return new WaitForSeconds(x);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        levelLoseMsg.SetActive(false);
        //Application.Quit();
    }
}
