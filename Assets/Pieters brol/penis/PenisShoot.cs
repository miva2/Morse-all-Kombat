using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenisShoot : MonoBehaviour {

    public ParticleSystem cumShot;

    public void Sploosh()
    {
        cumShot.Emit(10);
        Debug.Log("*Sploosh!*");
    }
}
