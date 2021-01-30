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

    public MotherAttack hittingObj;

    private GameObject timmy;
    private GameObject karen;
    private Camera cam;

    private Vector3 direction;
    private Rigidbody rb;

    private bool cantAttack;
    private float attackCooldown;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        timmy = GameObject.Find("Timmy");
        karen = GameObject.Find("Karen");

        rb = this.GetComponent<Rigidbody>();

        timmyReadyForLaunch = true;
        cantAttack = false;
        attackCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if((timmy.transform.position - karen.transform.position).magnitude < 2.5f) {
            timmyReadyForLaunch = true;
        }
        else {
            timmyReadyForLaunch = false;
        }
        if (cantAttack)
        {
            if (attackCooldown > 0)
                attackCooldown -= Time.deltaTime;
            else
            {
                attackCooldown = 0;
                cantAttack = false;
            }
        }

        

    }

    private void FixedUpdate()
    {
        if (isActive)
        {

            if (Input.GetKeyDown(KeyCode.Space) && gameObject.name == "Karen" && !cantAttack) {                         
                hittingObj.Attack();
                cantAttack = true;
                attackCooldown = 1.50f;
            }
            if (Input.GetKeyDown(KeyCode.E) && gameObject.name == "Karen") {
                hittingObj.DefendKid();
            }

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

        else if (gameObject.name == "Timmy")
        {

            if ((karen.transform.position - transform.position).magnitude > 2) {
                Vector3 diff = karen.transform.position - transform.position;
                //ignore y diff
                diff.y = 0;
                diff.Normalize();

                transform.LookAt(transform.position + diff);

                if ((karen.transform.position - transform.position).magnitude > 4)
                    rb.velocity = diff * speed;
                else
                    rb.velocity = diff * karen.GetComponent<PlayerMovement>().speed;
            }
        }
    }
    public void activeToggle()
    {
        isActive = !isActive;
    }


}
