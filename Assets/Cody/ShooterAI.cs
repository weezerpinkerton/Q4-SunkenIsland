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
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        health = startinghealth;
        sr = GetComponent<SpriteRenderer>();
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

}
