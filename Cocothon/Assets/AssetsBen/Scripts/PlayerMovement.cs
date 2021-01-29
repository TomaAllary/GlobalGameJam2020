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
    public GameObject timmy;
    public GameObject karen;

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


            if (horizontalInput != 0 || verticalInput != 0) {
                direction = (horizontalInput * Vector3.right + verticalInput * Vector3.forward).normalized;
                transform.LookAt(transform.position + direction);


                //var oldPosition = transform.position;

                rb.MovePosition(transform.position + direction * Time.deltaTime * speed);
            }
      
            
             //This is for the active character rotation.. It kinda works, the character turns when you press left or right instead of straffing, but it's WAYYYY too sensitive..
            /*
            var newPosition = transform.position;
            var headingDirection = newPosition - oldPosition;
            Quaternion LookAtRotation = Quaternion.LookRotation(headingDirection);
            Quaternion LookAtRotationOnly_Y = Quaternion.Euler(transform.rotation.eulerAngles.x, LookAtRotation.eulerAngles.y, transform.rotation.eulerAngles.z);
            transform.rotation = LookAtRotationOnly_Y;
            */



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
            transform.position = Vector3.Lerp(transform.position, timmy.transform.position - new Vector3(10*(Math.Sign(transform.position.x - timmy.transform.position.x)),0,10 * (Math.Sign(transform.position.z - timmy.transform.position.z))), Time.deltaTime );
            transform.rotation = Quaternion.Lerp(transform.rotation, timmy.transform.rotation, Time.deltaTime*100);
        }

        else if (gameObject.name == "Timmy" && ((karen.transform.position - transform.position).magnitude > 10))
        {
            transform.position = Vector3.Lerp(transform.position, karen.transform.position - new Vector3(10 * (Math.Sign(transform.position.x - karen.transform.position.x)), 0, 10 * (Math.Sign(transform.position.z - karen.transform.position.z))), Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, karen.transform.rotation, Time.deltaTime*100);
        }

    }

    public void activeToggle()
    {
        isActive = !isActive;
    }
}
