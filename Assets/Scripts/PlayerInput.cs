using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public static float dashTime = 0.15f;
    public static float pauseTime = 0.25f;

    public const char DASH = Morse.DASH, DOT = Morse.DOT;
    public ShowInput showInputScript;

    private static float sDashTime = -1;
    private static float sPauseTime = -1;
    

    //current time button is pressed
    private float inputTime = 0;
    //current time button is released
    private float releaseTime = 0;
    
    //morse input string
    protected string inputString = "";
    //button released on this frame
    private bool justReleasedButton = false;

    // Use this for initialization
    protected virtual void Start()
    {
        showInputScript = this.GetComponent<ShowInput>();

        //using static variables to set both prlayerInput variables to same value
        if(sDashTime < 0)
        {
            sDashTime = dashTime;
            sPauseTime = pauseTime;
        }
        else
        {
            dashTime = sDashTime;
            pauseTime = sPauseTime;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    //updates when player button is pressed
    public void PressButton()
    {
        //resets releaseTime -> next ReleaseButton it should be 0
        releaseTime = 0;

        inputTime += Time.deltaTime;
        justReleasedButton = true;
    }

    //updates when player button is not pressed
    public void ReleaseButton()
    {

        if (justReleasedButton)
        {
            justReleasedButton = false;
            if (inputTime > dashTime)
            {
                inputString += DASH;
            }
            else
            {
                inputString += DOT;
            }
        }
        //resets inputTime -> next PressButton it should be 0
        inputTime = 0;

        releaseTime += Time.deltaTime;
        if(releaseTime > pauseTime && inputString != "")
        {
            SendAction();
            inputString = "";
        }
    }

    protected virtual void SendAction()
    {
        char letter = MorseDictionary.TranslateMorseToLetter(inputString);
        GetComponent<PlayerScript>().ExecuteAttack(letter);
        if (showInputScript)
        {
            showInputScript.ShowText(letter.ToString());
            StartCoroutine(MorseSound.morseSound.PlayMorseSound(inputString));
        }
        //Debug.Log(gameObject.name + ": " + MorseDictionary.TranslateMorseToLetter(inputString));
    }

}
