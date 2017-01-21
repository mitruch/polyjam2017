using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panner1 : MonoBehaviour
{
    public int SortingOrder;

    private MeshRenderer Renderer;
    private MeshCollider falka;
    private float startSeed;
    private float intervalSeed;
    private Vector3 position;

    void Start()
    {
        Renderer = GetComponent<MeshRenderer>();
        Renderer.sortingOrder = SortingOrder;
        startSeed = UnityEngine.Random.Range(0.0f, 10.0f);
        intervalSeed = UnityEngine.Random.Range(1.0f, 2.0f);
        falka = GetComponent<MeshCollider>();
        position = falka.transform.position;
    }

    void Update()
    {
        Renderer.material.mainTextureOffset = new Vector2(transform.position.z * Time.time/10.0f, 0.0f);
        //falka.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Sin(intervalSeed * Time.time + startSeed) * 5);
        //falka.transform.position = position + new Vector3(0.0f, Mathf.Sin(Time.time) * 2, 0.0f);
    }
}
