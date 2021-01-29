using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 400.00f;
    public float xRange = 100.00f;
    public float zRange = 100.00f;

    public bool isActive;

    private GameObject timmy;
    private GameObject karen;

    private Vector3 direction;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        timmy = GameObject.Find("Timmy");
        karen = GameObject.Find("Karen");
        rb = this.GetComponent<Rigidbody>();
      
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");


            //if (horizontalInput != 0 || verticalInput != 0) {
                direction = (horizontalInput * Vector3.right + verticalInput * Vector3.forward).normalized;
                transform.LookAt(transform.position + direction);

                //rb.MovePosition(transform.position + direction * Time.deltaTime * speed);
                rb.velocity = direction * Time.deltaTime * speed;
            //}


            //limit of map -> should be walls
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
                transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
            }

            if (transform.position.z > zRange)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
            }
        }

        //Make Karen follow Timmy
        else if(gameObject.name == "Karen" &&  ((timmy.transform.position - transform.position).magnitude > 10))
        {
            Vector3 diff = timmy.transform.position - transform.position;
            //ignore y diff
            diff.y = 0;
            diff.Normalize();

            transform.LookAt(transform.position + diff);
            //rb.MovePosition(transform.position + diff * Time.deltaTime * speed);
            rb.velocity = diff * Time.deltaTime * speed;
        }

        else if (gameObject.name == "Timmy" && ((karen.transform.position - transform.position).magnitude > 10))
        {
            Vector3 diff = karen.transform.position - transform.position;
            //ignore y diff
            diff.y = 0;
            diff.Normalize();

            transform.LookAt(transform.position + diff);
            //rb.MovePosition(transform.position + diff * Time.deltaTime * speed);
            rb.velocity = diff * Time.deltaTime * speed;

        }

    }

    public void activeToggle()
    {
        isActive = !isActive;
    }
}
