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
        direction = Random.Range(0, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
        
        switch (direction)
        {
            case (0):
                transform.Translate(Vector3.right * 1 * Time.deltaTime * speed);
                current++;
                break;
            case (1):
                transform.Translate(Vector3.left * 1 * Time.deltaTime * speed);
                current++;
                break;
            case (2):
                transform.Translate(Vector3.forward * 1 * Time.deltaTime * speed);
                current++;
                break;
            case (3):
                transform.Translate(Vector3.back * 1 * Time.deltaTime * speed);
                current++;
                break;

        }
        if (current == paces)
        {
            current = 0;
            paces = Random.Range(150, 1000);
            direction = Random.Range(0, 4);
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
