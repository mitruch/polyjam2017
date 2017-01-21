using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rybka : MonoBehaviour {
    public List<GameObject> Items;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
		
	}

    public GameObject EmitParticles()
    {
        GameObject ItemPrefab = Items[Random.Range(0, Items.Count)];
        return Instantiate(ItemPrefab, transform.position, Quaternion.identity) as GameObject;
        //Item.GetComponent<SpriteRenderer>().color = 4.0f * Random.ColorHSV(0.0f, 1.0f);
        //SpawnedItems.Add(Item);
    }
}
