using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public float top_boundary = 25;
    public float Lower_boundary = -10;
    public int Animal_passed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < Lower_boundary)
        {
            Destroy(gameObject);
        }else if(transform.position.z > top_boundary)
        {
            Destroy(gameObject);
            Animal_passed++;
        }
    }
}
