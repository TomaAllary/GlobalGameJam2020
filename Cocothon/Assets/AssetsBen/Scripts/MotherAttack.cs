using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MotherAttack : MonoBehaviour
{

    public float defendRange = 2.6f;
    public ParticleSystem defendVFX;
    public float screamForce = 5f;
    public Renderer handbagMat;


    private bool isAttacking;
    private float attackTimer;
    private float voiceTimer;
    private bool canVoice;

    public AudioSource karenSound;
    public AudioClip[] shoutFr;
    public AudioClip[] shoutEn;
    public AudioClip attaqueFr;
    public AudioClip attaqueEn;

    
    // Start is called before the first frame update
    void Start()
    {
        isAttacking = false;
      
        attackTimer = 0;
        voiceTimer = 0;
        canVoice = true;
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
        if(voiceTimer > 0)
        {
            voiceTimer -= Time.deltaTime;
        }
        else
        {
            voiceTimer = 0;
            canVoice = true;
        }
       
           
    }

    void OnTriggerEnter(Collider collider) {
        if( collider.gameObject.CompareTag("Child") && isAttacking && !collider.gameObject.GetComponent<ChildCollision>().stunt) {
            collider.gameObject.GetComponent<ChildCollision>().TakeDamage();
        }
    }

    public void Attack() {
        isAttacking = true;
        attackTimer = 1.0f;
        if (canVoice)
        {
            if (Langue.LangueSelectionnee == "Francais")
            {
                karenSound.PlayOneShot(attaqueFr);
                voiceTimer = 3;
                canVoice = false;
            }
            else
            {
                karenSound.PlayOneShot(attaqueEn);
                voiceTimer = 3;
                canVoice = false;
            }
        }
        

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
