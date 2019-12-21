using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting2 : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    // Start is called before the first frame update

    // Update is called once per frame
    void FixedUpdate()
    {

        if (Input.GetKeyDown(KeyCode.F))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rigidBullet = bullet.GetComponent<Rigidbody2D>();
        rigidBullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }




}