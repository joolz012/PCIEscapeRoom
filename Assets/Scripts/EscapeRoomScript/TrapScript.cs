using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public float trapSpeed;
    public GameObject gameoverObj;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per fram
    void Update()
    {
        transform.Translate(0, -trapSpeed * Time.deltaTime, 0);
        if(transform.position.y <= -35)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            playerMovement.playerRb.velocity = Vector2.zero;
            playerMovement.playerAnim.Play("Idle");
            playerMovement.enabled = false;
            gameoverObj.SetActive(true);
        }
    }
}
