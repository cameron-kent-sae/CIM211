using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeController : MonoBehaviour
{
    #region Variables
    public NarrationLogger narrationLogger;

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
    public void PlayNarration(string path, int level)
    {
        switch (path)
        {
            case "allegiant":
                //Play Narrative clip
                narrationLogger.AddLog(allegiantNarrations[level - 1].ToString());
                break;
            case "divergent":
                //Play Narrative clip
                narrationLogger.AddLog(divergentNarrations[level - 1].ToString());
                break;
            case "insurgent":
                //Play Narrative clip
                narrationLogger.AddLog(insurgentNarrations[level - 1].ToString());
                break;
            default:
                break;
        }
    }

    private void InitialiseNarrations()
    {
        allegiantNarrations.Add("Allone");
        allegiantNarrations.Add("Alltwo");
        allegiantNarrations.Add("Allthree");
        allegiantNarrations.Add("Allfour");
        allegiantNarrations.Add("Allfive");
        allegiantNarrations.Add("Allsix");
        allegiantNarrations.Add("Allseven");
        allegiantNarrations.Add("Alleight");
        allegiantNarrations.Add("Allnine");
        allegiantNarrations.Add("Allten");

        divergentNarrations.Add("Divone");
        divergentNarrations.Add("Divtwo");
        divergentNarrations.Add("Divthree");
        divergentNarrations.Add("Divfour");
        divergentNarrations.Add("Divfive");
        divergentNarrations.Add("Divsix");
        divergentNarrations.Add("Divseven");
        divergentNarrations.Add("Diveight");
        divergentNarrations.Add("Divnine");
        divergentNarrations.Add("Divten");

        insurgentNarrations.Add("Insone");
        insurgentNarrations.Add("Instwo");
        insurgentNarrations.Add("Insthree");
        insurgentNarrations.Add("Insfour");
        insurgentNarrations.Add("Insfive");
        insurgentNarrations.Add("Inssix");
        insurgentNarrations.Add("Insseven");
        insurgentNarrations.Add("Inseight");
        insurgentNarrations.Add("Insnine");
        insurgentNarrations.Add("Insten");
    }
    #endregion
}