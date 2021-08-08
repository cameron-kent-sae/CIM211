using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IntroController : MonoBehaviour
{
    #region Variable
    public TMP_Text textOne;
    public TMP_Text textTwo;
    public TMP_Text textThree;

    public Image captainSprite;
    public Image techSprite;

    public GameObject launchBtn;

    private Color fadeColor = new Color(50, 50, 50, 255);
    private Color focusColor = new Color(250, 250, 250, 255);

    private float delayOne = 3f;
    private float delayTwo = 2f;
    private float delayThree = 2f;
    private float delayFour = 2f;
    #endregion

    #region Scripts
    private string scriptOne = "“Captain, Program 2501 is ready for testing.”";
    private string scriptTwo = "“Boot er up soldier. We can’t hack into their information systems unless we know she works. We can’t have another cyber coup on our hands. Prepare for simulation!”";
    private string scriptThree = "“Roger”";
    #endregion

    #region Built In Methods
    private void Start()
    {
        Time.timeScale = 1;

        textOne.text = "";
        textTwo.text = "";
        textThree.text = "";

        //techSprite.color = fadeColor;
        //captainSprite.color = fadeColor;

        //techSprite.gameObject.LeanScale(new Vector3(.8f, .8f, .8f), .0f);
        //captainSprite.gameObject.LeanScale(new Vector3(.8f, .8f, .0f), .5f);

        StartCoroutine("PlayIntroduction", delayOne);
    }

    #endregion

    #region Custom Methods
    private IEnumerator PlayIntroduction()
    {
        //StartCoroutine(AnimateTech());
        //techSprite.color = focusColor;
        techSprite.color = Color.Lerp(fadeColor, focusColor, .5f);
        //LeanTween.value(techSprite.gameObject, fadeColor, focusColor, .25f);
       
        //techSprite.gameObject.LeanScale(new Vector3(1.1f, 1.1f, 1.1f), .5f).setEaseInCirc();
        techSprite.gameObject.LeanValue(fadeColor, focusColor, .5f);

        foreach (char c in scriptOne)
        {
            textOne.text += c;
            yield return new WaitForSeconds(0.025f);
        }

        //LeanTween.value(techSprite.gameObject, focusColor, fadeColor, .25f);
        techSprite.color = Color.Lerp(focusColor, fadeColor, .5f);

        //techSprite.color = fadeColor;
        techSprite.gameObject.LeanScale(new Vector3(.8f, .8f, .8f), .5f).setEaseInCirc();

        yield return new WaitForSeconds(delayTwo);

        //captainSprite.color = focusColor;
        captainSprite.gameObject.LeanScale(new Vector3(1.1f, 1.1f, 1.1f), .5f).setEaseInCirc();

        foreach (char c in scriptTwo)
        {
            textTwo.text += c;
            yield return new WaitForSeconds(0.025f);
        }

        //captainSprite.color = fadeColor;
        captainSprite.gameObject.LeanScale(new Vector3(.8f, .8f, .8f), .5f).setEaseInCirc();

        yield return new WaitForSeconds(delayThree);
       
        //techSprite.color = focusColor;
        techSprite.gameObject.LeanScale(new Vector3(1.1f, 1.1f, 1.1f), .5f).setEaseInCirc();

        foreach (char c in scriptThree)
        {
            textThree.text += c;
            yield return new WaitForSeconds(0.025f);
        }

        //techSprite.color = fadeColor;
        techSprite.gameObject.LeanScale(new Vector3(.8f, .8f, .8f), .5f).setEaseInCirc();

        yield return new WaitForSeconds(delayFour);

        launchBtn.SetActive(true);
    }


    #endregion
}