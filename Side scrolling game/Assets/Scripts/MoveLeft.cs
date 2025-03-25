using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed = 20;
    private PlayerMovement PlayerMovementScript; // Got the class from VS
    public float left_bound = -15;
    // Start is called before the first frame update
    void Start()
    {
        PlayerMovementScript = GameObject.Find("Player").GetComponent<PlayerMovement>();
        // We specify here which gameobject script we want this to be as same class can be attached to multiple gameobjects.
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerMovementScript.GameOver == false)       // This will stop background and obstacles from moving when game is over.
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if(gameObject.CompareTag("obstacles") && transform.position.x < left_bound)  // When script is applied to object with tag obstacles and its x position is less than boundary then the obstacle will delete.
        {
            Destroy(gameObject);
        }
    }
}
