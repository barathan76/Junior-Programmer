using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public bool isOnGround;
    public float gravityModifier;
    public float jumpForce;
    private AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    public bool gameOver;
    private AudioSource backGroundMusic;
    public Animator playerAnimator;
    public ParticleSystem dirtParticle;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        backGroundMusic = GameObject.Find("Main Camera").GetComponent<Camera>().GetComponent<AudioSource>();
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnimator.SetTrigger("Jump_trig");
            audioSource.PlayOneShot(jumpSound, 1f);
            dirtParticle.Stop();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over");
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);
            audioSource.PlayOneShot(crashSound, 1f);
            backGroundMusic.Stop();
            dirtParticle.Stop();
            explosionParticle.Play();
        }
    }
}
