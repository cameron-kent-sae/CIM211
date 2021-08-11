using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterAIController : MonoBehaviour
{
    #region Variables
    public PlayerEvolutionManager player;
    public DataInventory dataInventory;

    #endregion

    #region Built In Methods
    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerEvolutionManager>();
        dataInventory = player.dataInventory;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //take data
        }
    }
    #endregion

    #region Custom Methods
    #endregion
}