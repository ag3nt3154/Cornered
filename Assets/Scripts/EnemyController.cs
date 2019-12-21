using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;
    private GameObject background;

    public GameObject ManaPrefab;
    private Vector3 position;
    public float speed;
    private Rigidbody2D rb2d;
    public float emoveHorizontal;
    public float emoveVertical;
    public Vector2 eposition;

    private Vector3 distance;
    private Vector3 distance1;
    private Vector3 distance2;
    private float y_pos;
    private float timenow;

    // Use this for initialization
    void Start()
    {
        background = GameObject.FindGameObjectWithTag("Background");
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.transform.position = new Vector2(Random.Range(-10.0f, 10.0f), Random.Range(-10.0f, 10.0f));
        y_pos = -15f;
        if (Random.Range(-1f, 1f) > 0)
        {
            y_pos = 15f;
        }

        rb2d.transform.position = new Vector2(Random.Range(-5.0f, 5.0f), y_pos);
        speed = 0.02f;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        
        distance1 = player1.transform.position - rb2d.transform.position;
        distance2 = player2.transform.position - rb2d.transform.position;

        if (distance1.magnitude > distance2.magnitude)
        {
            distance = distance2;
        }
        else
        {
            distance = distance1;
        }

        emoveVertical = Input.GetAxis("Vertical");
        Vector2 emovement = new Vector2(emoveHorizontal, emoveVertical);
        eposition = eposition + emovement * speed;
        rb2d.rotation = Mathf.Atan2(-distance.x, distance.y) * Mathf.Rad2Deg;
        rb2d.MovePosition(rb2d.transform.position + distance * speed / distance.magnitude);
        //rb2d.AddForce(distance/10f);
        if (Time.time - timenow > 5)
        {
            timenow = timenow + 5;
            speed = speed + 0.002f;
            if (speed > 0.05f)
            {
                speed = 0.05f;
            }
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
       if (other.gameObject.CompareTag ("Player1") || other.gameObject.CompareTag("Player2"))
        {
            // rb2d.gameObject.SetActive(false);
            // count = count + 1;
            background.GetComponent<BackgroundInfo>().energy = background.GetComponent<BackgroundInfo>().energy - 1;
            Destroy(rb2d.gameObject);
        }
        else if (other.gameObject.CompareTag("PlayerBullet"))
        {
            // rb2d.gameObject.SetActive(false);
            // count = count + 1;
            position = rb2d.position;
            Destroy(rb2d.gameObject);
            if (Random.Range(-1f, 1f) > 0)
            {
                GameObject ManaDrop = Instantiate(ManaPrefab, position, Quaternion.identity);
                Rigidbody2D ManaItem = ManaDrop.GetComponent<Rigidbody2D>();
            }

        }
    }
}
