using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
public void OnClickQuit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
