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
    #endregion

    #region Built In Methods
    private void Start()
    {
        effects = GetComponentInChildren<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
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