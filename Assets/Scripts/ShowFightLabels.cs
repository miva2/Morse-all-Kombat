using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFightLabels : MonoBehaviour {

    public Text[] labels;
    public AnimationCurve fadeCurve;
    public float timeMultiplier;

	// Use this for initialization
	void Start () {
        StartCoroutine("FadeLabels");
	}
	
	// Update is called once per frame
	//void Update () {
	//	foreach(Text label in labels)
 //       {
 //           label.CrossFadeAlpha(0f, 3f, true);
 //       }
	//}

    public IEnumerator FadeLabels()
    {
        Color c = new Color();
        float alpha = 1f;
        float t = 0;
        while (alpha >= 0.1f)
        {
            foreach (Text label in labels)
            {
                c = label.color;
                c.a = alpha;
                //label.CrossFadeAlpha(0f, 3f, true);
                label.color = c;
                //alpha -= 0.01f;
                alpha = fadeCurve.Evaluate(t * timeMultiplier);
                t += Time.deltaTime;
                //Debug.Log("alpha: " + alpha);
                //Debug.Log("t: " + t);
            }
            yield return null;
        }
        ResetAlpha();
    }

    private void ResetAlpha()
    {
        Color c = new Color();
        foreach (Text label in labels)
        {
            c = label.color;
            c.a = 0;
            label.color = c;
        }
    }

}
