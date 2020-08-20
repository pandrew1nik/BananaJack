using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class preloader : MonoBehaviour
{
    private const float sec = 5;
    public void Start()
    {
        StartCoroutine(LoadLevelAfterSec(sec));
    }

    IEnumerator LoadLevelAfterSec(float sec)
    {
        yield return new WaitForSeconds(sec);
        SceneManager.LoadScene("Menu");
    }
}
