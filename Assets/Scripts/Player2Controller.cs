using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Player2Controller : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody2D rb2d;
    private int count;
    public float turnthres = 0.25f;
    public GameObject Player1;
    public GameObject Tether2;
    public GameObject background;




    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        rb2d.rotation = 0f;
        rb2d.freezeRotation = true;
    }

    void FixedUpdate()
    {
        float moveHorizontal2 = 0.0f;
        float moveVertical2 = 0.0f;

        if (Input.GetKey(KeyCode.A)) { moveHorizontal2 = -1.0f; }
        else if (Input.GetKey(KeyCode.D)) { moveHorizontal2 = 1.0f; }
        
        if (Input.GetKey(KeyCode.W)) { moveVertical2 = 1.0f; }
        else if (Input.GetKey(KeyCode.S)) { moveVertical2 = -1.0f; }


        Vector2 movement = new Vector2(moveHorizontal2, moveVertical2);
        rb2d.velocity = movement * speed;


        float ideal_dir = rb2d.rotation;
        if (Math.Abs(moveHorizontal2) > turnthres || Math.Abs(moveVertical2) > turnthres)
        {
            ideal_dir = Mathf.Atan2(-moveHorizontal2, moveVertical2) * Mathf.Rad2Deg;
        }

        rb2d.rotation = ideal_dir;

        float tether_len = background.GetComponent<BackgroundInfo>().tether_length;
        Vector3 poffset = Player1.transform.position - transform.position;
        if (poffset.sqrMagnitude > tether_len) { Tether2.SetActive(true); }
        else { Tether2.SetActive(false); }

    }
}