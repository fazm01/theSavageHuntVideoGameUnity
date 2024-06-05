using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class painkillers : MonoBehaviour
{
    public AudioClip Painkiller;
    public int value;
    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioManager.instance.PlaySingle(Painkiller);
            FindObjectOfType<PlayerStats>().Collectionpainkillers(value);
            Destroy(this.gameObject);
        }
    }
    
}
