using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour
{
    public GameObject laser;
    public float delayTime;
    bool canShoot = true;
    private float movement = 0f;
    private bool FacingRight = true;

    public int manna;

    public void Update()
    {
        Shoot();
        Movement();

        //if (manna <= 2000)
        //{
        //    Shoot() = false;
        //}
    }

    

    public void Shoot()
    {
        manna++;

        //manna++;
        if (manna >= 2000)
            canShoot = true;
        if (manna < 2000)
        {
            canShoot = false;
        }

        if (canShoot = true && Input.GetButtonDown("Fire1"))
            manna -= 2000;


        Vector3 position = transform.position; 
        if (canShoot /*&& manna ==  2000*/ && Input.GetButtonDown("Fire1"))
        {
            canShoot = false;
            Instantiate(laser, transform.position, transform.rotation);
            StartCoroutine(NoFire());
        }
        //if (canShoot /*&& manna ==  2000*/ && Input.GetButtonDown("Fire1"))
        //{
        //   manna -= 2000;
        //}



    }

    IEnumerator NoFire()
    {
        yield return new WaitForSeconds(delayTime);
        canShoot = true;
    }

    public void Movement()
    {
        movement = Input.GetAxis("Horizontal");
        if (movement > 0 && !FacingRight)
            Flip();
        else if (movement < 0 && FacingRight)
            Flip();
    }
    public void Flip()
    {
        FacingRight = !FacingRight;
        Vector3 Scale = transform.localScale;
        Scale.x *= -1;
        transform.localScale = Scale;
    }
}
