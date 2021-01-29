using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollision : MonoBehaviour
{

    public int eggsInStock;

    // Start is called before the first frame update
    void Start()
    {
        eggsInStock = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Egg"))
        {
            eggsInStock++;
            Destroy(other.gameObject);
        }
    }

}
