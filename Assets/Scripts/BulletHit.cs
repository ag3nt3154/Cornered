using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHit : MonoBehaviour
{
    private GameObject player1;
    private GameObject player2;
    private GameObject background;

    // Start is called before the first frame update
    // public GameObject hitEffect;
    void Start()
    {
        background = GameObject.FindGameObjectWithTag("Background");
        player1 = GameObject.FindGameObjectWithTag("Player1");
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }
    void OnCollisionEnter2D(Collision2D collision)
	{
        // GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        // Destroy(effect, 5f);
        Destroy(gameObject);
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        //if (other.gameObject.CompareTag("Enemy"))
        //{
        //    Destroy(gameObject);
        //}


        //if (other.gameObject.CompareTag("Manadrop"))
        //{
        //    Destroy(gameObject);
        //}
        if ((other.gameObject.CompareTag("Player1")|| other.gameObject.CompareTag("Player2")) && gameObject.CompareTag("EnemyBullet"))
        {
            background.GetComponent<BackgroundInfo>().energy = background.GetComponent<BackgroundInfo>().energy - 1;
            Destroy(gameObject);
        }

        //if ((other.gameObject.CompareTag("Player1") && gameObject.CompareTag("EnemyBullet"))
        //{
            
        //}

        //if ((other.gameObject.CompareTag("Player2")) && gameObject.CompareTag("EnemyBullet"))
        //{
            
        //}
    }

}
