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
        falka.transform.position = position + new Vector3(0.0f, Mathf.Sin(Time.time) * 2, 0.0f);
    }
}
