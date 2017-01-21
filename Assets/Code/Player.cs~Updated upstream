using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Player : MonoBehaviour {

    public Vector2 jumpForce = new Vector2(0, 300);
    public new Rigidbody2D rigidbody2D;
    int score = 0;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    
	// Update is called once per frame
	void Update () {

        if (Input.GetKeyUp("space")) {

            rigidbody2D.velocity = Vector2.zero;
            rigidbody2D.AddForce(jumpForce);
           // Debug.Log(score);
        }
        
	}

    void Die()
    {
        score = 0;
        Application.LoadLevel(Application.loadedLevel);
    }

    

    void OnCollisionEnter2D(Collision2D other)
    {
        {
            Debug.Log("die collision" + score);
            Die();

        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "fish")
        {
            score++;
            Debug.Log("fish collision" + score);
        //    Destroy(other);
            DestroyObject(other.gameObject);
        }
    }




}
