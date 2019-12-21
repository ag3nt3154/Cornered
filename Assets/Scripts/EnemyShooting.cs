using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
	public Transform firePoint;
	public GameObject bulletPrefab;
	public float bulletForce = 20f;
    private float Timer = 2f;
    // Start is called before the first frame update

    // Update is called once per frame
    void LateUpdate()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0f)
        {
            Shoot();
            Timer = 2f;
        }
    }

    void Shoot()
	{
		GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		Rigidbody2D rigidBullet = bullet.GetComponent<Rigidbody2D>();
		rigidBullet.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
	}


}
