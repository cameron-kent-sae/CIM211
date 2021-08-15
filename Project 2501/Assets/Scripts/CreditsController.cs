/*
	Cameron Kent	2021
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsController : MonoBehaviour
{
    #region Variables
    public PlayerEvolutionManager player;
    public GameObject cameraRunner;
    public float endBound;

    public GameObject[] allegiantObjects;
    public GameObject[] divergentObjects;
    public GameObject[] insurgentObjects;
    public string menuScene;
    #endregion

    #region Built In Methods
    private void Start()
    {
        Cursor.visible = false;

        ActivatePlayerObjects();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SceneManager.LoadScene(menuScene);
        }

        if (cameraRunner.transform.position.z >= endBound)
        {
            SceneManager.LoadScene(menuScene);
        }

    }
    #endregion

    #region Custom Methods
    private void ActivatePlayerObjects()
    {
        switch (PlayerPrefs.GetString("WinPath"))
        {
            case "Allegiant":
                foreach (GameObject obj in allegiantObjects)
                {
                    obj.SetActive(true);
                }
                break;
            case "Divergent":
                foreach (GameObject obj in divergentObjects)
                {
                    obj.SetActive(true);
                }
                break;
            case "Insurgent":
                foreach (GameObject obj in insurgentObjects)
                {
                    obj.SetActive(true);
                }
                break;
            default:
                break;
        }
    }
    #endregion
}