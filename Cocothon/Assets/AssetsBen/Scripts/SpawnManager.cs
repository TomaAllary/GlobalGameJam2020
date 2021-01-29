using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private float spawnRange = 100;
    public GameObject egg;
    public GameObject child;
    public GameObject timmy;
    public GameObject karen;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10000; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));
            Instantiate(egg);
            egg.transform.position = spawnPos;
        }

        for (int i = 0; i < 500; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 1, Random.Range(-spawnRange, spawnRange));
            Instantiate(child);
            child.transform.position = spawnPos;
        }

      
        //Instantiate(karen);
        //karen.transform.position = new Vector3(3, 3, 3);

        timmy.gameObject.GetComponent<PlayerMovement>().isActive = true;
        karen.gameObject.GetComponent<PlayerMovement>().isActive = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
