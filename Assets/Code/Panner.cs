using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panner : MonoBehaviour
{
    public int SortingOrder;

    private MeshRenderer Renderer;


    void Start()
    {
        Renderer = GetComponent<MeshRenderer>();
        Renderer.sortingOrder = SortingOrder;
    }

    void Update()
    {
        Renderer.material.mainTextureOffset = new Vector2(transform.position.z * Time.time, 0.0f);
    }
}
