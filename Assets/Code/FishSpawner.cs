using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{

    public float SpawnInterval = 1.0f; // s

    public Vector2 SpawnArea = new Vector2(2.0f, 2.0f);

    public List<GameObject> Items;

    public List<GameObject> SpawnedItems;


    void Start()
    {
        InvokeRepeating("SpawnItem", SpawnInterval, SpawnInterval);
    }

    void Update()
    {
        // if (Input.GetKeyUp(KeyCode.Space))
        // {
        //     Debug.Log("Poland can into space");
        // }
    }

    void SpawnItem()
    {
        GameObject ItemPrefab = Items[Random.Range(0, Items.Count)];
        Vector3 SpawnPosition = new Vector3(
            (Random.value * 2.0f - 1.0f) * SpawnArea.x,
            (Random.value * 2.0f - 1.0f) * SpawnArea.y,
            0.0f
        );

        GameObject Item = Instantiate(ItemPrefab, SpawnPosition, Quaternion.identity) as GameObject;
        Item.GetComponent<SpriteRenderer>().color = Random.ColorHSV(0.0f, 1.0f);
        SpawnedItems.Add(Item);

        Debug.Log("called " + SpawnPosition);
    }
}