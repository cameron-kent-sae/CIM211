/*
	Cameron Kent	2021
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsObject : MonoBehaviour
{
    #region Variables
    private ParticleSystem effects;
    private AudioController audioController;

    public AudioClip hitClip;
    #endregion

    #region Built In Methods
    private void Start()
    {
        audioController = GameObject.Find("AudioController").GetComponent<AudioController>();
        effects = GetComponentInChildren<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            audioController.PlayClip(hitClip);
            StartCoroutine(PlayEffect());
        }
    }
    #endregion

    #region Custom Methods
    private IEnumerator PlayEffect()
    {
        effects.Play();

        yield return new WaitForSeconds(.3f);

        Destroy(gameObject);
    }
    #endregion
}