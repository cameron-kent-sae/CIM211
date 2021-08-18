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
    public AudioController audioController;

    public AudioClip counterAIHitClip;
    
    private bool isSlowed = false;
    #endregion

    #region Built In Methods
    private void Start()
    {
        cameraRunner = GameObject.Find("RunningCamera");
        insurgentBurst = GameObject.Find("InsurgentDataBurst").GetComponent<ParticleSystem>();
        divergentBurst = GameObject.Find("DivergentDataBurst").GetComponent<ParticleSystem>();
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
        dataLogger = GameObject.Find("UIController").GetComponent<DataLogger>();
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
            StealPackets();
            audioController.PlayClip(counterAIHitClip);

            SlowTime();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Invoke("NormalTime", .2f);
        }
    }
    #endregion

    #region Custom Methods
    private void SlowTime()
    {
        Time.timeScale = .1f;
    }
     private void NormalTime()
    {
        Time.timeScale = Mathf.Lerp(.1f, 1, 2);
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