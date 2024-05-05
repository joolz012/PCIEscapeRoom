using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.Member;

public class GameOver : MonoBehaviour
{
    GameObject playerObj;

    public AudioSource source;
    public AudioClip clip;
    // Start is called before the first frame update
    void Start()
    {
        //playerObj = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnEnable()
    {
        source.PlayOneShot(clip);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("EscapeRoomScene");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
