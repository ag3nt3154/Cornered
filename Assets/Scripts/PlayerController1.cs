using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayerController1 : MonoBehaviour
{
    public Sprite hurtSprite1;
    public Sprite okSprite1;
    public float speed = 10.0f;
    public float turnthres = 0.25f;
    private Rigidbody2D rb2d;
    private int count;
    public GameObject Player2;
    public GameObject Tether1;
    public GameObject background;

    private float Timer = 1f;



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
        float moveHorizontal = 0.0f;
        float moveVertical = 0.0f;
        if (Input.GetKey(KeyCode.LeftArrow)) { moveHorizontal = -1.0f; }
        else if (Input.GetKey(KeyCode.RightArrow)) { moveHorizontal = 1.0f; }

        if (Input.GetKey(KeyCode.UpArrow)) { moveVertical = 1.0f; }
        else if (Input.GetKey(KeyCode.DownArrow)) { moveVertical = -1.0f; }

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.velocity = movement * speed;



        float ideal_dir = rb2d.rotation;

        if (Math.Abs(moveHorizontal) > turnthres || Math.Abs(moveVertical) > turnthres)
        {
            ideal_dir = Mathf.Atan2(-moveHorizontal, moveVertical) * Mathf.Rad2Deg;
        }

        rb2d.rotation = ideal_dir;

        float tether_len = background.GetComponent<BackgroundInfo>().tether_length;
        Vector3 poffset = Player2.transform.position - transform.position;
        if (poffset.sqrMagnitude > tether_len) { Tether1.SetActive(true); }
        else { Tether1.SetActive(false); }



    }
    private IEnumerator changeSprite()
    {
        yield return new WaitForSeconds(0.5f);
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("EnemyBullet"))
        {
            GetComponent<SpriteRenderer>().sprite = hurtSprite1;
            Timer -= Time.deltaTime;
            if (Timer <= 0f)
            {
                GetComponent<SpriteRenderer>().sprite = okSprite1;
                Timer = 1f;
            }
        }
    }

    }