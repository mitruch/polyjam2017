using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CinematicEffects;

public class Aberacja : MonoBehaviour {

    private LensAberrations aberacja;
    // Use this for initialization
    void Start () {
        aberacja = GetComponent<LensAberrations>();
    }

    // Update is called once per frame
    void Update () {
        aberacja.chromaticAberration.amount = Mathf.Min(Mathf.Pow(Time.timeScale,4), 120.0f)*Mathf.Sin(Time.time);
	}
}
