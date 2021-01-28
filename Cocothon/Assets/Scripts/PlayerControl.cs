using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController controller;
    public Transform playerMesh;
    public Transform playerObject;
    public float speed = 12f;
    public Animator animator;
    public GravityApplier gravityApplier;


    public float jumpHeight = 3f;

    private Vector3 playerMeshOffset;


    // Start is called before the first frame update
    void Start()
    {
        playerMeshOffset = playerMesh.position - playerObject.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Trigger end of jump
        if (!gravityApplier.wasItGrounded() && gravityApplier.isGrounded()) {
            animator.SetTrigger("JumpFinished");
        }

        //Moving with controls
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z) * speed * Time.deltaTime;
        controller.Move(move);
        
        
        //Animator running parameter managing
        if (move.x != 0 && move.z != 0) {
            animator.SetBool("running", true);
            playerMesh.LookAt(playerMesh.position + move);
        }
        else {
            animator.SetBool("running", false);
            playerMesh.LookAt(playerMesh.position + playerObject.forward);
        }
        
        
        //Jumping with height factor
        if (Input.GetButtonDown("Jump") && gravityApplier.isGrounded()) {
            gravityApplier.velocity_y = Mathf.Sqrt(jumpHeight * -2 * GravityApplier.gravity);
            animator.SetTrigger("Jump");
        }

        playerMesh.position = playerObject.position + playerMeshOffset;




    }
}
