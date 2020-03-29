using UnityEngine;

public class PlayerController : MonoBehaviour {

    float movementSpeed = 0.1f;
    float rotationSpeed = 200f;
    float jumpForce = 300f;
    float throwForce = 2000f;

    public GameObject ShurikenSpawn;
    public GameObject Shuriken;

    Rigidbody rb;
    Transform t;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update() {

        // throw shuriken on mouse click
        if (Input.GetButtonDown("Fire1")) {
            GameObject thrownShuriken = GameObject.Instantiate(Shuriken, ShurikenSpawn.transform.position, ShurikenSpawn.transform.rotation) as GameObject;
            thrownShuriken.GetComponent<Rigidbody>().AddForce(thrownShuriken.transform.forward * throwForce);
        }

        // get z direction movement
        var z = Input.GetAxis("Vertical") * movementSpeed;

        // rotate player on A and D keys
        if (Input.GetKey(KeyCode.D))
            t.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.A))
            t.rotation *= Quaternion.Euler(0, - rotationSpeed * Time.deltaTime, 0);

        // player can jump when hitting spacebar
        if (Input.GetKeyDown(KeyCode.Space)) {
            rb.AddForce(t.up * jumpForce);
        }

        // move in world space
        t.Translate(0, 0, z);
    }
}
