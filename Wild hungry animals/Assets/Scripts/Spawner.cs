using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] Animal;
    private float SpawnRangeX = 20;
    private float SpawnPosZ = 20;

    private float Start_delay = 2;
    private float Interval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimal", Start_delay, Interval);  // Can call a function repeteadly.
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnRandomAnimal()
    {
        int animal_index = Random.Range(0, Animal.Length);
        Vector3 SpawnPos = new Vector3(Random.Range(-SpawnRangeX, SpawnRangeX), 0, SpawnPosZ);
        Instantiate(Animal[animal_index], SpawnPos, Animal[animal_index].transform.rotation);
    }
}
