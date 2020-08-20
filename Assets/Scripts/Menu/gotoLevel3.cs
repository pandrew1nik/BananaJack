using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class gotoLevel3 : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Game3");
    }
}
