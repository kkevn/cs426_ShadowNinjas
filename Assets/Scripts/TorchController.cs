using UnityEngine;

public class TorchController : MonoBehaviour {

    private Light[] lights;

    // Start is called before the first frame update
    void Start() {

        // build list of light sources in the torch
        lights = this.gameObject.GetComponentsInChildren<Light>(true);
    }

    // Update is called once per frame
    void Update() {
        
    }

    // When hit by object tagged "Weapon", remove light source from the torch
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Weapon")) {
            foreach (Light light in lights) {
                light.enabled = false;
            }
        }
    }
}
