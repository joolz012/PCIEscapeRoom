using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogEscapeRoom : MonoBehaviour
{
    public AudioSource audioSource;

    [Header("Text")]
    public TextMeshProUGUI textComponent;
    public TextMeshProUGUI nameText;
    public float textSpeed;
    public string[] characterNames;
    public string[] lines;

    [Header("Image")]
    public Texture2D[] images;
    public RawImage rawImage;

    public GameObject dialogCanvas;
    public GameObject[] highlights;
    public bool moving;
    private bool cantClick = true;

    public int index;

    [Header("Other")]
    public PlayerMovement playerMovement;
    public GameObject timerObj;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        dialogCanvas.SetActive(false);
        StartCoroutine(GameStart());
    }


    IEnumerator GameStart()
    {
        playerMovement.playerRb.velocity = Vector3.zero;
        playerMovement.enabled = false;
        textComponent.text = string.Empty;
        nameText.text = string.Empty;
        yield return new WaitForSeconds(1.5f);
        dialogCanvas.SetActive(true);
        StartDialogue();
        cantClick = false;
        yield break;
    }

    void Update()
    {
        if (!cantClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (textComponent.text == lines[index])
                {
                    NextLine();
                }
                else if (!moving)
                {
                    StopAllCoroutines();
                    textComponent.text = lines[index];
                }
            }
        }
    }

    public IEnumerator DialogEnable()
    {
        playerMovement.playerRb.velocity = Vector3.zero;
        playerMovement.enabled = false;
        textComponent.text = string.Empty;
        nameText.text = string.Empty;
        yield return new WaitForSeconds(2f);
        dialogCanvas.SetActive(true);
        StartCoroutine(TypeLine());
        UpdateImage();
        UpdateName();
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
        UpdateImage();
        UpdateName();
    }
    public IEnumerator Countdown()
    {
        Debug.Log("Countdown");
        dialogCanvas.SetActive(false);
        yield return new WaitForSeconds(3);
        dialogCanvas.SetActive(true);
        NextLine();
        moving = false;
    }

    public void HighlightsDisable()
    {
        foreach (GameObject images in highlights)
        {
            images.SetActive(false);
        }
    }

    IEnumerator TypeLine()
    {
        textComponent.text = string.Empty;
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            StartCoroutine(TypeLine());
            UpdateImage();
            UpdateName();
        }
        else
        {
            timerObj.SetActive(true);
            playerMovement.enabled = true;
            dialogCanvas.SetActive(false);
            gameObject.SetActive(false);
        }
    }

    void UpdateName()
    {
        if (index < characterNames.Length)
        {
            nameText.text = characterNames[index];
        }
    }

    void UpdateImage()
    {
        if (index < images.Length)
        {
            rawImage.texture = images[index];
        }
    }
}
