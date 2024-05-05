using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public static TimerScript instance;

    public float timeDuration;
    public Text minutesText;
    public Text secondsText;
    private float currentTime;
    public bool isRunning;

    public GameObject minusObj, gameOverObj;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Awake()
    {
        instance = this;
    }

    void OnEnable()
    {
        TimerDuration(timeDuration);
    }

    void Update()
    {
        if (isRunning)
        {
            currentTime -= Time.deltaTime;

            if (currentTime <= 0)
            {
                playerMovement.playerRb.velocity = Vector2.zero;
                playerMovement.playerAnim.Play("Idle");
                playerMovement.enabled = false;
                gameOverObj.SetActive(true);
            }

            UpdateTimerText();
        }

    }

    private void TimerDuration(float timer)
    {
        currentTime = timer * 60;
        isRunning = true;
    }

    void ResetTimer()
    {
        // Reset timer to the initial value
        isRunning = false;
        gameObject.SetActive(false);
        minutesText.text = "00";
        secondsText.text = "00";
    }

    void UpdateTimerText()
    {
        // Calculate minutes and seconds
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        // Update the UI text
        minutesText.text = minutes.ToString("00");
        secondsText.text = seconds.ToString("00");
    }

    public IEnumerator MinusTime()
    {
        currentTime -= 10;
        minusObj.SetActive(true);
        yield return new WaitForSeconds(3);
        minusObj.SetActive(false);
        yield break;
    }
}
