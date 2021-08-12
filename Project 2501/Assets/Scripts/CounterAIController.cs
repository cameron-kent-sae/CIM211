using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterAIController : MonoBehaviour
{
    #region Variables
    private PlayerEvolutionManager player;
    private GameObject cameraObject;
    private DataLogger dataLogger;

    private ParticleSystem divergentBurst;
    private ParticleSystem insurgentBurst;

    private DataInventory dataInventory;
    #endregion

    #region Built In Methods
    private void Start()
    {
        cameraObject = GameObject.Find("RunningCamera");
        insurgentBurst = GameObject.Find("InsurgentDataBurst").GetComponent<ParticleSystem>();
        divergentBurst = GameObject.Find("DivergentDataBurst").GetComponent<ParticleSystem>();

        dataLogger = GameObject.Find("Console Panel").GetComponent<DataLogger>();
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
        //Slow down time for seconds
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

            //remove from inventory?

            dataLogger.AddLog("Counter Measures Encountered");
            dataLogger.AddLog("Data Corrupted");

            StartCoroutine(AnimateBurst("Insurgent"));
        }
        else if (player.divergentLevel > player.insurgentLevel)
        {
            int j = Random.Range(player.divergentLevel, player.divergentLevel * 2);
            player.divergentCount = player.divergentCount - j;

            //remove from inventory?

            dataLogger.AddLog("Counter Measures Encountered");
            dataLogger.AddLog("Data Corrupted");
            
            StartCoroutine(AnimateBurst("Divergent"));
        }

        Destroy(gameObject);
    }

    public IEnumerator AnimateBurst(string path)
    {
        switch (path)
        {
            case "Divergent":
                divergentBurst.Play();
                yield return new WaitForSeconds(1.5f);
                divergentBurst.Stop();
                break;
            case "Insurgent":
                insurgentBurst.Play();
                yield return new WaitForSeconds(1.5f);
                insurgentBurst.Stop();
                break;
            default:
                break;
        }
    }
    #endregion
}