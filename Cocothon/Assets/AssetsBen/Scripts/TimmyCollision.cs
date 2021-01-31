using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class TimmyCollision : MonoBehaviour {


    public TextMeshProUGUI scoreText;
    public int eggsInStock;

    public GameObject starsFX;

    private float xDropRange;
    private float zDropRange;

    public bool stunt;
    private float stuntTimer;

    public GameObject egg;

    // Start is called before the first frame update
    void Start() {
        eggsInStock = 0;
        stunt = false;
        stuntTimer = 0;
        xDropRange = 1f;
        zDropRange = 1f;
    }

    // Update is called once per frame
    void Update() {
        starsFX.SetActive(stunt);

        if (stunt) {
            starsFX.transform.Rotate(0, Time.deltaTime * 350, 0, Space.Self);

            if (stuntTimer > 0)
                stuntTimer -= Time.deltaTime;
            else {
                stuntTimer = 0;
                stunt = false;
            }
        }
    }

    /* private void OnTriggerEnter(Collider other)
     {
         if (other.CompareTag("Egg"))
         {

             eggsInStock++;
             scoreText.text = "Oeufs: " + eggsInStock;
             Destroy(other.gameObject);
         }
     }*/

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Egg")) {
            if (collision.gameObject.GetComponent<EggCollectable>().isPickable()) {
                eggsInStock++;
                scoreText.text = "Oeufs: " + eggsInStock;
                Destroy(collision.gameObject);
            }
        }
    }

    public void TakeDamage() {
        if (!stunt) {
            if (eggsInStock < 3) {
                DropEggs(eggsInStock);
                eggsInStock = 0;
            }
            else {
                eggsInStock -= 3;
                DropEggs(3);
            }


            stunt = true;
            stuntTimer = 3;
        }
    }

    private void DropEggs(int nb) {
        for (int i = 0; i < nb; i++) {
            float x = Random.Range(-xDropRange, xDropRange);
            float z = Random.Range(-zDropRange, zDropRange);

            Vector3 spawnPos = new Vector3(x, 40, z);
            GameObject egg1 = Instantiate(egg);
            egg1.transform.position = transform.position + spawnPos;
        }
    }
}
