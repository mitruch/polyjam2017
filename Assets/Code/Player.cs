using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public AudioClip Theme;
    public AudioClip ScorePlusPlus;
    public Vector2 jumpForce = new Vector2(0, 3);
    public Text Text;
    private new Rigidbody2D rigidbody2D;
    private int score;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        AudioPlayer.Instance.PlayAtMainCamera(Theme,
            volume: 1.0f,
            autoDestroy: false
        ).loop = true;
    }

    void Die()
    {
        Debug.Log("die collision");
        Application.LoadLevel(Application.loadedLevel);
    }

    void Update()
    {
        Vector3 cat_position = transform.position;
        Vector3 cat_screen_position = Camera.main.WorldToViewportPoint(cat_position);

        if (cat_screen_position.y < 0)
        {
            Die();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Debug.Log("cat_screen_position" + cat_screen_position);
            float edge = 1;
            float c_s_pos_y = cat_screen_position.y;

            if (c_s_pos_y > 0.75)
            {
                jumpForce.y = (edge - c_s_pos_y) * 10;
            }
            else
            {
                jumpForce.y = 6;
            }

            // Debug.Log(jumpForce.y);
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(jumpForce, ForceMode2D.Impulse);
            // Debug.Log(score);
        }

        if (cat_screen_position.y > 1.0)
        {
            Vector3 screenHeight = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 1.0f, 0.0f));
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -1.0f * 50.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        AudioPlayer.Instance.PlayAtMainCamera(ScorePlusPlus,
            volume: 1.0f,
            autoDestroy: true
        ).loop = false;

        score++;
        Text.text = "Score: " + score;

        FishSpawner.Instance.RemoveItem(collision.gameObject);
        Destroy(collision.gameObject);

        Debug.Log("score " + score);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Die();
    }
}
