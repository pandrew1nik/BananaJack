using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoLevel2 : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Game2");
    }
}
