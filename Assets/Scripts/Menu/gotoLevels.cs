using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoLevels : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Levels");
    }
}
