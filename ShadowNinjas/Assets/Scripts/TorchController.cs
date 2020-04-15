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
	
	public AudioSource source;
    public AudioSource burn;

    private ParticleSystem _CachedSystem;

    private Light[] lights;

    private SphereCollider sphere;

    private bool wasHit = false;
    public bool isExtinguished = false;

    // Start is called before the first frame update
    void Start() {

        // build list of light sources in the torch
        lights = this.gameObject.GetComponentsInChildren<Light>(true);
		
		// grab audio component
		//source = GetComponent<AudioSource>();
        //burn = GetComponent<AudioSource>();

        // grab detection collider
        sphere = GetComponent<SphereCollider>();
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
                if (light.range <= 0f) {
                    light.enabled = false;
                    wasHit = false;
                    isExtinguished = true;
                }
            }
        }
    }

    // When torch is lit and hitbox hit by object tagged "Weapon", destroy light source
    private void OnCollisionEnter(Collision other) {

        if (other.contacts[0].thisCollider.transform.gameObject.name.Contains("Hitbox") == true && other.gameObject.CompareTag("Weapon") && isExtinguished == false) {

            // flag as hit
            wasHit = true;

            // stop particle system
            system.Stop(true, ParticleSystemStopBehavior.StopEmitting);
			
			// play sound effect (extinguish sound)
			source.Play();

            burn.Stop();

            // disable detection collider
            sphere.enabled = false;
        }
    }
}
