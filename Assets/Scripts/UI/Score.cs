using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public static int scoreValue;
    private static Text score;
    //public GameObject character;

    public void Start()
    {
        scoreValue = 0;
        score = GetComponent<Text>();
        //scoreValue = GameObject.Find("Character")./*gameObject.*/GetComponent<Character>().Score;
    }

    public static void Print()
    {
        score.text = scoreValue.ToString();

    }
}
