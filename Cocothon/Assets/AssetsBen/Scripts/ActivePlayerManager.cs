using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePlayerManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject timmy;
    public GameObject karen;
    public GameObject cam;

    private bool timmyLaunched;

    void Start()
    {
        timmyLaunched = false;

        timmy = GameObject.Find("Timmy");
        karen = GameObject.Find("Karen");


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && timmy.GetComponent<PlayerMovement>().timmyReadyForLaunch) {
            timmyLaunched = true;
        }

        if (Input.GetKeyUp(KeyCode.Mouse0)) {
            timmyLaunched = false;

        }

        if (Input.GetKey(KeyCode.Mouse0) && timmyLaunched)
        {
            timmy.gameObject.GetComponent<PlayerMovement>().isActive = true;
            karen.gameObject.GetComponent<PlayerMovement>().isActive = false;
        }
        else {
            timmy.gameObject.GetComponent<PlayerMovement>().isActive = false;
            karen.gameObject.GetComponent<PlayerMovement>().isActive = true;
        }
    }
}
