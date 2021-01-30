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

    public bool returningToParent;
    public Rigidbody rb;
    public GameObject parent;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        paces = Random.Range(30, 150);
        direction = Random.Range(0, 360);
        transform.Rotate(new Vector3(0, direction, 0));
      
        parent = findClosestKaren();
        returningToParent = false;
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if ((parent.transform.position - transform.position).sqrMagnitude > 200)
            returningToParent = true;

        if (!returningToParent)
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

        else
        {
            Vector3 diff = parent.transform.position - transform.position;
            //ignore y diff
            diff.y = 0;
            diff.Normalize();

            transform.LookAt(transform.position + diff);
            rb.MovePosition(transform.position + diff * Time.fixedDeltaTime * speed);
        }
    }

    GameObject findClosestKaren()
    {
        GameObject[] allKarens = GameObject.FindGameObjectsWithTag("Mother");
        float distance = Mathf.Infinity;
        GameObject closestKaren = null;
        foreach(var k in allKarens)
        {
            float currentDistance = (k.transform.position - transform.position).sqrMagnitude;
            if(currentDistance < distance)
            {
                closestKaren = k;
                distance = currentDistance;
            }
        }

        return closestKaren;
    }

   
}
