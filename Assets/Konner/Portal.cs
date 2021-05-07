using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    private Transform desination;

    public bool isOrange;

    private void Start()
    {
        if (isOrange == false) ;
        {
            desination = GameObject.FindGameObjectsWithTag("Portal").GetComponent<Transform>();
        }
        else
        {
            desination = GameObject.FindGameObjectsWithTag("Portal").GetComponent<Transform>();
        }
       
        void OnTriggerEnter2D(Collider2D other)
        {
            other.transofrm.position = new Vector2(desination.position.x, desination.position.y);
        }
    }
}
