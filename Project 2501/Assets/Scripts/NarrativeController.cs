using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeController : MonoBehaviour
{
    #region Variables

    public List<string> allegiantNarrations = new List<string>();
    public List<string> divergentNarrations = new List<string>();
    public List<string> insurgentNarrations = new List<string>();
    #endregion

    #region Built In Methods
    private void Start()
    {
        InitialiseNarrations();
    }

    #endregion

    #region Custom Methods
    public void PrintNarration(string path, int level)
    {
        switch (path)
        {
            case "allegiant":
                Debug.Log(allegiantNarrations[level].ToString());
                break;
            case "divergent":
                Debug.Log(divergentNarrations[level].ToString());
                break;
            case "insurgent":
                Debug.Log(insurgentNarrations[level].ToString());
                break;
            default:
                break;
        }
    }

    private void InitialiseNarrations()
    {
        allegiantNarrations.Add("one");
        allegiantNarrations.Add("two");
        allegiantNarrations.Add("three");
        allegiantNarrations.Add("four");
        allegiantNarrations.Add("five");
        allegiantNarrations.Add("six");
        allegiantNarrations.Add("seven");
        allegiantNarrations.Add("eight");
        allegiantNarrations.Add("nine");
        allegiantNarrations.Add("ten");

        divergentNarrations.Add("one");
        divergentNarrations.Add("two");
        divergentNarrations.Add("three");
        divergentNarrations.Add("four");
        divergentNarrations.Add("five");
        divergentNarrations.Add("six");
        divergentNarrations.Add("seven");
        divergentNarrations.Add("eight");
        divergentNarrations.Add("nine");
        divergentNarrations.Add("ten");

        insurgentNarrations.Add("one");
        insurgentNarrations.Add("two");
        insurgentNarrations.Add("three");
        insurgentNarrations.Add("four");
        insurgentNarrations.Add("five");
        insurgentNarrations.Add("six");
        insurgentNarrations.Add("seven");
        insurgentNarrations.Add("eight");
        insurgentNarrations.Add("nine");
        insurgentNarrations.Add("ten");
    }
    #endregion
}