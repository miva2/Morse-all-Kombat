using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : PlayerInput {

    public Text endText;
    public float riseHeight;
    public float riseTime;
    public AnimationCurve riseCurve;

    private Vector3 startPosition;

    private bool allowInput = false;

    private float riseTimer;

    protected override void Start()
    {
        base.Start();
        startPosition = transform.position;
    }

    protected override void SendAction()
    {
        if(allowInput && MorseDictionary.TranslateMorseToLetter(inputString) == 'b')
        {
            SceneHandler.LoadScene(SceneHandler.MAIN_MENU);
        }
    }

    public void Update()
    {
        if (allowInput)
        {
            riseTimer += Time.deltaTime;
            transform.position = startPosition + Vector3.up * riseHeight * riseCurve.Evaluate(Mathf.Clamp01(riseTimer / riseTime));
        }
    }

    public void AllowInput()
    {
        allowInput = true;
    }

}
