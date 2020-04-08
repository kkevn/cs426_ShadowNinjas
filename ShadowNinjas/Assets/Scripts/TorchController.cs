// particle source: https://docs.unity3d.com/ScriptReference/ParticleSystem.Stop.html

using UnityEngine;

public class TorchController : MonoBehaviour {

    ParticleSystem system {
        get {
            if (_CachedSystem == null)
                _CachedSystem = GetComponentInChildren<ParticleSystem>();
            return _CachedSystem;
        }
    }
	
	AudioSource source;

    private ParticleSystem _CachedSystem;

    private Light[] lights;

    private bool wasHit = false;
    private bool isExtinguished = false;

    // Start is called before the first frame update
    void Start() {

        // build list of light sources in the torch
        lights = this.gameObject.GetComponentsInChildren<Light>(true);
		
		// grab audio component
		source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {

        // if flagged as hit
        if (/*lights[0].enabled &&*/ wasHit) {

            foreach (Light light in lights) {

                // decrease angle and intensity of light
                light.spotAngle -= 0.05f;
                light.range -= 0.5f;
                light.intensity -= 0.05f;

                // disable lights
                if (light.spotAngle <= 0) {
                    light.enabled = false;
                    wasHit = false;
                    isExtinguished = true;
                }
            }
        }
    }

    // When lit and hit by object tagged "Weapon", destroy light source
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Weapon") && isExtinguished == false) {

            // flag as hit
            wasHit = true;

            // stop particle system
            system.Stop(true, ParticleSystemStopBehavior.StopEmitting);
			
			// play sound effect (extinguish sound)
			source.Play();
        }
    }
}
