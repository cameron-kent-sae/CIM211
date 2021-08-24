/*
	Cameron Kent	2021
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwapper : MonoBehaviour
{
    #region Variables
    public GameObject cameraMain;
    public GameObject cameraOffset;

    private bool isMainCamera;
    #endregion

    #region Built In Methods
    private void Start()
    {
        isMainCamera = true;    
    }

    private void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            cameraOffset.SetActive(false);
            cameraMain.SetActive(true);
        }

        if (Input.GetKeyDown("2"))
        {
            cameraMain.SetActive(false);
            cameraOffset.SetActive(true);
        }
    }
    #endregion

    #region Custom Methods

    #endregion
}