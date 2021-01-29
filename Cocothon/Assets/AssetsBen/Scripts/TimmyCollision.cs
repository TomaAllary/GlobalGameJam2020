using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TimmyCollision : MonoBehaviour
{

    
    public TextMeshProUGUI scoreText;
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
            scoreText.text = "Oeufs: " + eggsInStock;
            Destroy(other.gameObject);
        }
    }
}
