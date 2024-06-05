

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : EnemyController 
{
	public float speed;
    private EnemyWalkShoot Enemy;
	// Use this for initialization
	void Start () {
        Enemy = FindObjectOfType<EnemyWalkShoot>();
        if (Enemy.transform.localScale.x < 0)
        {
            speed = -speed;
        }



    }
	
	// Update is called once per frame
	void Update () {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);

    }

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
            

        }
    }
}
