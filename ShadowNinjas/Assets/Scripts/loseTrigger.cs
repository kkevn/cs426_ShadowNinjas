using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class loseTrigger : MonoBehaviour {
    public GameObject levelLoseMsg;
	public AudioSource yamete;

    // Trigger a win if the player enters the region
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            levelLoseMsg.SetActive(true);
            StartCoroutine(Close(3));
        }
    }

    public IEnumerator Close(float x) {
		
		if(yamete != null) {
		yamete.Play();	
		}
		
		
        yield return new WaitForSeconds(x-1);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        levelLoseMsg.SetActive(false);
    }
}
