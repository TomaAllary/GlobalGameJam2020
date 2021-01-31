using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class EndingScript : MonoBehaviour
{
    public Text textFr;
    public Text textEn;
    public Button boutonL;
    public AudioSource audio;
    public AudioClip audio2;
    // Start is called before the first frame update
    void Start()
    {
        audio.PlayOneShot(audio2);
        if(Langue.LangueSelectionnee == "Francais")
        {
            textFr.gameObject.SetActive(true);
            textEn.gameObject.SetActive(false);
            textFr.text = textFr.text + " " + Langue.EggsTotal + " oeufs!";
            boutonL.GetComponentInChildren<Text>().text = "Retour";

        }
        else
        {
            textFr.gameObject.SetActive(false);
            textEn.gameObject.SetActive(true);
            textEn.text = textEn.text + " " + Langue.EggsTotal + " eggs!";
            boutonL.GetComponentInChildren<Text>().text = "Return";
        }
    }

    public void retour()
    {
        SceneManager.LoadScene(0);
    }

}
