using UnityEngine;

public class Aura : MonoBehaviour {

    public AudioClip clip;

    private void OnTriggerEnter(Collider other) {

        // play sound at position when player picks up ammo
        if (other.gameObject.CompareTag("Player")) {
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }
    }
}
