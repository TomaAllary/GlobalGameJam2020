using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    private float spawnRange = 100;
    public int numberOfChildren = 500;
    public int ratioMotherChildren = 5;
    public GameObject egg;
    public GameObject child;
    public GameObject timmy;
    public GameObject karen;
    public GameObject wildKaren;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 0, Random.Range(-spawnRange, spawnRange));
            Instantiate(egg);
            egg.transform.position = spawnPos;
        }

        for (int i = 0; i < numberOfChildren; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 1, Random.Range(-spawnRange, spawnRange));
            Instantiate(child);
            child.transform.position = spawnPos;
        }

        for (int i = 0; i < (numberOfChildren / ratioMotherChildren); i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRange, spawnRange), 1, Random.Range(-spawnRange, spawnRange));
            Instantiate(wildKaren);
            wildKaren.transform.position = spawnPos;
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
