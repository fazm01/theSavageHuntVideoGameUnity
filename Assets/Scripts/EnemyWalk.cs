﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : EnemyController {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate()
    {
        if (this.isFacingRight == true)
        {
			this.GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
        }
        else
        {
			this.GetComponent<Rigidbody2D>().velocity= this.GetComponent<Rigidbody2D>().velocity = new Vector2(-maxSpeed, this.GetComponent<Rigidbody2D>().velocity.y);
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
        else if (collider.tag == "tnt")
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
