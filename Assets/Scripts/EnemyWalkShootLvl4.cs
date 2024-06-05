using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalkShootLvl4 : EnemyController
{
    public Transform firePoint;
    public GameObject bullet;
    float firerate;
    float nextfire;
    public Transform player;
    // Use this for initialization
    void Start()
    {
        firerate = 2f;
        nextfire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimeToFire();
        if(player.position.x > transform.position.x && transform.localScale.x < 0 || player.position.x < transform.position.x && transform.localScale.x > 0)
        {
            Flip();
        }
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
        if (collider.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            Flip();

        }

    }
    void Flip()
    {

    }
}
