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
    public int playerHealth;
    public int maxHealth = 5;
    private GameObject[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public GameObject heartPrefab;
    public Transform heartContainer;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        playerHealth = maxHealth;

        for (int i = 0; i <= maxHealth; i++)
        {
            hearts[i] = Instantiate(heartPrefab, heartContainer);
        }
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
        if (collision.tag == "HealthPotion")
        {
            PlayerHeal(1);
            Destroy(collision.gameObject);
        }
    }

    void PlayerDamage(int damage)
    {
        playerHealth -= damage;
        HealthChecker();
    }

    void PlayerHeal(int heal)
    {
        playerHealth += heal;
        HealthChecker();
    }

    void HealthChecker()
    {
        for (int i = 0; i <= playerHealth; i++)
        {
            Image hi = hearts[i].GetComponent<Image>();
            hi.sprite = fullHeart;
        }
        if (playerHealth < maxHealth)
        {
            for (int i = playerHealth; i < maxHealth; i++)
            {
                Image hi = hearts[i].GetComponent<Image>();
                hi.sprite = emptyHeart;
            }

        }
    }
}

       


