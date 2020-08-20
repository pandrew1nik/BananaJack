using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootSound : MonoBehaviour
{
    public AudioClip shootsound;
    public AudioClip jumpsound;
    public AudioClip deathsound;
    public static int lives;
    AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        GameObject character = GameObject.Find("Character");
        Character character1 = character.GetComponent<Character>();
        lives = Character.numOflives;
    }

    void Update()
    {
        Shoot();
        Jump();
        Lives();
    }

    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
            audio.PlayOneShot(shootsound);
    }

    public void Jump()
    {
        if (Input.GetButtonDown("Jump"))
            audio.PlayOneShot(jumpsound);
    }

    public void Lives()
    {
        if (lives <= 0)
            audio.PlayOneShot(deathsound);
    }
}