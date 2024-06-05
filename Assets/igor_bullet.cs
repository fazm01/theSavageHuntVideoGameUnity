using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class igor_bullet : MonoBehaviour
{

    // Start is called before the first frame update


    float movespeed = 7f;

    Rigidbody2D rb;

    Player target;
    Vector2 moveDirection;

    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindObjectOfType<Player>();
        moveDirection = (target.transform.position - transform.position).normalized * movespeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);

        //player = FindObjectOfType<Player>();

        //if(player.transform.localScale.x < 0)
        //{
        //    speed = -speed;
        //    transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        //}
    }

    // Update is called once per frame
    void Update()
    {

        //GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(3);




        }
    }


}
