using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayTuto : MonoBehaviour
{
    public Text textFr;
    public Text textEn; 
    public Text textRetour;
    public Text textBack;
    // Start is called before the first frame update
    void Start()
    {
        if(Langue.LangueSelectionnee == "Francais")
        {
            textFr.gameObject.SetActive(true);
            textEn.gameObject.SetActive(false);
            textRetour.gameObject.SetActive(true);
            textBack.gameObject.SetActive(false);
        }
        else
        {
            textFr.gameObject.SetActive(false);
            textEn.gameObject.SetActive(true);
            textRetour.gameObject.SetActive(false);
            textBack.gameObject.SetActive(true);
        }
    }

    public void backClick()
    {
        SceneManager.LoadScene(0);
    }
}
