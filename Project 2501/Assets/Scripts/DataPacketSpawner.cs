using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPacketSpawner : MonoBehaviour
{
    #region Variables
    public List<GameObject> allegientPackets = new List<GameObject>();
    public List<GameObject> divergentPackets = new List<GameObject>();
    public List<GameObject> insurgentPackets = new List<GameObject>();
    public List<GameObject> otherPackets = new List<GameObject>();

    public float minXSpawnBound;
    public float maxXSpawnBound;
    public float minYSpawnBound;
    public float maxYSpawnBound;
    public float minSpawnDistance;
    public float maxSpawnDistance;

    public float spawnRate = 1f;

    public GameObject runningCamera;
    #endregion

    #region Built-in Methods
    private void Start()
    {
        PopulatePacketArrays();

        StartCoroutine(SpawnAllegiantPacket());
        StartCoroutine(SpawnDivergentPacket());
        StartCoroutine(SpawnInsurgentPacket());
        StartCoroutine(SpawnOtherPacket());
    }
    #endregion

    #region Custom Methods
    private IEnumerator SpawnAllegiantPacket()
    {
        while (true)
        {
            int i = Random.Range(0, allegientPackets.Count);
            minSpawnDistance = runningCamera.transform.position.z + (Random.Range(minSpawnDistance, maxSpawnDistance));
            Vector3 spawnPos = new Vector3(Random.Range(minXSpawnBound, maxXSpawnBound), Random.Range(minYSpawnBound, maxYSpawnBound), minSpawnDistance);
            GameObject packet = Instantiate(allegientPackets[i], spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(spawnRate);
        }
    }

    private IEnumerator SpawnDivergentPacket()
    {
        while (true)
        {
            int i = Random.Range(0, divergentPackets.Count);
            minSpawnDistance = runningCamera.transform.position.z + (Random.Range(minSpawnDistance, maxSpawnDistance));
            Vector3 spawnPos = new Vector3(Random.Range(minXSpawnBound, maxXSpawnBound), Random.Range(minYSpawnBound, maxYSpawnBound), minSpawnDistance);
            GameObject packet = Instantiate(divergentPackets[i], spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(spawnRate);
        }
    }

    private IEnumerator SpawnInsurgentPacket()
    {
        while (true)
        {
            int i = Random.Range(0, insurgentPackets.Count);
            minSpawnDistance = runningCamera.transform.position.z + (Random.Range(minSpawnDistance, maxSpawnDistance));
            Vector3 spawnPos = new Vector3(Random.Range(minXSpawnBound, maxXSpawnBound), Random.Range(minYSpawnBound, maxYSpawnBound), minSpawnDistance);
            GameObject packet = Instantiate(insurgentPackets[i], spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(spawnRate);
        }
    }

    private IEnumerator SpawnOtherPacket()
    {
        while (true)
        {
            int i = Random.Range(0, otherPackets.Count);
            minSpawnDistance = runningCamera.transform.position.z + (Random.Range(minSpawnDistance, maxSpawnDistance));
            Vector3 spawnPos = new Vector3(Random.Range(minXSpawnBound, maxXSpawnBound), Random.Range(minYSpawnBound, maxYSpawnBound), minSpawnDistance);
            GameObject packet = Instantiate(otherPackets[i], spawnPos, Quaternion.identity);

            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void PopulatePacketArrays()
    {
        GameObject[] allegientObjects = Resources.LoadAll<GameObject>("DataPackets/Allegiant");
        GameObject[] divergentObjects = Resources.LoadAll<GameObject>("DataPackets/Divergent");
        GameObject[] insurgentObjects = Resources.LoadAll<GameObject>("DataPackets/Insurgent");
        GameObject[] otherObjects = Resources.LoadAll<GameObject>("DataPackets/Other");

        foreach (GameObject i in allegientObjects) { allegientPackets.Add(i); }
        foreach (GameObject i in divergentObjects) { divergentPackets.Add(i); }
        foreach (GameObject i in insurgentObjects) { insurgentPackets.Add(i); }
        foreach (GameObject i in otherObjects) { otherPackets.Add(i); }
    }
    #endregion
}
