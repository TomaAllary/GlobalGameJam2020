using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Apply Gravity on any CharacterController
/// </summary>
public class GravityApplier : MonoBehaviour
{
    public static float gravity = -20f;

    public CharacterController controller;
    public Transform groundCheck;
    public LayerMask Ground;


    public float velocity_y;
    private bool grounded;
    private bool wasGrounded;


    // Update is called once per frame
    void Update()
    {
        Transform groundHitBox = groundCheck.GetChild(0);

        bool wasGrounded = grounded;
        grounded = Physics.CheckBox(groundCheck.position, groundHitBox.localScale, groundHitBox.rotation, Ground);

        if (grounded)
            groundHitBox.GetComponent<MeshRenderer>().material.color = Color.green;
        else
            groundHitBox.GetComponent<MeshRenderer>().material.color = Color.red;

        //gravity without rigidbody
        velocity_y += gravity * Time.deltaTime;

        if (grounded && velocity_y < 0) {
            velocity_y = -2f;
        }

        controller.Move(Vector3.up * velocity_y * Time.deltaTime);

    }

    public bool isGrounded() {
        return grounded;
    }

    public bool wasItGrounded() {
        return wasGrounded;
    }
}
