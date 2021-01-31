using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{

    private Vector2 spawnRangeX = new Vector2(60, -1);
    private Vector2 spawnRangeZ = new Vector2(60, -5);
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
        for (int i = 0; i < 600; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(spawnRangeX.x, spawnRangeX.y), 40, Random.Range(spawnRangeZ.x, spawnRangeZ.y));
            Instantiate(egg);
            egg.transform.position = spawnPos;
        }

        for (int i = 0; i < numberOfChildren; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(spawnRangeX.x, spawnRangeX.y), 40, Random.Range(spawnRangeZ.x, spawnRangeZ.y));
            Instantiate(child);
            child.transform.position = spawnPos;
        }

        for (int i = 0; i < (numberOfChildren / ratioMotherChildren); i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(spawnRangeX.x, spawnRangeX.y), 40, Random.Range(spawnRangeZ.x, spawnRangeZ.y));
            Instantiate(wildKaren);
            wildKaren.transform.position = spawnPos;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
