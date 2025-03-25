using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;
    public PropellerRotate propellerrotate;

    // Start is called before the first frame update
    void Start()
    {
        propellerrotate = GameObject.FindGameObjectWithTag("Propeller").GetComponent<PropellerRotate>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        verticalInput = Input.GetAxis("Vertical");
        if (!propellerrotate.wall_collision)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput);
    }
}
