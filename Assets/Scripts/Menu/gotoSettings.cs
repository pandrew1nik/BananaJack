using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoSettings : MonoBehaviour
{
    public void Settings()
    {
        SceneManager.LoadScene("Settings"); // loads Settings scene
    }
}
