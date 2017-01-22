using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Height : MonoBehaviour {
    private MeshCollider falka;
    private Vector3 position;

    // Use this for initialization
    void Start()
    {
        falka = GetComponent<MeshCollider>();
        position = falka.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        float x = Time.time/5;
        float height = Mathf.Sin(x) + Mathf.Cos(x) + Mathf.Cos(x * 3) + Mathf.Acos(Mathf.Cos(x / 3));
        height = height / 2;
        falka.transform.position = position + new Vector3(0.0f, height * 2, 0.0f);
    }
}
