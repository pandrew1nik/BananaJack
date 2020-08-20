using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public GameObject laser;
    public float delayTime = 0.5F;
    bool canShoot = true;

    AudioSource audio;
    public AudioClip shootsound;

    public void Start()
    {
        audio = GetComponent<AudioSource>();
    }
    public void Update()
    {
        //Fire();
        if (Input.GetButtonDown("Fire1") && canShoot)
        {
            canShoot = false;
            Instantiate(laser, transform.position, transform.rotation);
        }
    }

        public void Fire()
    {
        if (/*Input.GetButtonDown("Fire1") && */canShoot)
        {
            canShoot = false;
            Instantiate(laser, transform.position, transform.rotation);
            StartCoroutine(NoFire());
            audio.PlayOneShot(shootsound);
        }


        IEnumerator NoFire()
        {
            yield return new WaitForSeconds(delayTime);
            canShoot = true;
        }


    }
}