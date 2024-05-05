using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public bool isSafe;
    public GameObject gameOverObj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            if (!isSafe)
            {
                playerMovement.playerRb.velocity = Vector2.zero;
                playerMovement.playerAnim.Play("Idle");
                playerMovement.enabled = false;
                gameOverObj.SetActive(true);
            }
            else
            {
                Debug.Log("Safe");
            }
        }
    }
}
