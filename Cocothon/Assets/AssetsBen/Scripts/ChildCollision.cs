using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollision : MonoBehaviour
{

    public int eggsInStock;
    public Transform eggsLabel;

    // Start is called before the first frame update
    void Start()
    {
        eggsInStock = 0;
    }

    // Update is called once per frame
    void Update()
    {
        eggsLabel.rotation = Quaternion.Euler(0.0f, gameObject.transform.rotation.z * -1.0f, 0.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Egg"))
        {
            eggsInStock++;
            eggsLabel.GetComponent<TextMesh>().text = eggsInStock.ToString();
            Destroy(other.gameObject);
        }
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetInstanceID() == gameObject.GetComponent<ChildMovement>().parent.GetInstanceID())
            gameObject.GetComponent<ChildMovement>().returningToParent = false;
    }

    public void TakeDamage()
    {

    }

}
