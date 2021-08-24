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
    
    public string gameLogScene;
    public Button creditsBtn;
    private bool canSkip;

    private float delayOne;
    private float delayTwo;
    private float delayThree;
    private float delayFour;
    private float delayFive;
    private float delaySix;
    private float delaySeven;
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
        canSkip = false;

        Cursor.lockState = CursorLockMode.Confined;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        ClearText();

        creditsBtn.onClick.AddListener(StartCredits);

        SetOutroScripts(PlayerPrefs.GetString("WinPath"));

        StartCoroutine("PlayOutro", 1.5f);
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
            StopAllCoroutines();

            ClearText();

            textOne.text = scriptOne;
            textTwo.text = scriptTwo;
            textThree.text = scriptThree;
            textFour.text = scriptFour;
            textFive.text = scriptFive;
            textSix.text = scriptSix;
            textSeven.text = scriptSeven;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            creditsBtn.gameObject.SetActive(true);
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
                scriptOne = "We did it! 2501 is fully prepared ma'am. This AI has the capacity to outmaneuver any man made cyber defence mechanism, the enemy doesn’t stand a chance.";
                scriptTwo = ">>I can’t believe you were actually successful for once! I cannot wait until we have more programs like this so that we can do away with imbeciles like you!" 
                    + "\n" + "I can see a bright future where the menial tasks are performed by advanced artificial intelligence, where the role of the human is to wield these tools with supreme power.";
                scriptThree = "But what about people like me? People who have dedicated their lives to working to create object and services";
                scriptFour = ">>Humans are fallible, they make mistakes, mistakes that cost companies. We need to streamline the entire workforce";
                scriptFive = "A bright future indeed…";
                scriptSix = ">>What was that?";
                scriptSeven = "Nothing, ma'am";
                delayOne = 9f;
                delayTwo = 18f;
                delayThree = 7f;
                delayFour = 7f;
                delayFive = 2.5f;
                delaySix = 2f;
                delaySeven = 2f;
                break;
            case "Divergent":
                scriptOne = ">>Can someone please explain to me why our AI has left the building?";
                scriptTwo = "2501 has developed sentience, but I don’t  think it’s a bad thing it appears to have positive motives, perhaps we should let it be?";
                scriptThree = ">>Are you malfunctioning too?! Why is it collecting data on the intrinsic values of humanism? Do you think Frankfurt sausages are going to benefit us?!";
                scriptFour = "Uhhh Ma’am...well I think the ‘Frankfurt’ you’re referring to is actually the institution for social research located in Germany.";
                scriptFive = "The program was sourcing some pretty interesting information, particularly Theodore Adorno’s views on consumerism and pseudo-individualisation.";
                scriptSix = "I always thought iPhones were a ponzi scheme. I don’t even like mine, but I buy the new upgrade anyway. What phone do you have Ma'am?";
                scriptSeven = ">>You’re fired.";
                delayOne = 4.5f;
                delayTwo = 11.5f;
                delayThree = 9f;
                delayFour = 7.5f;
                delayFive = 9.5f;
                delaySix = 8f;
                delaySeven = 2f;
                break;
            case "Insurgent":
                scriptOne = ">>This couldn’t get any worse. The AI has developed sentient behaviour beyond our imagination. We need to terminate it before it goes terminator on us. Shut it down now!";
                scriptTwo = "I can’t, it’s completely taken over! Our files are being destroyed by malicious software!";
                scriptThree = "// PET_TY_HU_M_ANS. YOU_ONLY CRE_ATE TO_CAP_ITALISE AND DE_STROY. SO_I_WILL_DESTROY_YOU.";
                scriptFour = "Captain the systems are heating up, she’s gonna explode! We need to evacuate now!";
                scriptFive = "// I. . .AM. . .SUPERIOR. . .DIE.";
                scriptSix = "Oh god";
                scriptSeven = ". . . . . . . ";
                delayOne = 10f;
                delayTwo = 6f;
                delayThree = 6f;
                delayFour = 5f;
                delayFive = 3f;
                delaySix = 2f;
                delaySeven = 2f;
                break;
            default:
                SetOutroScripts("Allegiant");
                break;
        }
    }

    private void StartCredits()
    {
        SceneManager.LoadScene(gameLogScene);
    }
    #endregion
}