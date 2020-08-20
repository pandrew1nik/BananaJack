using UnityEngine;
using System.Collections;

public class TurrelScr : MonoBehaviour
{


    public GameObject bullet;
    public float delayTime;
    bool canShoot = true;

    void Update()
    {
        if (canShoot)
        {
            canShoot = false;
            Instantiate(bullet, transform.position, transform.rotation);
            StartCoroutine(NoFire());
        }
    }

    IEnumerator NoFire()
    {
        yield return new WaitForSeconds(delayTime);
        canShoot = true;
    }
}