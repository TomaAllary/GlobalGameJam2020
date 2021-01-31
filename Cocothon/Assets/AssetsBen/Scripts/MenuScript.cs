using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{

    public AudioClip audioFr;
    public AudioClip audioEn;
    //public AudioSource audioSource;
    public AudioSource audioSource;
    public AudioSource audioSourceFond;
    private bool StoryIsRunning;

    public Button bouttonJouer; 
    public Button bouttonLang;
    public Button bouttonQuitter;
    public Button bouttonStory;
    private void Start()
    {
        Langue.LangueSelectionnee = "English";
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }
   public void PlayIntroFrench()
    {
        if (StoryIsRunning)
        {
            audioSource.Stop();
            StoryIsRunning = false;
            audioSourceFond.volume = 1;
        }
        else
        {
            audioSourceFond.volume = 0.3f;
            if (Langue.LangueSelectionnee == "Francais")
                audioSource.PlayOneShot(audioFr);
            else
                audioSource.PlayOneShot(audioEn);
            StoryIsRunning = true;
        }
    }

    public void LaunchTuto()
    {
        SceneManager.LoadScene(2);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }

    public void toggleLang()
    {
        if (Langue.LangueSelectionnee == "Francais")
        {
            Langue.LangueSelectionnee = "English";
            bouttonJouer.GetComponentInChildren<Text>().text = "Play";          
            bouttonLang.GetComponentInChildren<Text>().text = "FR";
            bouttonQuitter.GetComponentInChildren<Text>().text = "Quit";           
            bouttonStory.GetComponentInChildren<Text>().text = "Story";
        }
        else
        {
            Langue.LangueSelectionnee = "Francais";
            bouttonJouer.GetComponentInChildren<Text>().text = "Jouer";
            bouttonLang.GetComponentInChildren<Text>().text = "EN";
            bouttonQuitter.GetComponentInChildren<Text>().text = "Quitter";
            bouttonStory.GetComponentInChildren<Text>().text = "Histoire";
        }
            
    }

    public void LaunchCredits()
    {
        SceneManager.LoadScene(3);
    }
}
