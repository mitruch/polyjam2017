using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public static FishSpawner Instance;

    public float SpawnInterval = 1.0f; // s
    public Vector2 SpawnArea = new Vector2(2.0f, 2.0f);
    public List<GameObject> Items;
    public List<GameObject> SpawnedItems;
    public float Speed;

    public void RemoveItem(GameObject Item)
    {
        SpawnedItems.Remove(Item);
    }

    void Awake()
    {
        if (Instance)
        {
            Debug.Log("Multiple FishSpawner singletons");
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        InvokeRepeating("SpawnItem", SpawnInterval, SpawnInterval);
    }

    void Update()
    {
        float speed = 100*Speed * Time.deltaTime;
        for (int i = 0; i < SpawnedItems.Count; i++)
        {
            GameObject item = SpawnedItems[i];
            item.transform.Translate(new Vector3(-speed, 0.0f, 0.0f));

            Vector3 WSPos = Camera.main.WorldToViewportPoint(item.transform.position) - 0.5f * Vector3.left;
            if (WSPos.x < 0.0)
            {
                RemoveItem(item);
                Destroy(item);
            }
        }
    }

    void SpawnItem()
    {
        GameObject ItemPrefab = Items[Random.Range(0, Items.Count)];
        Vector3 SpawnPosition = transform.position + new Vector3(
            (Random.value * 2.0f - 1.0f) * SpawnArea.x,
            (Random.value * 2.0f - 1.0f) * SpawnArea.y,
            0.0f
        );

        GameObject Item = Instantiate(ItemPrefab, SpawnPosition, Quaternion.identity) as GameObject;
        Item.GetComponent<SpriteRenderer>().color = 4.0f * Random.ColorHSV(0.0f, 1.0f);
        SpawnedItems.Add(Item);

        // Debug.Log("called " + SpawnPosition);
    }
}