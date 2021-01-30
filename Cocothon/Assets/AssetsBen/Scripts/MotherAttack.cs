using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherAttack : MonoBehaviour
{

    public float defendRange = 10.0f;
    private bool isAttacking;
    
    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking) {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
        else {
            gameObject.GetComponent<Renderer>().material.color = Color.white;

        }
    }

    void OnTriggerEnter(Collider collider) {
        if( collider.gameObject.CompareTag("Child") && isAttacking) {
            collider.gameObject.GetComponent<ChildCollision>().TakeDamage();
        }
    }

    public void Attack() {
        isAttacking = true;
    }

    public void DefendKid() {
        Collider[] ennemies = Physics.OverlapSphere(transform.position, defendRange, LayerMask.GetMask("Child") | LayerMask.GetMask("Mother"));

        foreach(Collider collider in ennemies) {
            Rigidbody rb = collider.attachedRigidbody;

            if (rb) {
                Vector3 defendForce = rb.transform.position - transform.position;
                defendForce.y = 0;
                rb.AddForce(defendForce, ForceMode.Impulse);
            }
        }
    }
}
