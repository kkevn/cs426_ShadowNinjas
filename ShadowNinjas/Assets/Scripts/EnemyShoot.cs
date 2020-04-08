using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject arrow;
    public Transform arrowSpawner;
    public float shootForce = 20f;
    private float elapsed = 0f;
    private Vector3 force = new Vector3(0, 1, 10);
    private AudioSource audioS;

    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;

        if(elapsed >= Random.Range(1.5f, 6f))
        {
            GameObject shoot = Instantiate(arrow, arrowSpawner.position, Quaternion.identity);
            Rigidbody rb = shoot.GetComponent<Rigidbody>();
            rb.velocity = force * shootForce;
            audioS.Play();
            elapsed = 0f;
        }
    }
}
