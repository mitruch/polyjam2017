using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Player : MonoBehaviour
{

    public Vector2 jumpForce = new Vector2(0, 3);
    public new Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Die()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    void Update()
    {
        Vector3 cat_position = transform.position;
        Vector3 cat_screen_position = Camera.main.WorldToViewportPoint(cat_position);

        if (cat_screen_position.y < 0)
        {
            Debug.Log("die collision");
            Die();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("cat_screen_position" + cat_screen_position);
            float edge = 1;
            float c_s_pos_y = cat_screen_position.y;

            if (c_s_pos_y > 0.75)
            {
                jumpForce.y = (edge - c_s_pos_y) * 100;
            }
            else
            {
                jumpForce.y = 6;
            }

            Debug.Log(jumpForce.y);
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(jumpForce, ForceMode2D.Impulse);
            // Debug.Log(score);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        FishSpawner.Instance.RemoveItem(collision.gameObject);
        Destroy(collision.gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Die();
    }
}
