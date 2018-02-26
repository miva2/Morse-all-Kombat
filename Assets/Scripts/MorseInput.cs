using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorseInput : MonoBehaviour
{
    public PlayerInput playerInput1;
    public PlayerInput playerInput2;
    public PlayerInput menuHandler;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // TODO: if started take input

        if (menuHandler)
        {
            if (Input.GetButton("ButtonPlayer1") || Input.GetButton("ButtonPlayer2"))
            {
                menuHandler.PressButton();
            }
            else
            {
                menuHandler.ReleaseButton();
            }
        }
        else
        {
            if (Input.GetButton("ButtonPlayer1"))
            {
                playerInput1.PressButton();
            }
            else
            {
                playerInput1.ReleaseButton();
            }
            if (playerInput2)
            {
                if (Input.GetButton("ButtonPlayer2"))
                {
                    playerInput2.PressButton();
                }
                else
                {
                    playerInput2.ReleaseButton();
                }
            }
        }
    }
}
