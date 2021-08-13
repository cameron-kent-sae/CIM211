/*
	Cameron Kent	2021
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CounterAIMover : MonoBehaviour
{
    #region Variables
    public float moveRate;
    public Vector3 startPos;
    #endregion

    #region Built In Methods
    private void Start()
    {
        StartCoroutine(StartMoving());
    }
    #endregion

    #region Custom Methods
    public IEnumerator StartMoving()
    {
        while (true)
        {
            Vector3 newPos = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f), Random.Range(startPos.z - 1.5f, startPos.z + 1.5f));
            gameObject.LeanMove(newPos, moveRate).setEaseInOutBounce();

            yield return new WaitForSeconds(moveRate);

            gameObject.LeanMove(startPos, moveRate).setEaseInOutBounce();

            yield return new WaitForSeconds(moveRate);
        }
    }
    #endregion
}