using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Unity.VisualScripting.Member;

public class UnlockCode : MonoBehaviour
{
    public DoorEscapeRoom doorEscapeRoom;
    public InputField playerAnswer;
    public Collider2D col2D;
    public string correctAnswer;

    public AudioSource source;
    public AudioClip[] clip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckAnswer()
    {
        if(playerAnswer.text == correctAnswer)
        {
            Debug.Log("Correct");
            source.PlayOneShot(clip[0]);
            col2D.enabled = false;
            doorEscapeRoom.isUnlocked = true;
            gameObject.SetActive(false);
        }
        else
        {
            source.PlayOneShot(clip[1]);
            TimerScript.instance.StartCoroutine(TimerScript.instance.MinusTime());
        }
    }
}
