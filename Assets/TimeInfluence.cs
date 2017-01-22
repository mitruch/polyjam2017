using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeInfluence : MonoBehaviour {
    private ParticleSystem particles;
    // Use this for initialization
    void Start () {
        particles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update () {
        particles.startLifetime = (Time.timeScale - 0.7f) * 10;
        particles.gravityModifier = 0.01f / ((Time.timeScale + (Time.timeScale - 1)*5));
	}
}
