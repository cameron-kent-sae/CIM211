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
    public float zMoveBound;
    public float minXMoveBound;
    public float maxXMoveBound;
    public float minYMoveBound;
    public float maxYMoveBound; public Vector3 startPos;
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
            Vector3 newPos = new Vector3(Random.Range(minXMoveBound, maxXMoveBound), Random.Range(minYMoveBound, maxXMoveBound), Random.Range(startPos.z - zMoveBound, startPos.z + zMoveBound));
            gameObject.LeanMove(newPos, moveRate).setEaseInOutBounce();

            yield return new WaitForSeconds(moveRate);

            gameObject.LeanMove(startPos, moveRate).setEaseInOutBounce();

            yield return new WaitForSeconds(moveRate);
        }
    }
    #endregion
}