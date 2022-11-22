using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float speed = 20.0f;
    private float turnSpeed = 50.0f;
    private float horizontalInput;
    private float borderRange = 7.0f;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
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

       transform.Translate(Vector3.forward * Time.deltaTime * speed);
       transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
    }
}
