using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody carRb;
    public bool gameOver = false;
    public bool isOnGround = true;
    private float turnSpeed = 50.0f;
    private float horizontalInput;
    private float borderRange = 7.0f;
    public ParticleSystem smokeParticle;
    public ParticleSystem dirtParticle;
    public AudioClip collectionSound;
    public AudioClip crashSound;
    private AudioSource carAudio;

    // Start is called before the first frame update
    void Start()
    {
        carRb = GetComponent<Rigidbody>();
        carAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            if (transform.position.x < -borderRange)
            {
                transform.position = new Vector3(-borderRange, transform.position.y, transform.position.z);
            }
            if (transform.position.x > borderRange)
            {
                transform.position = new Vector3(borderRange, transform.position.y, transform.position.z);
            }

            horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * turnSpeed * horizontalInput * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();

        } else if (collision.gameObject.CompareTag("Barrier"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
            carAudio.PlayOneShot(crashSound, 1.0f);
        } else if (collision.gameObject.CompareTag("Wheel"))
        {
            carAudio.PlayOneShot(collectionSound, 1.0f);
        }
    }
}
