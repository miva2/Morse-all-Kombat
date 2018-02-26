using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInput : MonoBehaviour {
     public Text TextObject;
    // public planePlayer2;

    int counter = 0;
    public ShowInput()
    {
      
    
    }

    public void ShowText(string text)
    {
        //counter++;
        TextObject.text = text;
    }


}
