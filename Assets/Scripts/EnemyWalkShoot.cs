using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkShoot : EnemyController
{
    public Transform firePoint;
    public GameObject bullet;
    float firerate;
    float nextfire;
    // Use this for initialization
    void Start()
    {
        firerate = 5f;
        nextfire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimeToFire();
    }
    void CheckIfTimeToFire()
    {
        if (Time.time > nextfire)
        {
            Instantiate(bullet, firePoint.position, firePoint.rotation);
            nextfire = Time.time + firerate;
        }

    }
    void FixedUpdate()
    {
        if (this.isFacingRight == true)
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
            this.GetComponent<Rigidbody2D>().velocity = this.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Wall")
        {
            Flip();
        }
        else if (collider.tag == "Enemy")
        {
            Flip();
        }
        else if (collider.tag == "Enemy2")
        {
            Flip();
        }
        if (collider.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            Flip();

        }

    }

}
