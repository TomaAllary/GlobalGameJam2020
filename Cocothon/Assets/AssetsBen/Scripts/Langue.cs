using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Langue
{
    private static string langueSelectionnee = "English";
    private static bool gameMenuOn = false;
    private static bool canShout = true;
    private static int eggsTotal = 0;

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
    public static bool CanShout
    {
        get
        {
            return canShout;
        }
        set
        {
            canShout = value;
        }
    }
    public static int EggsTotal
    {
        get
        {
            return eggsTotal;
        }
        set
        {
            eggsTotal = value;
        }
    }
}
