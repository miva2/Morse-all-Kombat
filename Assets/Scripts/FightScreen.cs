using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightScreen : PlayerInput {
    
    public float riseHeight;
    public float riseTime;
    public AnimationCurve riseCurve;

    private Vector3 startPosition;

    private float riseTimer;

    protected override void Start()
    {
        base.Start();
        startPosition = transform.position;
    }

    protected override void SendAction()
    {

    }

    public void Update()
    {
        riseTimer += Time.deltaTime;
        transform.position = startPosition + Vector3.up * riseHeight * riseCurve.Evaluate(Mathf.Clamp01(riseTimer / riseTime));
        if(riseTimer > riseTime)
        {
            Destroy(gameObject);
        }
    }

}
