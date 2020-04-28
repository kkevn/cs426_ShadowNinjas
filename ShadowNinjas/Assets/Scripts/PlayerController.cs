using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public GameObject ShurikenSpawn;
    public GameObject Shuriken;
    public Transform playerBody;
    public Transform groundCheck;
    public LayerMask ground;
    public PlayerStats playerStats;
    //public AudioSource sound;

    public AudioSource throw1, throw2;

    public float movementSpeed = 12f;
    public float throwForce = 100f;
    public float rotationSpeed = 50f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 3f;

    bool isGrounded;
    Rigidbody rb;
    Vector3 move;

    private Animator anim;
    //private Collision collision;

    Ray ray;
    RaycastHit hit;
    bool canThrow = false;

    private float throwRange = 30f;

    private GameObject Target;
    private GameObject PreviousTarget;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if player is touching ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, ground);

        anim.SetBool("Walk", false);

        //if(collision.collider.gameObject.tag == "Crate")
        //{
        //    sound.Play();
        //}

        // rotate and move player in one of 4 directions based on input
        if (Input.GetKey(KeyCode.W)) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 180f, 0), rotationSpeed * Time.deltaTime);
            move.z = movementSpeed;
            transform.Translate(move * Input.GetAxis("Vertical") * Time.deltaTime);
            anim.SetBool("Walk", true);
        }
        else if (Input.GetKey(KeyCode.S)) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), rotationSpeed * Time.deltaTime);
            move.z = -movementSpeed;
            transform.Translate(move * Input.GetAxis("Vertical") * Time.deltaTime);
            anim.SetBool("Walk", true);
        }
        else if (Input.GetKey(KeyCode.A)) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 90f, 0), rotationSpeed * Time.deltaTime);
            move.z = -movementSpeed;
            transform.Translate(move * Input.GetAxis("Horizontal") * Time.deltaTime);
            anim.SetBool("Walk", true);
        }
        else if (Input.GetKey(KeyCode.D)) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -90f, 0), rotationSpeed * Time.deltaTime);
            move.z = movementSpeed;
            transform.Translate(move * Input.GetAxis("Horizontal") * Time.deltaTime);
            anim.SetBool("Walk", true);
        }

        // If player is touching ground and pressed space he will jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
			anim.Play("Standing Jump");
        }

        // throw shuriken on mouse click
        if (Input.GetButtonDown("Fire1") && canThrow == true && playerStats.shuriken > 0)
        {
            playerStats.UseShuriken();

            // enable throw animation
            anim.SetTrigger("Throw");

            // play a throw sound effect
            if (Random.Range(0, 2) == 0) {
                throw1.Play();
            }
            else {
                throw2.Play();
            }

            // spawn and throw shuriken at direction of current target
            GameObject thrownShuriken = GameObject.Instantiate(Shuriken, ShurikenSpawn.transform.position, ShurikenSpawn.transform.rotation) as GameObject;
            Vector3 directionToTarget = Target.transform.position - thrownShuriken.transform.position;
            thrownShuriken.GetComponent<Rigidbody>().AddForce(directionToTarget * throwForce);

            // remove ability to throw and remove lock on
            canThrow = false;
            Target.GetComponentInChildren<Canvas>().enabled = false;
        }

        // on right mouse click
        if (Input.GetMouseButtonDown(1)) {

            // get raycast to gameobject at mouse position
            ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
            if (Physics.Raycast(ray, out hit, throwRange)) {

                // if clicked object is tagged as a target and not already extinguished
                if (hit.collider.gameObject.tag == "Target" && hit.collider.gameObject.GetComponentInParent<TorchController>().isExtinguished == false) {

                    // remember previous target and get new one
                    if (Target != null)
                        PreviousTarget = Target;
                    Target = hit.collider.gameObject;

                    // enable ability to throw shuriken
                    canThrow = true;

                    // disable old target lock on and enable for new target
                    if (PreviousTarget != null)
                        PreviousTarget.GetComponentInChildren<Canvas>().enabled = false;
                    Target.GetComponentInChildren<Canvas>().enabled = true;
                }
            }
        }    
    }
}
