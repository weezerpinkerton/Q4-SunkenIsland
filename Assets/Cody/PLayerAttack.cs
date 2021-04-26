using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerAttack : MonoBehaviour
{
    private float timeBettweenhits;
    public float starttimeBettweenhits;
    public LayerMask WISE;
    public Transform AttackPos;
    public Transform AttackPos1;
    public Transform AttackPos2;
    public Transform AttackPos3;
    public Transform AttackPos4;
    public float attackrange;
    public float attackrange1;
    public int damage;
    //movement properties
    public float movementSpeed;

    public Rigidbody2D rbody;

    Vector2 movement;

    public void FixedUpdate()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Moving
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        // Attack
        if (timeBettweenhits <= 0)
        {
            if (Input.GetButton("Fire1"))
            {
                if (movement.x >= 0 && movement.x != 0)
                {
                    Collider2D[] enemystodamage = Physics2D.OverlapCircleAll(AttackPos1.position, attackrange, WISE);
                    for (int i = 0; i < enemystodamage.Length; i++)
                    {
                        enemystodamage[i].GetComponent<ShooterAI>().takedamage(damage);
                    }
                }
                if (movement.x <= 0 && movement.x != 0)
                {
                    Collider2D[] enemystodamage = Physics2D.OverlapCircleAll(AttackPos.position, attackrange, WISE);
                    for (int i = 0; i < enemystodamage.Length; i++)
                    {
                        enemystodamage[i].GetComponent<ShooterAI>().takedamage(damage);
                    }
                }
                if (movement.y >= 0 && movement.y != 0)
                {
                    Collider2D[] enemystodamage = Physics2D.OverlapCircleAll(AttackPos2.position, attackrange, WISE);
                    for (int i = 0; i < enemystodamage.Length; i++)
                    {
                        enemystodamage[i].GetComponent<ShooterAI>().takedamage(damage);
                    }
                }
                if (movement.y <= 0 && movement.y != 0)
                {
                    Collider2D[] enemystodamage = Physics2D.OverlapCircleAll(AttackPos3.position, attackrange, WISE);
                    for (int i = 0; i < enemystodamage.Length; i++)
                    {
                        enemystodamage[i].GetComponent<ShooterAI>().takedamage(damage);
                    }
                }
                if (movement.x == 0 && movement.x == 0)
                {
                    Collider2D[] enemystodamage = Physics2D.OverlapCircleAll(AttackPos4.position, attackrange1, WISE);
                    for (int i = 0; i < enemystodamage.Length; i++)
                    {
                        enemystodamage[i].GetComponent<ShooterAI>().takedamage(damage);
                    }
                }

                timeBettweenhits = starttimeBettweenhits;
            }

        }
        else
        {
            timeBettweenhits -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        if (movement.y >= 0&& movement.y != 0)
        {
            Gizmos.DrawWireSphere(AttackPos3.position, attackrange);
        }
        if (movement.y <= 0&& movement.y != 0)
        {
            Gizmos.DrawWireSphere(AttackPos2.position, attackrange);
        }
        if (movement.x >= 0&&movement.x != 0)
        {
            Gizmos.DrawWireSphere(AttackPos1.position, attackrange);
        }
        if (movement.x <= 0 && movement.x != 0)
        {
            Gizmos.DrawWireSphere(AttackPos.position, attackrange);
        }
        if (movement.x == 0 && movement.y == 0)
        {
            Gizmos.DrawWireSphere(AttackPos4.position, attackrange1);
        }

    }
}
