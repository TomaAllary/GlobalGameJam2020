using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float horizontalInput;
    public float verticalInput;
    public float speed = 20.00f;
    public float xRange = 100.00f;
    public float zRange = 100.00f;

    public bool isActive;
    public bool timmyReadyForLaunch;

    private GameObject timmy;
    private GameObject karen;
    private Camera cam;

    private Vector3 direction;
    private Rigidbody rb;

    
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        timmy = GameObject.Find("Timmy");
        karen = GameObject.Find("Karen");
        rb = this.GetComponent<Rigidbody>();

        timmyReadyForLaunch = true;
    }

    // Update is called once per frame
    void Update()
    {

        if((timmy.transform.position - karen.transform.position).magnitude < 6) {
            timmyReadyForLaunch = true;
        }
        else {
            timmyReadyForLaunch = false;
        }


        

    }

    private void FixedUpdate()
    {
        if (isActive)
        {

            Vector3 oldPos = transform.position;

            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

            if (horizontalInput != 0 || verticalInput != 0)
            {
                direction = (horizontalInput * Vector3.right + verticalInput * Vector3.forward).normalized;
                transform.LookAt(transform.position + direction);


                //Bound timmy to camera view range
                bool TimmyCanGo = true;
                if (gameObject.name == "Timmy")
                {
                    Vector3 viewPos = cam.WorldToViewportPoint(transform.position + direction * Time.fixedDeltaTime * speed);

                    if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
                    {
                        TimmyCanGo = false;
                    }

                }
                if (TimmyCanGo)
                    rb.MovePosition(transform.position + direction * Time.fixedDeltaTime * speed);
            }




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

        else if (gameObject.name == "Timmy" && ((karen.transform.position - transform.position).magnitude > 5))
        {
            Vector3 diff = karen.transform.position - transform.position;
            //ignore y diff
            diff.y = 0;
            diff.Normalize();

            transform.LookAt(transform.position + diff);
            rb.MovePosition(transform.position + diff * Time.fixedDeltaTime * speed);
        }
    }
    public void activeToggle()
    {
        isActive = !isActive;
    }
}
