using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherMovement : MonoBehaviour
{
    private float speed = 3.00f;
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

    public bool isAggressive;
    public int indecision;
    public float indecisionTimer;
    float aggroCooldownTimer;
    bool aggroOff;
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
        int aggro = Random.Range(0, 3);
        if (aggro == 1)
            isAggressive = true;
        else
            isAggressive = false;
        indecision = Random.Range(10, 45);
        indecisionTimer = indecision;
        aggroCooldownTimer = 0;
        aggroOff = false;
    }

    // Update is called once per frame
   
    
    
    void Update()
    {

        indecisionTimer -= Time.deltaTime;
        if(indecisionTimer <1 )
        {
            int aggro = Random.Range(0, 3);
            if (aggro == 1)
                isAggressive = true;
            else
                isAggressive = false;
            indecision = Random.Range(10, 45);
            indecisionTimer = indecision;
            aggroCooldownTimer = 0;
            aggroOff = false;
            isLocked = false;
        }
    }

    private void FixedUpdate()
    {


        transform.Translate(transform.forward * Time.deltaTime * speed);
        current++;

        if (!isLocked)
        {
            hitColliders = Physics.OverlapSphere(transform.position, 30);
            float distance = Mathf.Infinity;
            GameObject closest = null;

            if (isAggressive && !aggroOff)
            {

                if (hitColliders.Length != 0)
                {



                    foreach (var v in hitColliders)
                    {
                        if (v.gameObject.CompareTag("Timmy") && !v.gameObject.GetComponent<TimmyCollision>().stunt)
                        {
                            lockTarget(v.gameObject);
                            break;
                        }
                        else if (v.CompareTag("Child") && (v.gameObject.GetComponent<ChildMovement>().parent.GetInstanceID() != gameObject.GetInstanceID()) && !v.gameObject.GetComponent<ChildCollision>().stunt)
                        {
                            float currentDistance = (v.transform.position - transform.position).sqrMagnitude;
                            if (currentDistance < distance)
                            {
                                closest = v.gameObject;
                                distance = currentDistance;
                            }
                        }
                        if (closest != null)
                            lockTarget(closest);
                    }

                }
            }
            else
            {
                foreach (var v in hitColliders)
                {

                    if (v.CompareTag("Mother"))
                    {
                        float currentDistance = (v.transform.position - transform.position).sqrMagnitude;
                        if (currentDistance < distance)
                        {
                            closest = v.gameObject;
                            distance = currentDistance;
                        }
                    }
                    if (closest != null)
                        lockTarget(closest);
                }
            }
        }
        if (isLocked)
        {
            Vector3 diff = target.transform.position - transform.position;

            diff.y = 0;
            diff.Normalize();
            if (isAggressive)
            {
                transform.LookAt(transform.position + diff);
                rb.velocity = transform.forward * speed;
            }
            else
            {
                transform.LookAt(transform.position - diff);
                rb.velocity = transform.forward * speed;
            }

        }

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
                aggroOff = true;
                aggroCooldownTimer = 5;
            }
            if ((target.gameObject.CompareTag("Timmy") && target.gameObject.GetComponent<TimmyCollision>().stunt) || (target.gameObject.CompareTag("Child") && target.gameObject.GetComponent<ChildCollision>().stunt))
                isLocked = false;
        }

        if (aggroOff)
        {
            if (aggroCooldownTimer > 0)
                aggroCooldownTimer -= Time.deltaTime;
            else
            {
                aggroCooldownTimer = 0;
                aggroOff = false;
            }

        }
        
    }

    void lockTarget(GameObject obj)
    {
        isLocked = true;
        target = obj;
        lockingTimer = 15;
    }


    /***
     * 
     * Test to quickly implement mother attack on ennemies
     * 
     * **/
    private void OnCollisionEnter(Collision collision)
    {
        if (isAggressive && !aggroOff && collision.gameObject.GetInstanceID() == target.gameObject.GetInstanceID())
        {
            if (collision.gameObject.CompareTag("Child"))
                target.GetComponent<ChildCollision>().TakeDamage();
            else
                target.GetComponent<TimmyCollision>().TakeDamage();
        }
    }

    public void isScared()
    {
        lockingTimer = 0;
        isLocked = false;
        aggroOff = true;
        aggroCooldownTimer = 5;
    }
}
