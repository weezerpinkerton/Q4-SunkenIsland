using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float MoveSpeed;
    private Rigidbody2D rb;
    private Animator an;
    bool IsWalking;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        an = GetComponent<Animator>();

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

    }
}
