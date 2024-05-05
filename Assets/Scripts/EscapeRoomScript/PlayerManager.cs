using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    [Header("Flashlight")]
    public GameObject[] uvLightObj;
    public UnityEngine.Rendering.Universal.Light2D light2D;
    public bool canFlashLight;
    public bool isFlashlight;
    public GameObject pickupFlash;
    public GameObject flashlightText;

    [Header("Fingerprint")]
    public GameObject fingerPrintCanvas;
    public GameObject fingerprintPress;

    [Header("Code")]
    public GameObject getKey;
    public GameObject seeNote;
    public GameObject codeNote;

    public GameObject codeRiddle;
    public GameObject codePress;
    public GameObject needKey;
    bool codeKey = false;
    private GameObject currentObj;

    [Header("bools")]
    private bool flashBool, fingerBool, noteBool, keyBool, lockBool;


    [Header("Audio")]
    public AudioSource audioSource;
    public AudioClip audioClip;
    // Start is called before the first frame update
    void Start()
    {
        canFlashLight = false;
        isFlashlight = false;

        foreach (GameObject uvObjs in uvLightObj)
        {
            uvObjs.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        FlashLight(); 
        InteractableObjects();
    }

    void FlashLight()
    {
        if (canFlashLight)
        {
            if (Input.GetKeyDown(KeyCode.E) && !fingerBool && !lockBool)
            {
                isFlashlight = !isFlashlight;
            }

            Color color;
            if (isFlashlight)
            {
                if (ColorUtility.TryParseHtmlString("#9F28FF", out color))
                {
                    light2D.color = color;
                }

                foreach (GameObject uvObjs in uvLightObj)
                {
                    uvObjs.SetActive(true);
                }
                //flashlight on
            }
            else
            {
                if (ColorUtility.TryParseHtmlString("#FFFFFF", out color))
                {
                    light2D.color = color;
                }
                foreach (GameObject uvObjs in uvLightObj)
                {
                    uvObjs.SetActive(false);
                }
                //flashlight off
            }
        }
    }

    void InteractableObjects()
    {
        if (flashBool)
        {
            Debug.Log("Flashlight");
            pickupFlash.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                audioSource.PlayOneShot(audioClip);
                canFlashLight = true;
                flashBool = false;
                StartCoroutine(FlashlightTutor());
                currentObj.SetActive(false);
            }
        }
        if (fingerBool)
        {
            Debug.Log("fingerprint");
            fingerprintPress.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                audioSource.PlayOneShot(audioClip);
                fingerPrintCanvas.SetActive(true);
            }
        }
        if (noteBool)
        {
            Debug.Log("note");
            seeNote.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                audioSource.PlayOneShot(audioClip);
                codeNote.SetActive(true);
            }
        }
        if(keyBool)
        {
            Debug.Log("key");
            getKey.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                audioSource.PlayOneShot(audioClip);
                codeKey = true;
                currentObj.SetActive(false);
                keyBool = false;
            }
        }
        if (lockBool)
        {
            Debug.Log("lock");
            if (codeKey)
            {
                codePress.SetActive(true);
                if (Input.GetKeyDown(KeyCode.F))
                {
                    audioSource.PlayOneShot(audioClip);
                    codeRiddle.SetActive(true);
                }
            }
            else
            {
                needKey.SetActive(true);
            }
        }
    }

    IEnumerator FlashlightTutor()
    {
        flashlightText.SetActive(true);
        yield return new WaitForSeconds(3);
        flashlightText.SetActive(false);
        yield break;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("flashlight"))
        {
            flashBool = true;
            currentObj = collision.gameObject;

        }
        if (collision.gameObject.CompareTag("fingerprint"))
        {
            fingerBool = true;
            currentObj = collision.gameObject;

        }

        if (collision.gameObject.CompareTag("codeNote"))
        {
            noteBool = true;
            currentObj = collision.gameObject;
        }

        if (collision.gameObject.CompareTag("codeKey"))
        {
            keyBool = true;
            currentObj = collision.gameObject;

        }
        if (collision.gameObject.CompareTag("codeLock"))
        {
            lockBool = true;
            currentObj = collision.gameObject;

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("flashlight"))
        {
            flashBool = false;
            pickupFlash.SetActive(false);
        }
        if (collision.gameObject.CompareTag("fingerprint"))
        {
            fingerBool = false;
            fingerprintPress.SetActive(false);
            fingerPrintCanvas.SetActive(false);
        }
        if (collision.gameObject.CompareTag("codeNote"))
        {
            noteBool = false;
            seeNote.SetActive(false);
            codeNote.SetActive(false);
        }

        if (collision.gameObject.CompareTag("codeKey"))
        {
            keyBool = false;
            getKey.SetActive(false);
        }

        if (collision.gameObject.CompareTag("codeLock"))
        {
            lockBool = false;
            codeRiddle.SetActive(false);
            codePress.SetActive(false);
            needKey.SetActive(false);
        }
    }
}
