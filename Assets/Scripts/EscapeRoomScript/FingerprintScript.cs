using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class FingerprintScript : MonoBehaviour
{
    bool finger1, finger2, finger3, finger4;
    bool wrong1, wrong2;
    public GameObject fingerPrintObj;
    public DoorEscapeRoom doorEscapeRoom;


    public Collider2D col2D;

    public AudioSource source;
    public AudioClip[] clip;

    private void Awake()
    {
    }

    private void OnEnable()
    {
        //playerMovement.playerRb.velocity = Vector2.zero;
        //playerMovement.enabled = false;
    }

    private void Update()
    {

        //Debug.Log("1 " + finger1);
        //Debug.Log("2 " + finger2);
        //Debug.Log("3 " + finger3);
        //Debug.Log("4 " + finger4);
        Debug.Log("1 " + wrong1);
        Debug.Log("2 " + wrong2);
    }

    public void ChecckFingerprints()
    {
        if (finger1 && finger2 && finger3 && finger4 & !wrong1 && !wrong2)
        {
            source.PlayOneShot(clip[0]);
            col2D.enabled = false;
            doorEscapeRoom.isUnlocked = true;
        }
        else
        {
            source.PlayOneShot(clip[1]);
            TimerScript.instance.StartCoroutine(TimerScript.instance.MinusTime());
        }
    }

    public void FingerOne()
    {
        finger1 = !finger1;
    }
    public void FingerTwo()
    {
        finger2 = !finger2;
    }
    public void FIngerThree()
    {
        finger3 = !finger3;
    }
    public void FingerFour()
    {
        finger4 = !finger4;
    }

    public void WrongOne()
    {
        wrong1 = !wrong1;
    }
    public void WrongTwo()
    {
        wrong2 = !wrong2;
    }
}
