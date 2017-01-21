using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    private MeshCollider falka;
    private float startSeed;
    private float intervalSeed;
    public int SortingOrder;
    private Vector3 position;

    private MeshRenderer Renderer;
    // Use this for initialization
    void Start()
    {
        startSeed = Random.Range(0.0f, 10.0f);
        intervalSeed = Random.Range(1.0f, 2.0f);
        falka = GetComponent<MeshCollider>();
        Renderer = GetComponent<MeshRenderer>();
        Renderer.sortingOrder = SortingOrder;
        position = falka.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        falka.transform.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Sin(intervalSeed * Time.time + startSeed) * 2);
        //falka.transform.position = position + new Vector3(0.0f, Mathf.Sin(Time.time) * 2, 0.0f);
       // Debug.Log("test");
    }
}
