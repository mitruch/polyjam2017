using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Renderer TailRenderer;
    public AudioClip Theme;
    public AudioClip ScorePlusPlus;
    public Vector2 jumpForce = new Vector2(0, 3);
    public Text Text;
    private float Stamina = 1.0f;
    private new Rigidbody2D rigidbody2D;
    private int score;

    GameObject FadeGameObject;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        AudioPlayer.Instance.PlayAtMainCamera(Theme,
            volume: 1.0f,
            autoDestroy: false
        ).loop = true;

        FadeGameObject = iTween.CameraFadeAdd();
    }

    void Die()
    {
        iTween.CameraFadeTo(iTween.Hash(
            "amount", 0.5f,
            "time", 0.2f,
            "oncomplete", "RestartLevel",
            "oncompletetarget", gameObject
        ));

        Debug.Log("die collision");
    }

    void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    void Update()
    {
        Stamina = Mathf.Clamp01(Stamina - 0.1f * Time.deltaTime);
        Debug.Log("Stamina: " + Stamina);
        if (TailRenderer)
        {
            TailRenderer.material.SetFloat("_Stamina", Stamina);
        }

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
            jumpForce *= Stamina;
            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(jumpForce, ForceMode2D.Impulse);
            // Debug.Log(score);

            iTween.PunchPosition(Camera.main.gameObject, iTween.Hash(
                "name", "shake" + Time.frameCount,
                "amount", 1.0f * Vector3.down,
                "time", 2.0f
            ));
        }

        if (cat_screen_position.y > 1.0)
        {
            Vector3 screenHeight = Camera.main.ViewportToWorldPoint(new Vector3(0.0f, 1.0f, 0.0f));
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, -1.0f * 50.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "fish")
        {
            AudioPlayer.Instance.PlayAtMainCamera(ScorePlusPlus,
                volume: 1.0f,
                // pitch: Random.Range(0.97f, 1.03f),
                autoDestroy: true
            ).loop = false;

            Stamina = Mathf.Clamp01(Stamina + 1.0f);
            score++;
            Text.text = "Score: " + score;

            iTween.PunchScale(gameObject, iTween.Hash(
                "amount", 1.3f * Vector3.one,
                "time", 0.0f
            ));

            FishSpawner.Instance.RemoveItem(collision.gameObject);
            Destroy(collision.gameObject);

            Debug.Log("score " + score);
        }
        else
        {
            Die();
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Die();
    }
}
