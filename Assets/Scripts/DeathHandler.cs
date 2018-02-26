using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour {

    public static DeathHandler deathHandler;

    public MorseInput morseInput;
    public GameObject EndCanvas;

    private void Start()
    {
        deathHandler = this;
    }

    public IEnumerator Die(string playerName)
    {
        if (PlayerScript.useGlitch)
        {
            yield return new WaitForSeconds(30);
        }
        EndScreen endScreen = Instantiate(EndCanvas).GetComponent<EndScreen>();
        morseInput.menuHandler = endScreen;
        yield return new WaitForSeconds(3);
        endScreen.AllowInput();

    }

}
