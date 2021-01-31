using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Langue
{
    private static string langueSelectionnee = "English";
    private static bool gameMenuOn = false;

    public static string LangueSelectionnee
    {
        get
        {
            return langueSelectionnee;
        }
        set
        {
            langueSelectionnee = value;
        }
    }

    public static bool GameMenuOn
    {
        get
        {
            return gameMenuOn;
        }
        set
        {
            GameMenuOn = value;
        }
    }

}
