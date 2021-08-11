using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterAISpawner : MonoBehaviour
{
    #region Variables
    public GameObject runningCamera;

    public GameObject[] counterAIObject;

    public float minXSpawnBound;
    public float maxXSpawnBound;
    public float minYSpawnBound;
    public float maxYSpawnBound;
    public float minSpawnDistance;
    public float maxSpawnDistance;
    public float spawnRate;

    //public bool canSpawn = false;
    #endregion

    public IEnumerator SpawnCounterAI()
    {
        while (true)
        {
            int i = Random.Range(0, counterAIObject.Length);
            minSpawnDistance = runningCamera.transform.position.z + (Random.Range(minSpawnDistance, maxSpawnDistance));
            Vector3 spawnPos = new Vector3(Random.Range(minXSpawnBound, maxXSpawnBound), Random.Range(minYSpawnBound, maxYSpawnBound), minSpawnDistance);
            GameObject counterAI = Instantiate(counterAIObject[i], spawnPos, Quaternion.identity);
        }

        yield return new WaitForSeconds(spawnRate);
    }
}