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
    public Sprite fullHeart;
    public Sprite emptyHeart;
    public Animator sceneStuff;
    public int killCount = 0;
    public GameObject[] hearts = new GameObject[7];

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        playerHealth = maxHealth;

        for (int i = 0; i <= 6; i++)
        {
            hearts[i].GetComponent<Image>().sprite = fullHeart;
        }
    }
  
    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed, Input.GetAxis("Vertical") * MoveSpeed);
        if (rb.velocity != new Vector2(0, 0))
        {
           
            an.SetBool("IsWalking", true);
        }
        else
        {
         
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
            StartCoroutine(PlayerDeath());
        }
        if (playerHealth > maxHealth)
        {
            playerHealth = maxHealth;
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
            if (playerHealth < maxHealth)
            {
                PlayerHeal(1);
                Destroy(collision.gameObject);
            }
        }
        if (collision.tag == "HeartContainer")
        {
            if (maxHealth < 7)
            {
                maxHealth++;
                PlayerHeal(1);
                Destroy(collision.gameObject);
            }
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
        if (maxHealth == 5)
        {
            hearts[5].SetActive(false);
            hearts[6].SetActive(false);

        }

        if (maxHealth == 6)
        {
            hearts[5].SetActive(true);

        }
        if (maxHealth == 7)
        {
            hearts[6].SetActive(true);


        }

        for (int i = 0; i < playerHealth; i++)
        {
            hearts[i].GetComponent<Image>().sprite = fullHeart;
        }

        for (int i = 0; i < maxHealth - playerHealth; i++)
        {
            hearts[i].GetComponent<Image>().sprite = emptyHeart;
        }

    }

    IEnumerator PlayerDeath()
    {
        
        sceneStuff.SetTrigger("Start");
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("DeathScreen");
    }

}

       


