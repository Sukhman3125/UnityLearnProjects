using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundRepeat : MonoBehaviour
{
    private Vector3 start_pos;
    private float point_of_repetation;
    void Start()
    {
        point_of_repetation = GetComponent<BoxCollider>().size.x / 2;     // Half of the length of the background
        start_pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < start_pos.x - point_of_repetation)
        {
            transform.position = start_pos;
        }
    }
}
