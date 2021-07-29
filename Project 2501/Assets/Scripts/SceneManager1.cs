using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager1 : MonoBehaviour
{


    //Selects Scene
    public void SceneSelector(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    //Exits Game
    public void Exit()
    {
        Application.Quit();
    }

}
