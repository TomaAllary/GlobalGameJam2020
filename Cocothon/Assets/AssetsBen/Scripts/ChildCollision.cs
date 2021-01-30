using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollision : MonoBehaviour
{

    public int eggsInStock;
    public Transform eggsLabel;
    public GameObject egg;

    public GameObject starsFX;

    private float xDropRange;
    private float zDropRange;


    public bool stunt;
    private float stuntTimer;

    // Start is called before the first frame update
    void Start()
    {

        eggsInStock = 0;
        xDropRange = 1f;
        zDropRange = 1f;
        stunt = false;
        stuntTimer = 3;
    }

    // Update is called once per frame
    void Update()
    {
        eggsLabel.rotation = Quaternion.Euler(0.0f, gameObject.transform.rotation.z * -1.0f, 0.0f);

        starsFX.SetActive(true);
        starsFX.transform.Rotate(0, Time.deltaTime * 3, 0, Space.World);

        if (stunt)
        {

            if (stuntTimer > 0)
                stuntTimer -= Time.deltaTime;
            else
            {
                stuntTimer = 0;
                stunt = false;
            }
        }
            
    }

    private void OnTriggerEnter(Collider other)
    {
       /* if (other.CompareTag("Egg"))
        {
            eggsInStock++;
            eggsLabel.GetComponent<TextMesh>().text = eggsInStock.ToString();
            Destroy(other.gameObject);
        }*/
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetInstanceID() == gameObject.GetComponent<ChildMovement>().parent.GetInstanceID())
            gameObject.GetComponent<ChildMovement>().returningToParent = false;

        if (collision.gameObject.CompareTag("Egg"))
        {
            if (collision.gameObject.GetComponent<EggCollectable>().isPickable()) {
                eggsInStock++;
                eggsLabel.GetComponent<TextMesh>().text = eggsInStock.ToString();
                Destroy(collision.gameObject);
            }
        }
    }

    public void TakeDamage()
    {
        if (!stunt)
        {
            print("ayoye tbk!!");
            if (eggsInStock < 3)
            {
                DropEggs(eggsInStock);
                eggsInStock = 0;
            }
            else
            {
                eggsInStock -= 3;
                DropEggs(3);
            }

            eggsLabel.GetComponent<TextMesh>().text = eggsInStock.ToString();
            stunt = true;
            stuntTimer = 3;
        }
    }

    private void DropEggs(int nb) {
        for (int i = 0; i < nb; i++) {
            float x = Random.Range(-xDropRange, xDropRange);
            float z = Random.Range(-zDropRange, zDropRange);

            Vector3 spawnPos = new Vector3(x, 1.5f, z);
            GameObject egg1 = Instantiate(egg);
            egg1.transform.position = transform.position + spawnPos;

            Debug.Log("Egg spawned");

        }
    }

}
