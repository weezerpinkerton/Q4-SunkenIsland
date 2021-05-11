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
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = startinghealth;
        sr = GetComponent<SpriteRenderer>();
        rbEnemy = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > Stoppingdistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speedchasing * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < Stoppingdistance && Vector2.Distance(transform.position, player.position) > retreatdistance)
        {
            transform.position = this.transform.position;
        }

        else if (Vector2.Distance(transform.position, player.position) < retreatdistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speedRetreating * Time.deltaTime);
        }


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
    }

    public void takedamage(int damage)
    {
        health -= damage;
        Debug.Log(health);

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
}
