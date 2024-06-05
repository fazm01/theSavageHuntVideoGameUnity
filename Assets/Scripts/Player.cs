using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public int painkillersvalue;
    public int value;
    public bool isFacingRight;
    public KeyCode Spacebar;
    public KeyCode L;
    public KeyCode R;
    public KeyCode d;
    public KeyCode s;
    public KeyCode q;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    private Animator anim;
    public Transform firePoint;
    public GameObject bullet;
    public AudioClip ShotgunClick;
    public AudioClip gunShot;

    // Use this for initialization
    void Start()
    {
        isFacingRight = true;
        anim = GetComponent<Animator>();
    }
    void flip()
    {
        transform.localScale = new Vector3(-(transform.localScale.x), transform.localScale.y, transform.localScale.z);
    }
    void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
    }


    // Update is called once per frame

    void Update()
    {

        if (Input.GetKeyDown(d))
        {
            FindObjectOfType<PlayerStats>().Takepainkillers(painkillersvalue);

        }
        if (Input.GetKeyDown(d))
        {

            FindObjectOfType<PlayerStats>().Takenpainkillers(painkillersvalue);

        }
        if (Input.GetKeyDown(q))
        {
            AudioManager.instance.PlaySingle(ShotgunClick);
            FindObjectOfType<PlayerStats>().useAdrenline(value);
            anim.Play("shootgun");
        }


        if (Input.GetKeyDown(s))
        {
            AudioManager.instance.PlaySingle(gunShot);
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
        if (Input.GetKeyDown(s))
        {
            anim.Play("shooting");
        }


        anim.SetFloat("Speed", Mathf.Abs(GetComponent<Rigidbody2D>().velocity.x));
        if (Input.GetKeyDown(Spacebar) && grounded)
        {
            Jump();
        }
        anim.SetBool("Grounded", grounded);
        if (Input.GetKey(L))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (isFacingRight)
            {
                flip();
                isFacingRight = false;
            }
        }
        if (Input.GetKey(R))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            if (!isFacingRight)
            {
                flip();
                isFacingRight = true;
            }
        }
    }
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "tnt")
        {

            FindObjectOfType<Explode>().explode();
            FindObjectOfType<PlayerStats>().TakeDamage(6);
        }

    }
}