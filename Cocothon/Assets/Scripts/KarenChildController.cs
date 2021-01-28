using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarenChildController : MonoBehaviour
{
    public Transform karen;
    public CharacterController controller;
    public Animator animator;

    public Transform groundCheck;
    public LayerMask Ground;

    public float speed = 12f;


    public float distanceCheck = 0.4f;

    private Vector3 playerMeshOffset;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = (transform.right * x + transform.forward * z) * speed * Time.deltaTime;

        controller.Move(move);
    }
}
