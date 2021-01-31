using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownHandler : MonoBehaviour
{
    private string langage;
    
    public Dropdown langDropdown;
    public GameObject StartButton;
    public GameObject StoryButton;
    // Start is called before the first frame update

    private void Start()
    {
        
        langage = langDropdown.options[langDropdown.value].text;
        StartButton = GameObject.Find("StartButton");
        StoryButton = GameObject.Find("StoryButton");
        if (langage == "Français")
        {
            StartButton.GetComponentInChildren<Text>().text = "Jouer";
            StoryButton.GetComponentInChildren<Text>().text = "Histoire";
        }
        else
        {
            StartButton.GetComponentInChildren<Text>().text = "Start";
            StoryButton.GetComponentInChildren<Text>().text = "Story";
        }
    }
    public void ChangeButtonText()
    {
        if (langage == "Français")
        {
            StartButton.GetComponentInChildren<Text>().text = "Jouer";
            StoryButton.GetComponentInChildren<Text>().text = "Histoire";
        }
        else
        {
            StartButton.GetComponentInChildren<Text>().text = "Start";
            StoryButton.GetComponentInChildren<Text>().text = "Story";
        }
    }

}
