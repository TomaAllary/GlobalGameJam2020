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
    public GameObject timmy; 

    private Rigidbody rb;

    public bool isLocked;
    public GameObject target;
    Collider[] hitColliders;

    private float lockingTimer;

    // Start is called before the first frame update
    void Start()
    {
        current = 0;
        paces = Random.Range(30, 150);
        direction = Random.Range(0, 360);
        transform.Rotate(new Vector3(0, direction, 0));
        rb = this.GetComponent<Rigidbody>();

        children = GameObject.FindGameObjectsWithTag("Child");
        timmy = GameObject.FindGameObjectWithTag("Timmy");
        target = null;
        lockingTimer = 0;
    }

    // Update is called once per frame
   
    
    
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        hitColliders = Physics.OverlapSphere(transform.position, 30);
        transform.Translate(transform.forward * Time.deltaTime * speed);
        current++;

        if (!isLocked)
        {
            if (hitColliders.Length != 0)
            {
                float distance = Mathf.Infinity;
                GameObject closestChild = null;

                foreach (var v in hitColliders)
                {
                    if (v.gameObject.CompareTag("Timmy")&& !v.gameObject.GetComponent<TimmyCollision>().stunt)
                    {
                        lockTarget(v.gameObject);
                        break;
                    }
                    else if (v.CompareTag("Child") && (v.gameObject.GetComponent<ChildMovement>().parent.GetInstanceID() != gameObject.GetInstanceID()) && !v.gameObject.GetComponent<ChildCollision>().stunt)
                    {
                        float currentDistance = (v.transform.position - transform.position).sqrMagnitude;
                        if (currentDistance < distance)
                        {
                            closestChild = v.gameObject;
                            distance = currentDistance;
                        }
                    }
                    if (closestChild != null)
                        lockTarget(closestChild);
                }
            }
        }
        if (isLocked)
        {
            Vector3 diff = target.transform.position - transform.position;

            diff.y = 0;
            diff.Normalize();

            transform.LookAt(transform.position + diff);
            rb.MovePosition(transform.position + diff * Time.deltaTime * speed);
        }
        //else if 
        else
        {
            if (current == paces)
            {
                current = 0;
                paces = Random.Range(150, 1000);
                direction = Random.Range(0, 360);

                transform.Rotate(new Vector3(0, direction, 0));
            }
        }

        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
            transform.Rotate(new Vector3(0, 180, 0));
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
            transform.Rotate(new Vector3(0, 180, 0));
        }

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
            transform.Rotate(new Vector3(0, 180, 0));
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
            transform.Rotate(new Vector3(0, 180, 0));
        }

        if (isLocked)
        {
            if (lockingTimer > 0)
            {
                lockingTimer -= Time.deltaTime;
            }
            else
            {
                lockingTimer = 0;
                isLocked = false;
            }
            if ((target.gameObject.CompareTag("Timmy") && target.gameObject.GetComponent<TimmyCollision>().stunt) || (target.gameObject.CompareTag("Child") && target.gameObject.GetComponent<ChildCollision>().stunt))
                isLocked = false;
        }
    }

    void lockTarget(GameObject obj)
    {
        isLocked = true;
        target = obj;
        lockingTimer = 5;
    }
}
