using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterAI : MonoBehaviour
{
    public float retreatdistance;
    private float timeBettweenshots;
    public float starttimeBettweenshots;
    public float speedchasing;
    public float speedRetreating;
    public float Stoppingdistance;
    public float health;
    public float startinghealth;

    public GameObject proj;
    public Transform player;

    public SpriteRenderer sr;
    public Rigidbody2D rbEnemy;
    public BoxCollider2D col;
    public Animator enemy;

    private bool CanMove = true;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = startinghealth;
        sr = GetComponent<SpriteRenderer>();
        rbEnemy = GetComponent<Rigidbody2D>();
        enemy = GetComponent<Animator>();

    }
    void Update()
    {
        Vector2 chase = player.transform.position - enemy.transform.position;
        Vector2 normalChase = chase.normalized;

            Chase(normalChase);
        


        if (timeBettweenshots <= 0)
        {
            Instantiate(proj, transform.position, Quaternion.identity);
            timeBettweenshots = starttimeBettweenshots;

        }
        else
        {
            timeBettweenshots -= Time.deltaTime;
        }
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if(rbEnemy.velocity.x > 0)
        {
            sr.flipX = true;
        }
        else if(rbEnemy.velocity.x < 0)
        {
            sr.flipX = false;
        }
    }

    public void takedamage(int damage)
    {
        health -= damage;
        Debug.Log(health);
        CanMove = false;

        StartCoroutine(DamageTake());
    }

    void Chase(Vector2 move)
    {

        rbEnemy.velocity = move * speedchasing;
        enemy.SetBool("IsWalking", true);
        if (Vector2.Distance(transform.position, player.position) < Stoppingdistance)
        {
            rbEnemy.velocity = move * 0;
            enemy.SetBool("IsWalking", false);

        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CollisionMap")
        {
            col.isTrigger = true;

        }
        else
        {
            col.isTrigger = false;
        }
    }

    IEnumerator DamageTake()
    {
        Debug.Log("courotine damage");
        enemy.SetTrigger("Damage");
        yield return new WaitForSeconds(.5f);

    }
}
