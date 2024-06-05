using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DraculaController : MonoBehaviour
{
    public int health = 60;
    public int damage = 3;
    public Slider DraculaUI;

    public Transform firepoint;
    public GameObject bullet;

    public float HorizontalSpeed;
    public float VerticalSpeed;
    public float amplitude;
    private Vector3 tempPosition;
    private Player player;
    public AudioClip draculasound;

    float firerate, nextfire;

    void Start()
    {
        tempPosition = transform.position;

        firerate = 1f;
        nextfire = Time.time;
    }

    // Update is called once per frame

    void FixedUpdate()
    {
        tempPosition.x += HorizontalSpeed;
        tempPosition.y += Mathf.Sin(Time.realtimeSinceStartup * VerticalSpeed) * amplitude;
        transform.position = tempPosition;
    }
    void Update()
    {
        FindObjectOfType<DraculaFlip>().LookAtPlayer();
        CheckIfTimeToFire();
        DraculaUI.value = health;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerStats>().TakeDamage(damage);
        }


    }
    public void TakeDamage(int damage)
    {
            this.health = this.health - damage;

                if (this.health < 0f)
                {
                    this.health = 0;
                }
               
                else if (this.health == 0)
                {
                    Debug.Log("Victory!");
                    Destroy(this.gameObject);
            AudioManager.instance.PlaySingle(draculasound);
            NavigationController.instance.GoToFinalScene();


        }
        Debug.Log("Dracula Health:" + this.health.ToString());

    }

    public void Shoot()
    {
        Instantiate(bullet, firepoint.position, firepoint.rotation);
    }
    void CheckIfTimeToFire()
    {
        if (Time.time > nextfire)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            nextfire = Time.time + firerate;
        }
    }
}
        
   