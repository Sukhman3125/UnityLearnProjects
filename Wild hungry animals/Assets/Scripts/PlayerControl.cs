using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float HorizontalInput;
    public float boundary_x = 13f;
    public float speed = 1f;

    public GameObject food_prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * speed * HorizontalInput);
        if (transform.position.x>=boundary_x)
        {
            transform.position = new Vector3(boundary_x, transform.position.y, transform.position.z);
        }
        if (transform.position.x <= -boundary_x)
        {
            transform.position = new Vector3(-boundary_x, transform.position.y, transform.position.z);
        }

        if (Input.GetButtonDown("Jump"))
        {
            Instantiate(food_prefab, transform.position, food_prefab.transform.rotation);
        }
    }
}
