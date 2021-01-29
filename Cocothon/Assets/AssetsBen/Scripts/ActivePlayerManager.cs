using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayerManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject timmy;
    public GameObject karen;
    public GameObject cam;

    private Vector3 camOffset;

    void Start()
    {

        if (timmy.gameObject.GetComponent<PlayerMovement>().isActive)
            camOffset = cam.transform.position - timmy.transform.position;
        else
            camOffset = cam.transform.position - karen.transform.position;

        timmy = GameObject.Find("Timmy");
        karen = GameObject.Find("Karen");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            timmy.gameObject.GetComponent<PlayerMovement>().isActive = true;
            karen.gameObject.GetComponent<PlayerMovement>().isActive = false;
        }
        else {
            timmy.gameObject.GetComponent<PlayerMovement>().isActive = false;
            karen.gameObject.GetComponent<PlayerMovement>().isActive = true;
        }
        //if (timmy.gameObject.GetComponent<PlayerMovement>().isActive)
            //cam.transform.position = timmy.transform.position + camOffset;
        //else
            cam.transform.position = karen.transform.position + camOffset;
    }
}
