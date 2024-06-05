using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour {
    public int Value = 1;
    float timedestroy = 1;
    public float speed;
    public AudioClip explosion;
    public AudioClip vampdeath;
    public AudioClip gobdeath;
    private Player Player;
	// Use this for initialization
	void Start () {
		Player = FindObjectOfType<Player>();
        if (Player.transform.localScale.x < 0)
        {
			speed = -speed;
        }
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        Destroy(gameObject, timedestroy);

	}
	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            AudioManager.instance.PlaySingle(gobdeath);
            Destroy(other.gameObject);
            Destroy(gameObject);
            FindObjectOfType<PlayerStats>().numberOfEneme(Value);
        }
        if (other.tag == "Enemy2")
        {
            AudioManager.instance.PlaySingle(vampdeath);
            Destroy(other.gameObject);
            Destroy(gameObject);
            FindObjectOfType<PlayerStats>().numberOfEneme(Value);
        }
        if (other.tag == "Dracula")
        {
            
            FindObjectOfType<DraculaController>().TakeDamage(1);
            FindObjectOfType<PlayerStats>().numberOfEneme(1);
            Destroy(gameObject);
        }

        if (other.tag == "tnt")
        {
            FindObjectOfType<Explode>().explode();
            Destroy(gameObject);
            AudioManager.instance.PlaySingle(explosion);
        }
        if (other.tag == "enemyboss")
        {
            FindObjectOfType<igor>().TakeDamage(6);
            Destroy(gameObject);
           
        }


    }







}
