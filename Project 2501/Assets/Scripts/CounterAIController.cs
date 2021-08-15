using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterAIController : MonoBehaviour
{
    #region Variables
    private PlayerEvolutionManager player;
    private GameObject cameraRunner;
    private DataLogger dataLogger;
    private DataInventory dataInventory;
    private ParticleSystem divergentBurst;
    private ParticleSystem insurgentBurst;
    private bool isSlowed = false;
    #endregion

    #region Built In Methods
    private void Start()
    {
        cameraRunner = GameObject.Find("RunningCamera");
        insurgentBurst = GameObject.Find("InsurgentDataBurst").GetComponent<ParticleSystem>();
        divergentBurst = GameObject.Find("DivergentDataBurst").GetComponent<ParticleSystem>();

        dataLogger = GameObject.Find("Console Panel").GetComponent<DataLogger>();
        player = GameObject.Find("Player").GetComponent<PlayerEvolutionManager>();

        dataInventory = player.dataInventory;
    }

    private void Update()
    {
        if (transform.position.z < (cameraRunner.transform.position.z - 25))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //player.StartCoroutine("SlowTime");
            if (!isSlowed)
            {
                StartCoroutine(SlowPlayer());
            }
            StealPackets();
        }
    }
    #endregion

    #region Custom Methods
    public IEnumerator SlowPlayer()
    {
        Debug.Log("Slow Player Called");
        isSlowed = true;

        float tempSpeed = 2f;
        float currentSpeed = cameraRunner.GetComponent<CameraRunner>().speed;
        //cameraRunner.GetComponent<CameraRunner>().speed = Mathf.Lerp(currentSpeed, tempSpeed, .2f);
        cameraRunner.GetComponent<CameraRunner>().speed = 2;
        
        yield return new WaitForSeconds(2);

        //cameraRunner.GetComponent<CameraRunner>().speed = Mathf.Lerp(tempSpeed, currentSpeed, .2f);
        cameraRunner.GetComponent<CameraRunner>().speed = currentSpeed;

        yield return new WaitForSeconds(.2f);

        isSlowed = false;
    }

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

        //Destroy(gameObject);
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