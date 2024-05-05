using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    public GameObject trapObj;
    bool doOnce;
    private BoxCollider2D boxCollider2D;
    // Start is called before the first frame update
    void Start()
    {
        doOnce = false;
        trapObj.SetActive(false);
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //as
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player") && !doOnce)
        {
            trapObj.SetActive(true);
            doOnce = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            boxCollider2D.isTrigger = false;
        }
    }
}
