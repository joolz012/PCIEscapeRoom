using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorEscapeRoom : MonoBehaviour
{
    public bool isUnlocked;
    public GameObject[] doors;
    Collider2D col2D;
    // Start is called before the first frame update
    void Start()
    {
        col2D = GetComponent<Collider2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(col2D != null)
        {
            if (isUnlocked)
            {
                col2D.isTrigger = true;
            }
        }
        else
        {
            Debug.Log("No Collider");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            doors[0].SetActive(false);
            doors[1].SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            doors[1].SetActive(false);
            doors[0].SetActive(true);
        }
    }
}
