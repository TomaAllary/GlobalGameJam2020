using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Langue
{
    private static string langueSelectionnee = "English";

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


}
