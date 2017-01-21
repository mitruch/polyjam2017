using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingWaves : MonoBehaviour {

    private Rigidbody2D falka;
    private float startSeed;
    private float intervalSeed;

    // Use this for initialization
    void Start () {
        startSeed = Random.Range(0.0f, 10.0f);
        intervalSeed = Random.Range(1.0f, 2.0f);
        falka = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update () {
        falka.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Sin(intervalSeed*Time.time+ startSeed) *10);
        //falka.transform.RotateAroundLocal(new Vector3(1.0f, 0.0f, 0.0f), 30.0f);
        transform.RotateAround(Vector3.zero, Vector3.forward, Mathf.Sin(intervalSeed * Time.time + startSeed) * 10);
        Debug.Log("test");
	}
}
