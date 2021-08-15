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
    
    private bool isExpanded;
    #endregion

    #region Built In Methods
    private void Update()
    {
        if (isExpanded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                logPanel.LeanMoveY(175, .2f).setEaseOutBounce();
                isExpanded = false;
            }
        }
        else if (!isExpanded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                logPanel.LeanMoveY(-75, .2f).setEaseInBounce();
                isExpanded = true;
            }
        }
    }
    #endregion

    #region Custom Methods

    #endregion
}