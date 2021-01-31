using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherAttack : MonoBehaviour
{

    public float defendRange = 2.6f;
    public ParticleSystem defendVFX;
    public float screamForce = 5f;
    public Renderer handbagMat;


    private bool isAttacking;
    private float attackTimer;
  
    
    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
      
        attackTimer = 0;
   
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking) {
            handbagMat.material.color = Color.red;
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else
            {
                attackTimer = 0;
                isAttacking = false;  
            }
        }
        else 
        {
            handbagMat.material.color = new Color(173, 0, 156);
           
        }
    }

    void OnTriggerEnter(Collider collider) {
        if( collider.gameObject.CompareTag("Child") && isAttacking && !collider.gameObject.GetComponent<ChildCollision>().stunt) {
            collider.gameObject.GetComponent<ChildCollision>().TakeDamage();
        }
    }

    public void Attack() {
        isAttacking = true;
        attackTimer = 0.63f;
    }

    public void DefendKid() {

        defendVFX.Play();

        Collider[] ennemies = Physics.OverlapSphere(transform.position, defendRange, LayerMask.GetMask("Child") | LayerMask.GetMask("Mother"));

        foreach(Collider collider in ennemies) {
            Rigidbody rb = collider.attachedRigidbody;

            if (rb) {
                Vector3 defendForce = (screamForce / (rb.transform.position - transform.position).magnitude) * (rb.transform.position - transform.position);
                defendForce.y = 0;
                rb.AddForce(defendForce, ForceMode.Impulse);
            }
            if (collider.gameObject.CompareTag("Mother"))
                collider.gameObject.GetComponent<MotherMovement>().isScared();
        }
    }
}
