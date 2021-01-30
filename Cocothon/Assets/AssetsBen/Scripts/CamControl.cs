using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    public Transform Karen;

    private float zoomSensitivity = 16f;
    private float minFov = 30f;
    private float maxFov = 100f;
    private Vector3 camOffset;


    // Start is called before the first frame update
    void Start()
    {
        Camera.main.transform.LookAt(Karen.position);

        camOffset = Camera.main.transform.position - Karen.transform.position;

    }

    // Update is called once per frame
    void Update()
    {



        float fov = Camera.main.fieldOfView;
        fov += Input.GetAxis("Mouse ScrollWheel") * -zoomSensitivity;
        fov = Mathf.Clamp(fov, minFov, maxFov);
        Camera.main.fieldOfView = fov;

        Camera.main.transform.position = Karen.transform.position + camOffset;

    }
}
