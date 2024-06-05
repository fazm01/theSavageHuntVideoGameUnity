using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdrenalineBullet : MonoBehaviour
{

    public float speed;
    private Player Player;
    public AudioClip explosion;
    public AudioClip vampdeath;
    public AudioClip gobdeath;
    // Use this for initialization
    void Start()
    {
        Player = FindObjectOfType<Player>();
        if (Player.transform.localScale.x < 0)
        {
            speed = -speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        

    }
    void OnTriggerEnter2D(Collider2D tagg)
    {
        if (tagg.tag == "Enemy")
        {
            AudioManager.instance.PlaySingle(gobdeath);
            Destroy(tagg.gameObject);
            
        }
        if (tagg.tag == "Enemy2")
        {
            AudioManager.instance.PlaySingle(vampdeath);
            Destroy(tagg.gameObject);

        }
        if (tagg.tag == "Dracula")
        {

            FindObjectOfType<DraculaController>().TakeDamage(5);

        }
        if (tagg.tag == "Wall")
        {

            Destroy(gameObject);
        }
        if (tagg.tag == "tnt")
        {
            FindObjectOfType<Explode>().explode();
            Destroy(gameObject);
            AudioManager.instance.PlaySingle(explosion);
        }
    }
}