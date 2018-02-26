using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : PlayerInput {

    public Vector3 EndLocation;
    public Camera menuCamera;
    public AnimationCurve cameraMovement;
    public float speed = 1;

    private Vector3 startLocation;

    private float t;

    protected override void Start()
    {
        base.Start();
        startLocation = menuCamera.transform.position;
    }

    private void Update()
    {
        t -= Time.deltaTime * speed;
        t = Mathf.Clamp01(t);
        menuCamera.transform.position = Vector3.Lerp(startLocation, EndLocation, cameraMovement.Evaluate(t));
    }

    private enum EnumMenuType
    {
        Main,
        Instructions
    }

    private EnumMenuType currentMenu = EnumMenuType.Main;

    protected override void SendAction()
    {
        switch (currentMenu)
        {
            case EnumMenuType.Main:
                MainMenuAction(MorseDictionary.TranslateMorseToLetter(inputString));
                break;
            case EnumMenuType.Instructions:
                InstructionMenuAction(MorseDictionary.TranslateMorseToLetter(inputString));
                break;
            default:
                break;
        }
    }

    private void MainMenuAction(char letter)
    {

        switch (letter)
        {
            case 'i': //play
                PlayAction();
                break;
            case 'q'://quit
                QuitAction();
                break;
            case 'e'://instructions
            default:
                InstructionsAction();
                break;
        }
    }

    private void InstructionMenuAction(char letter)
    {
        switch (letter)
        {
            case 'n':
                currentMenu = EnumMenuType.Main;
                speed *= -1;
                break;
        }
    }

    private void PlayAction()
    {
        SceneHandler.LoadScene(SceneHandler.GAME);
    }

    private void InstructionsAction()
    {
        currentMenu = EnumMenuType.Instructions;
        speed *= -1;
    }

    private void QuitAction()
    {
        Application.Quit();
    }

}
