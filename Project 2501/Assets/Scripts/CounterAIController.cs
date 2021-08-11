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