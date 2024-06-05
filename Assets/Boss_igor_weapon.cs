using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_igor_weapon : MonoBehaviour
{

    public int attackDamage = 2;
    public Vector3 attackOffset;
    public float attackRange = 2f;
    public LayerMask attackigor;
    public GameObject bullet;
    // Start is called before the first frame update
    public void Attack()
    {
        Vector3 pos = transform.position;
        pos += transform.right * attackOffset.x;
        pos += transform.up * attackOffset.y;

        Collider2D colInfo = Physics2D.OverlapCircle(pos, attackRange, attackigor);
        if(colInfo != null)
        {
            colInfo.GetComponent<PlayerStats>().TakeDamage(attackDamage);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
