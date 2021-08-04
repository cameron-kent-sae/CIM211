using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class TrackGenerator : MonoBehaviour
{
    #region Variables
    [Header("Track Section Prefabs")]
    public GameObject[] trackSections;

    public CameraRunner cameraRunner;
    public float sectionLength;
    public int maxSections;

    private Transform spawnLocation;
    private int currentSections;
    private float cameraRunSpeed;
    private float spawnTime;
    private bool spawning;
    private List<GameObject> spawnedSections = new List<GameObject>();
    #endregion

    #region Methods
    private void Start()
    {
        cameraRunSpeed = cameraRunner.speed;
        spawning = true;
        spawnLocation = gameObject.transform;
        StartCoroutine(GenerateTrack());
    }

    private IEnumerator GenerateTrack()
    {
        while (spawning)
        {
            int i = Random.Range(0, trackSections.Length);
            GameObject section = Instantiate(trackSections[i], spawnLocation.position, spawnLocation.rotation);
            spawnLocation = section.GetComponentInChildren<Transform>().GetChild(1);
            spawnedSections.Add(section);
            currentSections++;

            UpdateSpawnTime();

            if (currentSections == maxSections)
            {
                DestroySection();
            }

            yield return new WaitForSeconds(spawnTime);
        }
    }

    private void UpdateSpawnTime()
    {
        spawnTime = sectionLength / cameraRunSpeed;
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