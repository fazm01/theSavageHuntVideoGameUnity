using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    
    public float fieldofimpact;
    public float force;
    public LayerMask LayerToHit;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

   
    public void explode()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldofimpact, LayerToHit);
        foreach(Collider2D obj in objects)
        {

            Vector2 direction =obj.transform.position-transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(direction*force);

        }

        Destroy(gameObject);
        

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldofimpact);


    }
   
    
}
