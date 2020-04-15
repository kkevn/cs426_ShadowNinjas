using UnityEngine;

public class Arrow : MonoBehaviour
{
    Rigidbody arrow;
    public float lifeTimer = 10f;
    public AudioSource burn;
    private float timer;
    private bool hit = false;

    // Start is called before the first frame update
    void Start()
    {
        arrow = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.LookRotation(arrow.velocity);
        burn.Play();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= lifeTimer)
        {
            Destroy(gameObject);
        }

        if(!hit)
        {
            transform.rotation = Quaternion.LookRotation(arrow.velocity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag != "Arrow")
        {
            hit = true;
            Stick();
        }
    }

    private void Stick()
    {
        arrow.constraints = RigidbodyConstraints.FreezeAll;
    }

    private void FixedUpdate()
    {
        transform.LookAt(transform.position + GetComponent<Rigidbody>().velocity);
    }
}
