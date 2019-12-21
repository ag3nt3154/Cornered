 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mana_controller : MonoBehaviour
{
    private GameObject player;
    private float spawntime;
    private GameObject background;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawntime = Time.time;
        background = GameObject.FindGameObjectWithTag("Background");
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody2D Manaitem = GetComponent<Rigidbody2D>();
        Manaitem.rotation = Manaitem.rotation + 5;
        if (Time.time - spawntime > 20)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player1") || other.gameObject.CompareTag("Player2"))
        {
            Destroy(gameObject);
            background.GetComponent<BackgroundInfo>().energy = background.GetComponent<BackgroundInfo>().energy + 1;
        }

    }
}
