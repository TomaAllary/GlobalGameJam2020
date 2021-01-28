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

    public Transform groundCheck;
    public LayerMask Ground;
    public float distanceCheck = 0.4f;

    public float jumpHeight = 3f;

    private Vector3 playerMeshOffset;

    private Vector3 velocity;
    private float gravity = -20f;
    private bool isGrounded;

    //public GameObject player;

    //public float speed;

    // Start is called before the first frame update
    void Start()
    {
        playerMeshOffset = playerMesh.position - playerObject.position;
    }

    // Update is called once per frame
    void Update()
    {
        Transform groundHitBox = groundCheck.GetChild(0);

        bool wasGrounded = isGrounded;
        isGrounded = Physics.CheckBox(groundCheck.position, groundHitBox.localScale, groundHitBox.rotation, Ground);

        if (isGrounded)
            groundHitBox.GetComponent<MeshRenderer>().material.color = Color.green;
        else
            groundHitBox.GetComponent<MeshRenderer>().material.color = Color.red;

        if (!wasGrounded && isGrounded) {
            animator.SetTrigger("JumpFinished");
        }

        if(isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z) * speed * Time.deltaTime;

        controller.Move(move);


        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
            animator.SetTrigger("Jump");
        }

        //gravity without rigidbody
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        playerMesh.position = playerObject.position + playerMeshOffset;


        if (move.x != 0 && move.z != 0) {
            animator.SetBool("running", true);
            playerMesh.LookAt(playerMesh.position + move);
        }
        else {
            animator.SetBool("running", false);
            playerMesh.LookAt(playerMesh.position + playerObject.forward);
        }

    }
}
