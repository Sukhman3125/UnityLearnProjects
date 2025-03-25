using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody Rigidbody;
    private Animator anim;
    private AudioSource audioSource;
    public float jump_force = 5f;
    public float gravityModifier = 1;
    private bool isonground = true;
    public bool GameOver = false;
    private bool double_jump_available = false;

    public ParticleSystem explosion;
    public ParticleSystem DirtSplash;

    public AudioSource BGMusic;
    public AudioClip jump;
    public AudioClip death;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;   // Now we can change the gracity through a slider
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isonground && !GameOver)
        {
            isonground = false;
            Rigidbody.AddForce(Vector3.up * jump_force, ForceMode.Impulse);
            anim.SetTrigger("Jump_trig");
            DirtSplash.Stop();
            double_jump_available = true;
        }
        if (Input.GetButtonDown("Jump") && transform.position.y >1f && Rigidbody.linearVelocity.y>0 && !GameOver && double_jump_available)
        {
            double_jump_available = false;
            Rigidbody.AddForce(Vector3.up * jump_force * 75 /100, ForceMode.Impulse);
            anim.SetTrigger("Jump_trig");
            audioSource.PlayOneShot(jump, 1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ground") && !GameOver)
        {
            isonground = true;
            DirtSplash.Play();
        }else if (collision.gameObject.CompareTag("obstacles"))
        {
            GameOver = true;
            explosion.Play();
            DirtSplash.Stop();
            BGMusic.Stop();
            audioSource.PlayOneShot(death, 1f);
            anim.SetBool("Death_b", true);
            anim.SetInteger("DeathType_int", 1);

        }
    }
    IEnumerator coroutine(float time_delay)               
    {
        yield return new WaitForSeconds(time_delay);     
    }
}
