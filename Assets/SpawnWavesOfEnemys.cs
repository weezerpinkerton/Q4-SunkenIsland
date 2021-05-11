using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnWavesOfEnemys : MonoBehaviour
{
    public GameObject Enemys;
    public int xpos;
    public int ypos;

    void Update()
    {
        StartCoroutine(enemyDrop());

    }

    IEnumerator enemyDrop()
    {
        xpos = Random.Range(-50, 50);
        ypos = Random.Range(-50, 50);
        Instantiate(Enemys, new Vector2(xpos, ypos), Quaternion.identity);

        yield return new WaitForSeconds(5f);
    }
}