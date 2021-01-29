using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextIndicator : MonoBehaviour
{
    public Camera cam;
    public GameObject arrow3D;

    private GameObject timmy;
    private GameObject karen;
    private Vector3 viewportPos;
    private GameObject inactive;
    
    // Start is called before the first frame update
    void Start()
    {
        arrow3D.transform.LookAt(arrow3D.transform.position + cam.transform.forward.normalized);

        timmy = GameObject.Find("Timmy");
        karen = GameObject.Find("Karen");
    }

    // Update is called once per frame
    void Update()
    {
        /*GameObject active;
        if (karen.GetComponent<PlayerMovement>().isActive) {
            active = karen;
            inactive = timmy;
        }
        else {
            active = timmy;
            inactive = karen;
        }*/


        //look if the inactive character is in screen
        Vector3 viewPos = cam.WorldToViewportPoint(timmy.transform.position);
        if(viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1) {
            arrow3D.SetActive(true);

            //"this" is the container of the 3d text arrow
            this.transform.position = karen.transform.position;
            this.transform.LookAt(timmy.transform.position);
        }
        else {
            arrow3D.SetActive(false);

        }

    }
}
