using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeInfluence : MonoBehaviour {
    private ParticleSystem particles;
    private float speed;
    private float emissionRate;
    private float lifeTime;

    // Use this for initialization
    void Start () {
        particles = GetComponent<ParticleSystem>();
        speed = particles.startSpeed;
        emissionRate = particles.emissionRate;
        lifeTime = particles.startLifetime;
    }

    // Update is called once per frame
    void Update () {
        particles.startSpeed = speed*Time.timeScale;
        particles.emissionRate = emissionRate * Time.timeScale * Time.timeScale;
        particles.startLifetime = lifeTime * Time.timeScale;
        particles.gravityModifier = 0.01f / ((Time.timeScale + (Time.timeScale - 1)*5));
	}
}
