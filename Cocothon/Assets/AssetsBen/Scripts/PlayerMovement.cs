using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 20.00f;
    public float xRange = 100.00f;
    public float zRange = 100.00f;

    public GameObject cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x,  transform.position.y, -zRange);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }

        cam.transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);
        cam.transform.Translate(Vector3.up * verticalInput * Time.deltaTime * speed);

        if (cam.transform.position.x < -xRange)
        {
            cam.transform.position = new Vector3(-xRange, 18, transform.position.z);
        }

        if (cam.transform.position.x > xRange)
        {
            cam.transform.position = new Vector3(xRange, 18, transform.position.z);
        }

        if (cam.transform.position.z < -zRange)
        {
            cam.transform.position = new Vector3(transform.position.x, 18, -zRange);
        }

        if (cam.transform.position.z > zRange)
        {
            cam.transform.position = new Vector3(transform.position.x, 18, zRange);
        }
    }
}
