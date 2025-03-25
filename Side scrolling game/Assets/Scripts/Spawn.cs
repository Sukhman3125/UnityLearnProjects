using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] Obstacles;
    private Vector3 spawnpos = new Vector3(25, 0.1f, 0);
    private float startDelay = 2;
    private float Interval = 2;

    private PlayerMovement PlayerMovementScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, Interval);
        PlayerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void SpawnObstacle()
    {
        if(PlayerMovementScript.GameOver == false)        // This will stop spawning obstacles after game is over;
        {
            int rand = Random.Range(0, 4);
            Instantiate(Obstacles[rand], spawnpos, Obstacles[rand].transform.rotation);
        }
    }
}
