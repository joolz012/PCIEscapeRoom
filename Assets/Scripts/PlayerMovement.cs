using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D playerRb;
    private float trueSpeed;
    public float walkSpeed;
    public float runSpeed;

    public Animator playerAnim;

    public GameObject footStep;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        trueSpeed = walkSpeed;
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector2 movement = new(horizontal, vertical);

        playerRb.velocity = movement * trueSpeed;


        if (Input.GetKey(KeyCode.LeftShift))
        {
            trueSpeed = runSpeed;
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            trueSpeed = walkSpeed;
        }

        PlayerBody(horizontal, vertical);
    }

    void PlayerBody(float horizontal, float vertical)
    {
        Transform playerBody = transform.Find("PlayerObj");

        if(horizontal < 0)
        {
            playerBody.localScale = new(-1, 1, 1);
        }
        else if (horizontal > 0)
        {
            playerBody.localScale = new(1, 1, 1);
        }

        if(horizontal != 0)
        {
            footStep.SetActive(true);
            playerAnim.Play("Walk");
        }
        else if (vertical != 0)
        {
            footStep.SetActive(true);
            playerAnim.Play("Walk");
        }
        else if (horizontal == 0)
        {
            footStep.SetActive(false);
            playerAnim.Play("Idle");
        }
    }
}
