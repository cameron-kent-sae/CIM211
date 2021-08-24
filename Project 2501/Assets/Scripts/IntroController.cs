using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroController : MonoBehaviour
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

    public string setupScene;
    public Button launchBtn;
    private bool canSkip;
    #endregion

    #region Narrative Scripts
    private string scriptOne = "Captain, Program 2501 is ready for testing.";
    private string scriptTwo = ">>That’s what you said last time.";
    private string scriptThree = "Uhh..uhh...I mean Ma'am, she’s prime for testing!";
    private string scriptFour = ">>Imbecile! That’s not what I meant! We can’t afford another failure this time. How do you expect us to hack into the enemy’s mainframe unless we know she works and won’t backfire...again!?";
    private string scriptFive = "Uhh...Uhhh that is very true. I hope she works, I mean...I know she works…!";
    private string scriptSix = ">>Boot er up and prepare for simulation!";
    private string scriptSeven = "Aye aye Captain! Oh, I mean...Roger!";
    #endregion

    #region Built In Methods
    private void Start()
    {
        Time.timeScale = 1;
        canSkip = false;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        ClearText();

        launchBtn.onClick.AddListener(StartGame);

        StartCoroutine("PlayIntroduction", 3);
        StartCoroutine("SetSkip");
    }

    private void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            SkipCutscene();
        }
    }
    #endregion

    #region Custom Methods
    private IEnumerator SetSkip()
    {
        yield return new WaitForSeconds(3);
        canSkip = true;
    }

    private void SkipCutscene()
    {
        if (canSkip)
        {
            ClearText();

            StopCoroutine("PlayIntroduction");

            textOne.text = scriptOne;
            textTwo.text = scriptTwo;
            textThree.text = scriptThree;
            textFour.text = scriptFour;
            textFive.text = scriptFive;
            textSix.text = scriptSix;
            textSeven.text = scriptSeven;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            launchBtn.gameObject.SetActive(true);
        }
    }

    private void ClearText()
    {
        textOne.text = "";
        textTwo.text = "";
        textThree.text = "";
        textFour.text = "";
        textFive.text = "";
        textSix.text = "";
        textSeven.text = "";
    }

    private IEnumerator PlayIntroduction()
    {
        StartCoroutine(TypewriteText(textOne, scriptOne, 0.05f));

        yield return new WaitForSeconds(delayOne);

        StartCoroutine(TypewriteText(textTwo, scriptTwo, 0.025f));

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
        launchBtn.gameObject.SetActive(true);
    }

    private IEnumerator TypewriteText(TMP_Text text, string script, float delay)
    {
        foreach (char c in script)
        {
            text.text += c;
            yield return new WaitForSeconds(delay);
        }
    }

    private void StartGame()
    {
        SceneManager.LoadScene(setupScene);
    }
    #endregion
}