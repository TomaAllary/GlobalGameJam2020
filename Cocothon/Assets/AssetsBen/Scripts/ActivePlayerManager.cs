using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayerManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject timmy;
    public GameObject karen;
    public GameObject cam;

    void Start()
    {
        timmy = GameObject.Find("Timmy");
        karen = GameObject.Find("Karen");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            timmy.gameObject.GetComponent<PlayerMovement>().activeToggle();
            karen.gameObject.GetComponent<PlayerMovement>().activeToggle();
        }
        if (timmy.gameObject.GetComponent<PlayerMovement>().isActive) 
            cam.transform.position = new Vector3(timmy.transform.position.x, timmy.transform.position.y + 17, timmy.transform.position.z-10);
        else
            cam.transform.position = new Vector3(karen.transform.position.x, karen.transform.position.y + 17, karen.transform.position.z-10);
    }
}
