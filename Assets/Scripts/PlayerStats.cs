using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public int health = 6;
    public int lives = 1;
    private float flickerTime = 0f;
    public float flickerDuration = 0.1f;
    private SpriteRenderer spriteRenderer;
    public bool isImmune = false;
    private float immunityTime = 0f;
    public float immunityDuration = 1.5f;
    public int coinsCollected;
    public int painkillersCollected;
    public Text scoreUI;
    public Text painkillerUI;
    public Slider healthUI;
    public Slider adrenalineUI;
    public int enemeiskilled;
    public GameObject Firebullet;
    public Transform firePoint2;
    public AudioClip shotgun;
    public AudioClip TakePainkiller;
    
    // Use this for initialization
    void Start()
    {

        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
    }

    public void numberOfEneme(int Value)
    {
        enemeiskilled = enemeiskilled + Value;
    }

    public void CollectionCoins(int coinValue)
    {
        coinsCollected = coinsCollected + coinValue;


    }

    public void Collectionpainkillers(int painkillersValue)
    {
        painkillersCollected = painkillersCollected + painkillersValue;
    }

    public void Takenpainkillers(int painkillersValue)
    {
        if (this.painkillersCollected > 0f && this.health < 6f)
        {
            AudioManager.instance.PlaySingle(TakePainkiller);
            painkillersCollected = painkillersCollected - painkillersValue;
        }
    }
    public void useAdrenline(int value)
    {
        if (this.enemeiskilled >= 5f)
        {
            AudioManager.instance.PlaySingle(shotgun);
            Instantiate(Firebullet, firePoint2.position, firePoint2.rotation);
            this.enemeiskilled = this.enemeiskilled - 5;

        }
    }



    void SpriteFlicker()
    {
        if (this.flickerTime < this.flickerDuration)
        {
            this.flickerTime = this.flickerTime + Time.deltaTime;
        }
        else if (this.flickerTime >= this.flickerDuration)
        {
            spriteRenderer.enabled = !(spriteRenderer.enabled);
            this.flickerTime = 0;
        }
    }
    public void TakeDamage(int damage)
    {
        {
            if (this.isImmune == false)
            {
                this.health = this.health - damage;
                if (this.health < 0f)
                {
                    this.health = 0;
                }
                if (this.lives > 0f && this.health == 0f)
                {
                    FindObjectOfType<LevelManager>().RespawnPlayer();
                    this.health = 6;
                    this.lives--;
                }
                else if (this.lives == 0 && this.health == 0)
                {
                    Debug.Log("Gameover");
                    Destroy(this.gameObject);
                    Scene currentScene = SceneManager.GetActiveScene();
                    if ((currentScene.name == "Level1Scene1") || (currentScene.name == "Level1Scene2"))
                        {
                        NavigationController.instance.GameOver1();
                    }
                    if ((currentScene.name == "Level2Scene1") || (currentScene.name == "Level2Scene2"))
                        {
                        NavigationController.instance.GameOver2();
                    }
                    if (currentScene.name == "Level3")
                        {
                        NavigationController.instance.GameOver3();
                    }
                    if ((currentScene.name == "Level4Scene1") || (currentScene.name == "Level4Scene2"))
                        {
                        NavigationController.instance.GameOver4();
                    }


                }
                Debug.Log("Player Health:" + this.health.ToString());
                Debug.Log("Player Lives:" + this.lives.ToString());
            }
        }
        PlayHitReaction();
    }
    void PlayHitReaction()
    {
        this.isImmune = true;
        this.immunityTime = 0f;
    }



    public void Takepainkillers(int value)
    {
        {
            if (this.painkillersCollected > 0f && this.health < 6f)
            {
                this.health = this.health + value;
                if (this.health > 6f)
                {
                    this.health = 6;
                }



                Debug.Log("Player Health:" + this.health.ToString());
                Debug.Log("Player Lives:" + this.lives.ToString());
            }
        }

    }


    // Update is called once per frame
    void Update()
    {
        healthUI.value = health;
        scoreUI.text = "" + coinsCollected;
        adrenalineUI.value = enemeiskilled;
        painkillerUI.text = "" + painkillersCollected;
        if (this.isImmune == true)
        {
            SpriteFlicker();
            immunityTime = immunityTime + Time.deltaTime;
            if (immunityTime >= immunityDuration)
            {
                this.isImmune = false;
                this.spriteRenderer.enabled = true;
            }
        }


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Key" && coinsCollected >= 32)
        {
            NavigationController.instance.GoToLevel1Scene2();
        }
        if (other.tag == "Captives" && coinsCollected >=32)
        {
            NavigationController.instance.GoToLevel2();
        }
        if (other.tag == "Lvl2")
        {
            NavigationController.instance.GoToIgorBossFight();
        }
    }

}