using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMenuScript : MonoBehaviour
{
    public Button startButton;
    public Button restartButton;
    public Button quitButton;
    public GameObject menu;

    // Start is called before the first frame update
    void Start()
    {
        menu.SetActive(false);
        if (Langue.LangueSelectionnee == "Francais")
        {
            startButton.GetComponentInChildren<Text>().text = "Revenir";
            restartButton.GetComponentInChildren<Text>().text = "Recommencer";
            quitButton.GetComponentInChildren<Text>().text = "Quitter";

        }
        else
        {
            startButton.GetComponentInChildren<Text>().text = "Resume";
            restartButton.GetComponentInChildren<Text>().text = "Restart";
            quitButton.GetComponentInChildren<Text>().text = "Quit";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void resumeGame()
    {
        menu.SetActive(false);
    }

    public void quitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }
}
