using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public AudioClip coin;
    public int value;
    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioManager.instance.PlaySingle(coin);
            FindObjectOfType<PlayerStats>().CollectionCoins(value);
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}