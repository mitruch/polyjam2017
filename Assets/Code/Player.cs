using System.Collections;
using System.Collections.Generic;

using UnityEngine.UI;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public Text Wasted;
    public ParticleSystem Tail;
    public AudioClip Theme;
    public AudioClip ScorePlusPlus;
    public Vector2 jumpForce = new Vector2(0, 3);
    public Text Text;
    private float Stamina = 1.0f;
    private new Rigidbody2D rigidbody2D;
    private int score;
    private bool splashOnce;
    public List<GameObject> Items;
    private float saved_time;

    GameObject FadeGameObject;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Time.timeScale = 1.0f;

        splashOnce = true;
        AudioPlayer.Instance.PlayAtMainCamera(Theme,
            volume: 1.0f,
            autoDestroy: false
        ).loop = true;

        FadeGameObject = iTween.CameraFadeAdd();
    }

    void Splash()
    {
        Vector3 t = transform.position + new Vector3(0.0f, 2.0f, 0.0f);
        if (splashOnce)
        {
            splashOnce = false;
            GameObject ItemPrefab = Items[UnityEngine.Random.Range(0, Items.Count)];
            GameObject splash = Instantiate(ItemPrefab, t, Quaternion.identity) as GameObject;
        }
        Invoke("Die", 0.2f);
    }

    void Die()
    {
        Time.timeScale = 0.1f;
        Wasted.color = Color.red;

        // iTween.ColorTo(Wasted, iTween.Hash());

        iTween.CameraFadeTo(iTween.Hash(
            "amount", 0.5f,
            "time", 0.8f
            //"oncomplete", "RestartLevel",
            // "oncompletetarget", gameObject
        ));

        Invoke("RestartLevel", 0.5f);

        Debug.Log("die collision");
    }

    void RestartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    void Update()
    {
        Stamina = Mathf.Clamp01(Stamina - 0.1f * Time.deltaTime);
        //Debug.Log("Stamina: " + Stamina);
        if (Tail)
        {
            Tail.playbackSpeed = Mathf.Lerp(1.0f, 10.0f, Stamina);
            Tail.startSize = Mathf.Lerp(0.0f, 1.0f, Stamina);
        }

        Vector3 cat_position = transform.position;
        Vector3 cat_screen_position = Camera.main.WorldToViewportPoint(cat_position);

        if (cat_screen_position.y < 0)
        {
            Splash();
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0)
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
                "amount", 0.1f * Vector3.down,
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
        iTween.PunchScale(gameObject, iTween.Hash(
            "amount", 1.5f * Vector3.one,
            "time", 0.5f
        ));

        if (collision.gameObject.tag == "fish" || collision.gameObject.tag=="gold")
        {
            AudioPlayer.Instance.PlayAtMainCamera(ScorePlusPlus,
                volume: 1.0f,
                // pitch: Random.Range(0.97f, 1.03f),
                autoDestroy: true
            ).loop = false;

            Stamina = Mathf.Clamp01(Stamina + 1.0f);
            score++;
            Text.text = "Score: " + score;

            iTween.PunchScale(Text.gameObject, iTween.Hash(
               "amount", 1.5f * Vector3.one,
               "time", 0.5f
             ));

            //try
            //{
                FishSpawner.Instance.RemoveItem(collision.gameObject);
                Destroy(collision.GetComponent<Rybka>().EmitParticles(), 1.0f);
                Destroy(collision.gameObject);
           //| }
           // catch (Exception e) {
           //     Die();
           // }

            Time.timeScale += 0.05f;

            if (collision.gameObject.tag == "gold") {
                saved_time = Time.timeScale;
                Time.timeScale *= 1.5f;

                Invoke("addgolden",2.0f);
            }

                Debug.Log("score " + score);
        }
        else
        {
            Splash();
        }
    }

    void addgolden()
    {
        Time.timeScale = saved_time;

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Splash();
    }
}
