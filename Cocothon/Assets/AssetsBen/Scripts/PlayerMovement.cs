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
    public Animator animator;

    public MotherAttack hittingObj;

    private GameObject timmy;
    private GameObject karen;

    private Vector3 direction;
    private Rigidbody rb;

    private bool cantAttack;
    private float attackCooldown;
    
    // Start is called before the first frame update
    void Start()
    {
        timmy = GameObject.Find("Timmy");
        karen = GameObject.Find("Karen");

        rb = this.GetComponent<Rigidbody>();

        cantAttack = false;
        attackCooldown = 0;
    }

    // Update is called once per frame
    void Update()
    {
        

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
        if (gameObject.name == "Karen")
        {

            if (Input.GetKeyDown(KeyCode.Space) && !cantAttack) {
                animator.SetTrigger("hit");
                hittingObj.Attack();
                cantAttack = true;
                attackCooldown = 0.50f;
            }
            if (Input.GetKeyDown(KeyCode.E) ) {
                hittingObj.DefendKid();
            }

            horizontalInput = Input.GetAxisRaw("Horizontal");
            verticalInput = Input.GetAxisRaw("Vertical");

            if (horizontalInput != 0 || verticalInput != 0)
            {
                animator.SetBool("isRunning", true);

                direction = (horizontalInput * Vector3.right + verticalInput * Vector3.forward).normalized;
                transform.LookAt(transform.position + direction);

                rb.MovePosition(transform.position + direction * Time.fixedDeltaTime * speed);
            }
            else {
                animator.SetBool("isRunning", false);
            }





        }

        else if (gameObject.name == "Timmy")
        {

            //Control timmy
            if (Input.GetKey(KeyCode.Mouse1)) {
                Camera cam = Camera.main;

                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if(Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask("Terrain"))) {

                    Vector3 destination = new Vector3(hit.point.x, timmy.transform.position.y, hit.point.z);

                    timmy.transform.LookAt(destination);
                    rb.velocity =  (destination - transform.position).normalized * speed;

                }

                if (rb.velocity.x != 0 || rb.velocity.z != 0) {
                    animator.SetBool("isRunning", true);
                }
                else {
                    animator.SetBool("isRunning", false);
                }




            }
            else {
                //Timmy control itself
                if ((karen.transform.position - transform.position).magnitude > 3) {

                    animator.SetBool("isRunning", true);
                    
                    

                    Vector3 diff = karen.transform.position - transform.position;
                    //ignore y diff
                    diff.y = 0;
                    diff.Normalize();

                    transform.LookAt(transform.position + diff);

                    if ((karen.transform.position - transform.position).magnitude > 4.5f)
                        rb.velocity = diff * speed;
                    else
                        rb.velocity = diff * karen.GetComponent<PlayerMovement>().speed;
                }
                else {
                    animator.SetBool("isRunning", false);
                }
            }

            
        }

        //limit of map -> should be walls
        /*if (transform.position.x < -xRange) {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange) {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -zRange) {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        if (transform.position.z > zRange) {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }*/
    }


}
