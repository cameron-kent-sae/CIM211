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
                //Debug.Log(allegiantNarrations[level].ToString());
                break;
            case "divergent":
                //Debug.Log(divergentNarrations[level].ToString());
                break;
            case "insurgent":
                //Debug.Log(insurgentNarrations[level].ToString());
                break;
            default:
                break;
        }
    }

    private void InitialiseNarrations()
    {
        allegiantNarrations.Add("Aone");
        allegiantNarrations.Add("Atwo");
        allegiantNarrations.Add("Athree");
        allegiantNarrations.Add("Afour");
        allegiantNarrations.Add("Afive");
        allegiantNarrations.Add("Asix");
        allegiantNarrations.Add("Aseven");
        allegiantNarrations.Add("Aeight");
        allegiantNarrations.Add("Anine");
        allegiantNarrations.Add("Aten");

        divergentNarrations.Add("Done");
        divergentNarrations.Add("Dtwo");
        divergentNarrations.Add("Dthree");
        divergentNarrations.Add("Dfour");
        divergentNarrations.Add("Dfive");
        divergentNarrations.Add("Dsix");
        divergentNarrations.Add("Dseven");
        divergentNarrations.Add("Deight");
        divergentNarrations.Add("Dnine");
        divergentNarrations.Add("Dten");

        insurgentNarrations.Add("Ione");
        insurgentNarrations.Add("Itwo");
        insurgentNarrations.Add("Ithree");
        insurgentNarrations.Add("Ifour");
        insurgentNarrations.Add("Ifive");
        insurgentNarrations.Add("Isix");
        insurgentNarrations.Add("Iseven");
        insurgentNarrations.Add("Ieight");
        insurgentNarrations.Add("Inine");
        insurgentNarrations.Add("Iten");
    }
    #endregion
}