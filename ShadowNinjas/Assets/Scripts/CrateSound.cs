using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateSound : MonoBehaviour
{
    public AudioSource sound;
    public new Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rigidbody.IsSleeping())
        {
            sound.Play();
        }
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            sound.Play();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.tag == "Player")
        {
            sound.Stop();
        }
    }*/
}
