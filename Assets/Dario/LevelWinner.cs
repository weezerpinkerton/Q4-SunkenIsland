using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelWinner : MonoBehaviour
{
    public GameObject Portal;
    public GameObject Player;
    private PlayerScript PlayerScript;
    public GameObject Spawner;
    private SpawnWavesOfEnemys SpawnerScript;
    


    // Start is called before the first frame update
    void Start()
    {
        Portal.SetActive(false);
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerScript = Player.GetComponent<PlayerScript>();
        Spawner = GameObject.FindGameObjectWithTag("Spawner");
        SpawnerScript = Spawner.GetComponent<SpawnWavesOfEnemys>();
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerScript.killCount >= SpawnerScript.Maxenemys)
        {
            Portal.SetActive(true);
        }
    }
}
