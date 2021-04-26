using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartFlashing : MonoBehaviour
{
    public float moveSpeed;
    public float maxX = .5f;
    public float maxY = .5f;
    public float minX = 0.4f;
    public float minY = 0.4f;
    public Image im;

    // Start is called before the first frame update
    void Start()
    {
        im = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        float rangeX = maxX - minX;
        float rangeY = maxY - minY;
        transform.localScale = new Vector2 ( minX + Mathf.PingPong(Time.time * moveSpeed, rangeX),minY + Mathf.PingPong(Time.time * moveSpeed, rangeY));
    }
}
