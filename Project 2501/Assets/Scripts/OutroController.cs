/*
	Cameron Kent	2021
*/
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OutroController : MonoBehaviour
{
    #region Variable
    [Header("Text Fields")]
    public TMP_Text textOne;
    public TMP_Text textTwo;
    public TMP_Text textThree;
    public TMP_Text textFour;
    public TMP_Text textFive;
    public TMP_Text textSix;
    public TMP_Text textSeven;

    [Header("Text Delays")]
    public float delayOne;
    public float delayTwo;
    public float delayThree;
    public float delayFour;
    public float delayFive;
    public float delaySix;
    public float delaySeven;

    public string gameLogScene;
    public Button creditsBtn;

    private string scriptOne;
    private string scriptTwo;
    private string scriptThree;
    private string scriptFour;
    private string scriptFive;
    private string scriptSix;
    private string scriptSeven;
    #endregion

    #region Built In Methods
    private void Start()
    {
        Time.timeScale = 1;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        textOne.text = "";
        textTwo.text = "";
        textThree.text = "";
        textFour.text = "";
        textFive.text = "";
        textSix.text = "";
        textSeven.text = "";

        creditsBtn.onClick.AddListener(StartCredits);

        SetOutroScripts(PlayerPrefs.GetString("WinPath"));

        StartCoroutine("PlayOutro", 3);
    }
    #endregion

    #region Custom Methods
    private IEnumerator PlayOutro()
    {
        StartCoroutine(TypewriteText(textOne, scriptOne, 0.05f));

        yield return new WaitForSeconds(delayOne);

        StartCoroutine(TypewriteText(textTwo, scriptTwo, 0.05f));

        yield return new WaitForSeconds(delayTwo);

        StartCoroutine(TypewriteText(textThree, scriptThree, 0.05f));

        yield return new WaitForSeconds(delayThree);

        StartCoroutine(TypewriteText(textFour, scriptFour, 0.05f));

        yield return new WaitForSeconds(delayFour);

        StartCoroutine(TypewriteText(textFive, scriptFive, 0.05f));

        yield return new WaitForSeconds(delayFive);

        StartCoroutine(TypewriteText(textSix, scriptSix, 0.05f));

        yield return new WaitForSeconds(delaySix);

        StartCoroutine(TypewriteText(textSeven, scriptSeven, 0.05f));

        yield return new WaitForSeconds(delaySeven);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        creditsBtn.gameObject.SetActive(true);
    }

    private IEnumerator TypewriteText(TMP_Text text, string script, float delay)
    {
        foreach (char c in script)
        {
            text.text += c;
            yield return new WaitForSeconds(delay);
        }
    }

    private void SetOutroScripts(string path)
    {
        switch (path)
        {
            case "Allegiant":
                scriptOne = "xxx";
                scriptTwo = "xxx";
                scriptThree = "xxx";
                scriptFour = "xxx";
                scriptFive = "xxx";
                scriptSix = "xxx";
                scriptSeven = "xxx";
                break;
            case "Divergent":
                scriptOne = "xxx";
                scriptTwo = "xxx";
                scriptThree = "xxx";
                scriptFour = "xxx";
                scriptFive = "xxx";
                scriptSix = "xxx";
                scriptSeven = "xxx";
                break;
            case "Insurgent":
                scriptOne = "xxx";
                scriptTwo = "xxx";
                scriptThree = "xxx";
                scriptFour = "xxx";
                scriptFive = "xxx";
                scriptSix = "xxx";
                scriptSeven = "xxx";
                break;
            default:
                scriptOne = "test";
                scriptTwo = "test";
                scriptThree = "test";
                scriptFour = "test";
                scriptFive = "test";
                scriptSix = "test";
                scriptSeven = "test";
                break;
        }
    }

    private void StartCredits()
    {
        SceneManager.LoadScene(gameLogScene);
    }
    #endregion
}