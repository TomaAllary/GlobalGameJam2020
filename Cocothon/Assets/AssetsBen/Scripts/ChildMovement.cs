using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildMovement : MonoBehaviour
{
    private float speed = 5.00f;
    public float xRange = 100.00f;
    public float zRange = 100.00f;
    public int paces;
    private int current;
    private int direction;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        paces = Random.Range(30, 150);
        direction = Random.Range(0, 360);
        transform.Rotate(new Vector3(0, direction, 0));

    }

    // Update is called once per frame
    void Update()
    {
        
        transform.Translate(transform.forward * Time.deltaTime * speed);
        current++;


        if (current == paces)
        {
            current = 0;
            paces = Random.Range(150, 1000);
            direction = Random.Range(0, 360);

            transform.Rotate(new Vector3(0, direction, 0));
        }


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
