using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed = 10.0f;
    public float turnthres = 0.25f;
    private Rigidbody2D rb2d;
    public int manacount;




    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        manacount = 10;
        rb2d.rotation = 0f;
        rb2d.freezeRotation = true;
    }

    void FixedUpdate()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        //rb2d.velocity = movement * speed;

        //float ideal_dir = rb2d.rotation;
        //if (Math.Abs(moveHorizontal) > turnthres || Math.Abs(moveVertical) > turnthres)
        //{
        //    ideal_dir = Mathf.Atan2(-moveHorizontal, moveVertical) * Mathf.Rad2Deg;
        //}

        //    rb2d.rotation = ideal_dir;

    }
}