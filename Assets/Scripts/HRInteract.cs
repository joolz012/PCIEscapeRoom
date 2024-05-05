using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HRInteract : MonoBehaviour
{
    public DialogManager dialogManager;
    public GameObject interact;
    private bool isInteracted = false;
    bool isInteracting = false;
    // Start is called before the first frame update
    void Start()
    {
        interact.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(isInteracting)
        {
            interact.SetActive(true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                interact.SetActive(false);
                if (dialogManager != null)
                {
                    Debug.Log("Dialog");
                    dialogManager.index += 1;
                    StartCoroutine(dialogManager.DialogEnable());
                    isInteracting = false;
                    isInteracted = true;
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player") && !isInteracted)
        {
            isInteracting = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("player"))
        {
            isInteracting = false;
            interact.SetActive(false);
        }
    }

}
