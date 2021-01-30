using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherMovement : MonoBehaviour
{
    private float speed = 5.00f;
    public float xRange = 100.00f;
    public float zRange = 100.00f;
    public int paces;
    private int current;
    private int direction;

    public GameObject[] children; 
    //public GameObject timmy; 

    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        paces = Random.Range(30, 150);
        direction = Random.Range(0, 360);
        transform.Rotate(new Vector3(0, direction, 0));
        rb = this.GetComponent<Rigidbody>();

        children = GameObject.FindGameObjectsWithTag("Child");
        //timmy = GameObject.FindGameObjectWithTag("Timmy");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed);
        current++;
        /*if ((transform.position - timmy.transform.position).magnitude < 50)
        {
            Vector3 diff = timmy.transform.position - transform.position;

            diff.y = 0;
            diff.Normalize();

            transform.LookAt(transform.position + diff);
            rb.MovePosition(transform.position + diff * Time.deltaTime * speed);
        }
        else
        {*/
            if (current == paces)
            {
                current = 0;
                paces = Random.Range(150, 1000);
                direction = Random.Range(0, 360);

                transform.Rotate(new Vector3(0, direction, 0));
            }
        //}

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
}
