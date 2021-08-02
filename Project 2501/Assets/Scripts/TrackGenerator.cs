using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TrackGenerator : MonoBehaviour
{
    #region Variables
    [Header("Track Section Prefabs")]
    public GameObject firstSection;
    public GameObject[] trackSections;

    public Transform startLocation;
    public Transform nextLocation;

    public int maxSections;
    public int currentSections;

    private List<GameObject> spawnedSections = new List<GameObject>();
    #endregion

    #region Methods

    private void Start()
    {
        GenerateFirst();
    }

    private void Update()
    {
        if (spawnedSections.Count == maxSections)
        {
            RemoveSection();
        }    
    }

    private void GenerateFirst()
    {
        if (startLocation)
        {
            GameObject section = Instantiate(firstSection, startLocation.position, startLocation.rotation);
            spawnedSections.Add(section);
            nextLocation = section.GetComponentInChildren<Transform>().GetChild(1);
            currentSections++;

            GenerateSections();
        }
    }

    private void GenerateSections()
    {
        if (currentSections < maxSections)
        {
            int i = Random.Range(0, trackSections.Length);
            //Transform loc = 
            GameObject section = Instantiate(trackSections[i], nextLocation.position, nextLocation.rotation);

            AddSection(section);

            Invoke("GenerateSections", .1f);
        }
    }

    public void AddSection(GameObject section)
    {
        spawnedSections.Add(section);
        currentSections++;
    }

    public void RemoveSection()
    {
        spawnedSections.Remove(spawnedSections[0]);
        //Destroy(spawnedSections[0]);

        currentSections--;

        GenerateSections();
    }
    #endregion
}
