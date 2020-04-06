using UnityEngine;

public class ShurikenController : MonoBehaviour {

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    // Remove when colliding
    private void OnCollisionEnter(Collision other) {
        Destroy(this.gameObject);
    }
}
