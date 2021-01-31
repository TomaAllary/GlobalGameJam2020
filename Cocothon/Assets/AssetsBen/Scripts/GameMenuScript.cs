using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuScript : MonoBehaviour
{
    Button startButton;
    Button restartButton;
    Button quitButton;
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        if(Langue.LangueSelectionnee == "Francais")
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
