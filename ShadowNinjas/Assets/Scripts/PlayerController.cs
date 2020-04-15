using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject ShurikenSpawn;
    public GameObject Shuriken;
    public Transform playerBody;
    public Transform groundCheck;
    public LayerMask ground;
    //public AudioSource sound;

    public float movementSpeed = 12f;
    public float throwForce = 2000f;
    public float rotationSpeed = 200f;
    public float groundDistance = 0.4f;
    public float jumpHeight = 3f;

    bool isGrounded;
    Rigidbody rb;
    Vector3 move;

    private Animator anim;
    //private Collision collision;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        //sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if player is touching ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, ground);

        move = Vector3.zero;
        move.z = Input.GetAxis("Vertical");
        anim.SetBool("Walk", false);

        //if(collision.collider.gameObject.tag == "Crate")
        //{
        //    sound.Play();
        //}

        // Gets the input of W and S
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            anim.SetBool("Walk", true);
        }

        // If player is touching ground and pressed space he will jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * Mathf.Sqrt(jumpHeight * -2f * Physics.gravity.y), ForceMode.VelocityChange);
			anim.Play("Standing Jump");
        }

        // rotate player on A and D keys
        if (Input.GetKey(KeyCode.D))
            playerBody.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.A))
            playerBody.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);

        // throw shuriken on mouse click
        if (Input.GetButtonDown("Fire1"))
        {
            // enable throw animation
            anim.SetTrigger("Throw");

            // spawn and throw shuriken
            GameObject thrownShuriken = GameObject.Instantiate(Shuriken, ShurikenSpawn.transform.position, ShurikenSpawn.transform.rotation) as GameObject;
            thrownShuriken.GetComponent<Rigidbody>().AddForce(thrownShuriken.transform.forward * throwForce);
        }
    }
    // For cleaner movement despite fps difference
    private void FixedUpdate()
    {
        transform.Translate(move * movementSpeed * Time.fixedDeltaTime);
    }
}
