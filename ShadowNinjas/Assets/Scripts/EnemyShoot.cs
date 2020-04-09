using System.Collections;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {
    public GameObject arrow;
    public Transform arrowSpawner;
    public float shootForce = 20f;
    public float maxTimeBetweenShots = 2.0f;
    private float elapsed = 0f;
    private Vector3 force = new Vector3(0, 1, 10);
    private AudioSource audioS;

    private Animator anim;

    // Start is called before the first frame update
    void Start() {
        audioS = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {
        elapsed += Time.deltaTime;
        
        // shoot every 5 (length of animation) to maxTimeBeweenShots seconds
        if (elapsed >= Random.Range(5.0f, 5.0f + maxTimeBetweenShots)) {
            anim.SetTrigger("Shoot");

            // arrow release in animation happens at 3.2seconds
            StartCoroutine(Shoot(3.2f));
            elapsed = 0f;
        }
    }

    // spawn and shoot the arrow after waiting x seconds
    public IEnumerator Shoot(float x) {
        yield return new WaitForSeconds(x);
        GameObject shoot = Instantiate(arrow, arrowSpawner.position, Quaternion.identity);
        Rigidbody rb = shoot.GetComponent<Rigidbody>();
        rb.velocity = force * shootForce;
        audioS.Play();
    }
}
