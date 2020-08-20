using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class anali : MonoBehaviour
{
    public GoogleAnalyticsV4 googleAnalytics;


    public void FacebookClick()
    {
        Application.OpenURL("https://www.facebook.com/profile.php?id=100007296677280");
    }
}
