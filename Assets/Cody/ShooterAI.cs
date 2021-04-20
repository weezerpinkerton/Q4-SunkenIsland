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

    public GameObject proj;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
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
    }
}
