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
    public float moveBound;
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
            Vector3 newPos = new Vector3(Random.Range(startPos.x - moveBound, startPos.x + moveBound), Random.Range(startPos.y - moveBound, startPos.y + moveBound), Random.Range(startPos.z - moveBound, startPos.z + moveBound));
            gameObject.LeanMove(newPos, moveRate).setEaseInOutBounce();

            yield return new WaitForSeconds(moveRate);

            gameObject.LeanMove(startPos, moveRate).setEaseInOutBounce();

            yield return new WaitForSeconds(moveRate);
        }
    }
    #endregion
}