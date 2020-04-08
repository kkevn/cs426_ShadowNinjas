using System.Collections;
using UnityEngine;

public class winTrigger : MonoBehaviour {
    public GameObject levelCompleteMsg;

    // Trigger a win if the player enters the region
    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            levelCompleteMsg.SetActive(true);
            StartCoroutine(Close(5));
        }
    }

    public IEnumerator Close(float x) {
        yield return new WaitForSeconds(x);
        Application.Quit();
    }
}
