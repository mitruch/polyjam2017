using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Osci : MonoBehaviour {
    private ParticleSystem particles;
    Player player;
    float score;
    // Use this for initialization
    void Start () {
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        particles = GetComponent<ParticleSystem>();
        particles.emissionRate = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        particles.emissionRate = Player.score;
        Debug.Log(particles.emissionRate);
	}
}
