using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterAIController : MonoBehaviour
{
    #region Variables
    public PlayerEvolutionManager player;
    public DataInventory dataInventory;
    public GameObject cameraObject;
    #endregion

    #region Built In Methods
    private void Start()
    {
        cameraObject = GameObject.Find("RunningCamera");
        player = GameObject.Find("Player").GetComponent<PlayerEvolutionManager>();
        dataInventory = player.dataInventory;
    }

    private void Update()
    {
        if (transform.position.z < (cameraObject.transform.position.z - 25))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            StealPackets();
        }
    }
    #endregion

    #region Custom Methods
    private void StealPackets()
    {
        if (player.insurgentLevel > player.divergentLevel)
        {
            int i = Random.Range(player.insurgentLevel, player.insurgentLevel * 2);
            player.insurgentCount = player.insurgentCount - i;
            //animation
        }
        else if (player.divergentLevel > player.insurgentLevel)
        {
            int j = Random.Range(player.divergentLevel, player.divergentLevel * 2);
            player.divergentCount = player.divergentCount - j;
            //animation
        }

        Destroy(gameObject);
    }
    #endregion
}