using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TrackGenerator : MonoBehaviour
{
    #region Variables
    private const float MAX_DIST = 200;

    [Header("Track Section Prefabs")]
    public GameObject[] trackSections;

    public CameraRunner cameraRunner;
    public int maxSections;

    private Transform spawnLocation;
    private int currentSections;
    private List<GameObject> spawnedSections = new List<GameObject>();
    #endregion

    #region Methods
    private void Awake()
    {
        spawnLocation = gameObject.transform;

        StartSpawning();
    }

    private void Update()
    {
        if (Vector3.Distance(cameraRunner.gameObject.transform.position, spawnLocation.transform.position) < MAX_DIST)
        {
            SpawnTrack();
        }

        if (currentSections == maxSections)
        {
            DestroySection();
        }
    }

    private void SpawnTrack()
    {
        int i = Random.Range(0, trackSections.Length);
        GameObject section = Instantiate(trackSections[i], spawnLocation.position, spawnLocation.rotation);
        spawnLocation = section.GetComponentInChildren<Transform>().GetChild(1);
        spawnedSections.Add(section);
        currentSections++;
    }

    private void StartSpawning()
    {
        while (currentSections < maxSections)
        {
            int i = Random.Range(0, trackSections.Length);
            GameObject section = Instantiate(trackSections[i], spawnLocation.position, spawnLocation.rotation);
            spawnLocation = section.GetComponentInChildren<Transform>().GetChild(1);
            spawnedSections.Add(section);
            currentSections++;
        }
    }

    private void DestroySection()
    {
        var obj = spawnedSections[0];
        spawnedSections.Remove(obj);
        Destroy(obj);

        currentSections--;
    }
    #endregion
}