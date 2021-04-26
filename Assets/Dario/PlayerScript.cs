using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float MoveSpeed;
    private Rigidbody2D rb;
    private Animator an;
    private SpriteRenderer sr;
    bool IsWalking;
    public int playerHealth = 3;
    public Image h1;
    public Image h2;
    public Image h3;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();

        h1.color = Color.red;
        h2.color = Color.red;
        h3.color = Color.red;

        playerHealth = 3;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed, Input.GetAxis("Vertical") * MoveSpeed);
        if (rb.velocity != new Vector2(0, 0))
        {
            IsWalking = true;
            an.SetBool("IsWalking", true);
        }
        else
        {
            IsWalking = false;
            an.SetBool("IsWalking", false);

        }

        if (rb.velocity.x > 0)
        {
            sr.flipX = true;
        }
        else if (rb.velocity.x < 0)
        {
            sr.flipX = false;
        }

        if (playerHealth <= 0)
        {
            SceneManager.LoadScene("DeathScreen");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ouch")
        {
            PlayerDamage(1);
        }
    }

    void PlayerDamage(int damage)
    {
        playerHealth -= damage;
        if (playerHealth == 2) h1.color = Color.black;
        if (playerHealth == 1) h2.color = Color.black;
        if (playerHealth == 0) h3.color = Color.black;

    }

}
