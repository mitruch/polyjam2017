using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SetSortingLayer: MonoBehaviour
{
    public string sortingLayerName;
    public int sortingOrder;

    void Start()
    {
        GetComponent<Renderer>().sortingLayerName = sortingLayerName;
        GetComponent<Renderer>().sortingOrder = sortingOrder;
    }
}