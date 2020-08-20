using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement; 
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public bool isOpened = false; //Открыто ли меню

    public void ShowHideMenu()
    {
        isOpened = !isOpened;
        GetComponent<Canvas>().enabled = isOpened;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            ShowHideMenu();
        }
    }

    public void HideMenu()
    {
#pragma warning disable CS1717 // Проведено присвоение той же переменной; действительно выполнить такое назначение, а не иное?
        isOpened = isOpened;
#pragma warning restore CS1717 // Проведено присвоение той же переменной; действительно выполнить такое назначение, а не иное?
        GetComponent<Canvas>().enabled = isOpened;
    }
}
