
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isGrounded = true;
    public bool hasShield = false;

    public float turnSpeed = 3f;

    public int playerPoints = 0;

    private Animator animator;
    public GameObject shieldGameObject;


    public AudioSource jumpAudioSource;
    public AudioClip jumpAudioClip;

    public AudioSource musicAudioSource;


    public AudioSource shieldAudioSource;
    public AudioClip shildTakeAC;

    public AudioClip[] musicArray;
    public int musicId = 0;


    void Start()
    {
        GameManager.playerController = this;

        animator = GetComponent<Animator>();
        shieldGameObject.SetActive(false);


        musicAudioSource.clip = (musicArray[musicId]);
        musicAudioSource.PlayOneShot(musicArray[musicId]);
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (transform.position.x < 4)
            {
                transform.Translate(Vector3.right * Time.deltaTime * turnSpeed);
            }
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (transform.position.x > -4)
            {
                transform.Translate(Vector3.left * Time.deltaTime * turnSpeed);
            }
        }

        //   if (isGrounded)
        // {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.Play("Jump");
            jumpAudioSource.PlayOneShot(jumpAudioClip);
            //    rb.AddForce(transform.up * 6, ForceMode.Impulse);
        }
       // }

        if (transform.position.y < 0.0f)
        {
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        }

        GroundCheck();
    }

    private void GroundCheck()
    {
        if (transform.position.y == 0f)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    public void AddPoint()
    {
        playerPoints++;
    }

    public void TurnOffShield()
    {
        hasShield = false;
        shieldGameObject.SetActive(false);
        GameManager.uiManager.HideShieldIcon();
    }

    public void TurnOnShield()
    {
        hasShield = true;
        shieldAudioSource.PlayOneShot(shildTakeAC);
        shieldGameObject.SetActive(true);
        GameManager.uiManager.ShowShieldIcon();
    }

    public void PlayNextEpisode()
    {
        musicAudioSource.Stop();
        musicId++;
        musicAudioSource.clip = (musicArray[musicId]);
        musicAudioSource.PlayOneShot(musicArray[musicId]);

    }
}
