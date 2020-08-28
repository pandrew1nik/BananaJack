using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game8 : MonoBehaviour
{
    public Character character;
    public GameObject finish;
    private InterstitialAds InterstitialAds;

    [SerializeField] private
        string _sceneName;

    public int nextScene;

    public void Start()
    {
        nextScene = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log("[IntAd] Initing interstitial in finish...");
        InterstitialAds = FindObjectOfType<InterstitialAds>();
        InterstitialAds.InitInerstitialAd();
    }

    public void Update()
    {
        finish.SetActive(character.Portal >= 1);
    }

    private void LoadNewScene()
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Debug.Log("[IntAd] Showing ad in finish...");
            InterstitialAds.ShowAd();
            LoadNewScene();
            if (nextScene > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextScene);
            }
        }
    }
}
