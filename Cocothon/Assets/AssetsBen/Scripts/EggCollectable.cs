using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggCollectable : MonoBehaviour
{
    private bool canPickUp;
    private float timer;
    private float timeLimit;
    private bool throwed;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0.0f;
        timeLimit = 3.0f;
        canPickUp = throwed = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!canPickUp) {

            if (!throwed) {

                Vector3 throwEggVector = Vector3.up * 7f;
                gameObject.GetComponent<Rigidbody>().AddForce(throwEggVector, ForceMode.Impulse);
                gameObject.GetComponent<Rigidbody>().AddTorque(Random.Range(-1, 1), Random.Range(-1, 1), Random.Range(-1, 1));

                throwed = true;
            }


            timer += Time.deltaTime;
        }
        if(timeLimit < timer) {
            canPickUp = true;
        }
    }

    public bool isPickable() {
        return canPickUp;
    }
}
