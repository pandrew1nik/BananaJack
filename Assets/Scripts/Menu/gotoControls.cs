using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gotoControls : MonoBehaviour
{
    public void OnClick()
    {
        SceneManager.LoadScene("Controls");
    }
}
