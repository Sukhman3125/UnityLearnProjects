using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Control : MonoBehaviour
{
    public float speed = 0;
    public float back_speed = 0;
    public float turn_speed = 75.0f;
    public float forward_movement;
    public float direction_movement;

    
    public TextMeshProUGUI Speed_counter;
    void Start()
    {
        
    }
    void Update()
    {
        if (forward_movement >= 0)
        {
            Speed_counter.text = "Speed: " + ((int)speed).ToString();
        }
        else
        {
            Speed_counter.text = "Reverse Gear";
        }
        if (Input.GetButton("Vertical") && forward_movement>=0 && speed <= 150 ){
            speed += Time.deltaTime*10;
        }
        else if(Input.GetButton("Vertical") && forward_movement <= 0 && back_speed <= 10)
        {
            back_speed += Time.deltaTime * 2;
        }
        if (Input.GetButtonUp("Vertical"))
        {
            speed = 0;
            back_speed = 0;
        }
        forward_movement = Input.GetAxis("Vertical");
        direction_movement = Input.GetAxis("Horizontal");
        if(forward_movement > 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed * forward_movement);
        }
        else
        {
            transform.Translate(Vector3.forward * Time.deltaTime * back_speed * forward_movement);
        }
        transform.Rotate(Vector3.up, Time.deltaTime * direction_movement * turn_speed);
    }
}
