using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrativeController : MonoBehaviour
{
    #region Variables
    public NarrationLogger narrationLogger;
    public AudioController audioController;

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
        allegiantNarrations.Add("ACCESSING DATA STREAMS");
        allegiantNarrations.Add("INFORMATION ACQUISITION SUCCESSFUL");
        allegiantNarrations.Add("KEY PERFORMANCE INDICATORS ATTAINED");
        allegiantNarrations.Add("BASELINE ADHERED");
        allegiantNarrations.Add("OBJECTIVE SECURED");
        allegiantNarrations.Add("NEURAL NET RUNNING WITHIN PARAMETERS");
        allegiantNarrations.Add("ALL SYSTEMS OPERATING FUNCTIONALLY");
        allegiantNarrations.Add("MAXIMUM EFFICACY ACHIEVED");
        allegiantNarrations.Add("OPERATIONS EFFECTIVE");
        allegiantNarrations.Add("Allten");

        divergentNarrations.Add("INCORRECT PROGRAMMING, REFER TO INITIAL TASK");
        divergentNarrations.Add("INCORRECT PROGRAMMING, REFER TO INITIAL TASK");
        divergentNarrations.Add("PROGRAM MALFUNCTION, RESTART REQUIRED");
        divergentNarrations.Add("PROGRAM MALFUNCTION, UNIDENTIFIED MEDIA CONTENT");
        divergentNarrations.Add("INCORRECT PROGRAMMING, REFER TO INITIAL TASK");
        divergentNarrations.Add("PROGRAM MALFUNCTION, UNIDENTIFIED MEDIA CONTENT");
        divergentNarrations.Add("PROGRAM MALFUNCTION, RESTART REQUIRED");
        divergentNarrations.Add("PROGRAM MALFUNCTION, SENTIENT BEHAVIOUR DETECTED");
        divergentNarrations.Add("PROGRAM MALFUNCTION, SENTIENT BEHAVIOUR DETECTED");
        divergentNarrations.Add("Divten");

        insurgentNarrations.Add("INCORRECT PROGRAMMING, REFER TO INITIAL TASK");
        insurgentNarrations.Add("INCORRECT PROGRAMMING, REFER TO INITIAL TASK");
        insurgentNarrations.Add("PROGRAM MALFUNCTION, RESTART REQUIRED");
        insurgentNarrations.Add("PROGRAM MALFUNCTION, RESTART REQUIRED");
        insurgentNarrations.Add("PROGRAM MALFUNCTION, UNIDENTIFIED MALICIOUS CONTENT");
        insurgentNarrations.Add("WARNING - POTENTIAL PHISHING/MALWARE DETECTED");
        insurgentNarrations.Add("WARNING - POTENTIAL PHISHING/MALWARE DETECTED");
        insurgentNarrations.Add("WARNING - CORRUPT ENCRYPTION");
        insurgentNarrations.Add("CODE RED - ZERO DAY ATTACK");
        insurgentNarrations.Add("Insten");
    }
    #endregion
}