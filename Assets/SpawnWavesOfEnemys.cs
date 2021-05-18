using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class SpawnWavesOfEnemys : MonoBehaviour
{
    public int RMS;
    public GameObject Enemys;
    public int enemyCount;
    public int Maxenemys = 5;

    public Transform SpawnPoint0;
    public Transform SpawnPoint1;
    public Transform SpawnPoint2;
    public Transform SpawnPoint3;
    public Transform SpawnPoint4;
    public Transform SpawnPoint5;
    public Transform SpawnPoint6;
    public Transform SpawnPoint7;
    public Transform SpawnPoint8;
    public Transform SpawnPoint9;

    public float timestart;
    public float timego;


    void Start()
    {
        SpawnPoint0 = transform.GetComponent<Transform>();
        SpawnPoint1 = transform.GetComponent<Transform>();
        SpawnPoint2 = transform.GetComponent<Transform>();
        SpawnPoint3 = transform.GetComponent<Transform>();
        SpawnPoint4 = transform.GetComponent<Transform>();
        SpawnPoint5 = transform.GetComponent<Transform>();
        SpawnPoint6 = transform.GetComponent<Transform>();
        SpawnPoint7 = transform.GetComponent<Transform>();
        SpawnPoint8 = transform.GetComponent<Transform>();
        SpawnPoint9 = transform.GetComponent<Transform>();
        StartCoroutine(enemyDrop());
    }
    IEnumerator enemyDrop()
    {
        while(enemyCount < Maxenemys)
        {
            yield return new WaitForSeconds(timestart);
            RMS = Random.Range(1, 10);
            if (RMS == 1)
            {
                Instantiate(Enemys, SpawnPoint0.transform.position, Quaternion.identity);
            }
            if (RMS == 2)
            {
                Instantiate(Enemys, SpawnPoint1.transform.position, Quaternion.identity);
            }
            if (RMS == 3)
            {
                Instantiate(Enemys, SpawnPoint2.transform.position, Quaternion.identity);
            }
            if (RMS == 4)
            {
                Instantiate(Enemys, SpawnPoint3.transform.position, Quaternion.identity);
            }
            if (RMS == 5)
            {
                Instantiate(Enemys, SpawnPoint4.transform.position, Quaternion.identity);
            }
            if (RMS == 6)
            {
                Instantiate(Enemys, SpawnPoint5.transform.position, Quaternion.identity);
            }
            if (RMS == 7)
            {
                Instantiate(Enemys, SpawnPoint6.transform.position, Quaternion.identity);
            }
            if (RMS == 8)
            {
                Instantiate(Enemys, SpawnPoint7.transform.position, Quaternion.identity);
            }
            if (RMS == 9)
            {
                Instantiate(Enemys, SpawnPoint8.transform.position, Quaternion.identity);
            }
            if (RMS == 10)
            {
                Instantiate(Enemys, SpawnPoint9.transform.position, Quaternion.identity);
            }
            enemyCount+=1;

            yield return new WaitForSeconds(timego);
        }

    }
}