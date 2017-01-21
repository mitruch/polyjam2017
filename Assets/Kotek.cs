using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kotek : MonoBehaviour
{
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;

    private Rigidbody2D kotek;

    // Use this for initialization
    void Start()
    {
        kotek = GetComponent<Rigidbody2D>();
        InvokeRepeating("Loguj", 1.0f, 1.0f);
    }

    void Update()
    {
        //Debug.Log("adsasdasd");
        /*
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if (Input.GetButton("Jump"))
            {
                Debug.Log("Mejt jest glupi");

                moveDirection.y = jumpSpeed;
            }
            */
       // Debug.Log("is not grounded");

        //moveDirection.y -= gravity * Time.deltaTime;
        //kotek.velocity = new Vector2(1.0f, 1.0f);
        Debug.Log("adsasdasd");
    }

    void Loguj()
    {
    }
}