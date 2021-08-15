/*
	Cameron Kent	2021
*/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NarrationLogger : MonoBehaviour
{
    #region Variables
    public TMP_Text textLog;
    public GameObject logPanel;

    private float xPos;

    private bool isExpanded;
    #endregion

    #region Built In Methods
    private void Start()
    {
        xPos = logPanel.transform.position.x;
    }

    private void Update()
    {
        if (isExpanded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                logPanel.LeanMoveX(1895, .2f).setEaseOutBounce();
                //logPanel.LeanMoveX(1895, .2f).setEaseOutBounce();
                isExpanded = false;
            }
        }
        else if (!isExpanded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                logPanel.LeanMoveX(1445, .2f).setEaseInBounce();
                //logPanel.LeanMoveX(1445, .2f).setEaseInBounce();
                isExpanded = true;
            }
        }
    }
    #endregion

    #region Custom Methods

    #endregion
}