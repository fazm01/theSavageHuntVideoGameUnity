using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class igor : MonoBehaviour
{
    private Player player;
    public int health =50;

    
    public int lives = 1;
    public Slider healthBar;
   


    public void TakeDamage(int damage)
    {



        this.health = this.health - damage;
        if (this.health < 0f)
        {
            this.health = 0;
        }
        if (this.lives > 0f && this.health == 0f)
        {

            this.health = 6;
            this.lives--;
        }
        else if (this.lives == 0 && this.health == 0)
        {

            Destroy(this.gameObject);
            NavigationController.instance.GoToLevel3();

        }
        Debug.Log("Player Health:" + this.health.ToString());
        Debug.Log("Player Lives:" + this.lives.ToString());
    }

        // Use this for initialization
        void Start()
	{
		player = FindObjectOfType<Player>();
       
    }

    // Update is called once per frame
    
    void Update()
	{
       
        healthBar.value = health;
       
    }

   
}
