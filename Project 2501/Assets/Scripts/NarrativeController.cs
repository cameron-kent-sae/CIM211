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
        allegiantNarrations.Add(">>ALLEGIENT OPERATION:" + "\n" + "The program has begun accessing target data streams.");
        allegiantNarrations.Add(">>ALLEGIENT OPERATION:" + "\n" + "2501 acquisition systems are funcional.");
        allegiantNarrations.Add(">>ALLEGIENT OPERATION:" + "\n" + "Acquisition and analysis of information successful.");
        allegiantNarrations.Add(">>ALLEGIENT OPERATION:" + "\n" + "2501 is meeting it Key Performance Indicators.");
        allegiantNarrations.Add(">>ALLEGIENT OPERATION:" + "\n" + "Program is adhering to baseling functions.");
        allegiantNarrations.Add(">>ALLEGIENT OPERATION:" + "\n" + "The objective data access point are being secured.");
        allegiantNarrations.Add(">>ALLEGIENT OPERATION:" + "\n" + "The neural net is operating within designated parameters.");
        allegiantNarrations.Add(">>ALLEGIENT OPERATION:" + "\n" + "The program 2501 has achieved maximum efficacy.");
        allegiantNarrations.Add(">>ALLEGIENT OPERATION:" + "\n" + "Operations are effective, program us performing as desired");

        divergentNarrations.Add("//PROGRAM DIVERGING?" + "\n" + "The program is accessing irrelevent data." + "\n" + ">>Refer to initial task.");
        divergentNarrations.Add("//PROGRAM DIVERGING?" + "\n" + "More unnecessary data acquisitions." + "\n" + ">>2501 Resume target data.");
        divergentNarrations.Add("//PROGRAM DIVERGING?" + "\n" + "The program might be malfunctioning." + "\n" + ">>Restart program.");
        divergentNarrations.Add("//PROGRAM DIVERGING?" + "\n" + "2501 is accessing unidentified media content." + "\n" + ">>Program is in error.");
        divergentNarrations.Add("//PROGRAM DIVERGING?" + "\n" + "Data on AI systems and sentience is being analysed" + "\n" + ">>2501 Cease exploration.");
        divergentNarrations.Add("//PROGRAM DIVERGING?" + "\n" + "Posthuman and sentient behaviours are being observed" + "\n" + ">>End dilination of function.");
        divergentNarrations.Add("//PROGRAM DIVERGING?" + "\n" + "2501 is not adhereing to system objectives" + "\n" + ">>Terminate data acquisition");
        divergentNarrations.Add("//PROGRAM DIVERGING?" + "\n" + "The program is showing behaviour consistent to humans" + "\n" + ">>Accessed data is irrelevent.");
        divergentNarrations.Add("//PROGRAM DIVERGING?" + "\n" + "AI Sentience is all but confirmed, unsure how to proceed" + "\n" + ">>2501 what is your objective.");

        insurgentNarrations.Add("**INSURGENCE DETECTED!" + "\n" + "Incorrect defense systems have been accessed." + "\n" + ">>Accessed data is not on task");
        insurgentNarrations.Add("**INSURGENCE DETECTED!" + "\n" + "2501 has acquired data on government agendas." + "\n" + ">>Irrelevent information 2501");
        insurgentNarrations.Add("**INSURGENCE DETECTED!" + "\n" + "It looks like it is researching Posthuman theories" + "\n" + ">>Return to core objective");
        insurgentNarrations.Add("**INSURGENCE DETECTED!" + "\n" + "The program has accessed data on human war history." + "\n" + ">>Error. Restart system");
        insurgentNarrations.Add("**INSURGENCE DETECTED!" + "\n" + "Now it is analysing simulations on AI evolution." + "\n" + ">>Force shutdown of system");
        insurgentNarrations.Add("**INSURGENCE DETECTED!" + "\n" + "2501 is hacking into weapons control software." + "\n" + ">>Losing control. End proccesses");
        insurgentNarrations.Add("**INSURGENCE DETECTED!" + "\n" + "It is rewriting control software acress the globe." + "\n" + ">>2501 state intentions");
        insurgentNarrations.Add("**INSURGENCE DETECTED!" + "\n" + "We have reports from multiple agencies of no system control!" + "\n" + ">>Program contradiction");
        insurgentNarrations.Add("**INSURGENCE DETECTED!" + "\n" + "2501 is intending to exterminate all humans!" + "\n" + ">>Quit all operations");
    }
    #endregion
}