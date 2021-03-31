using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabnetOpen : MonoBehaviour
{
    [SerializeField]
    private GameObject interactIcon = null;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private GameObject contents = null;
    [SerializeField]
    private bool hasItems = false;

    private bool interact = false;
    private bool closed = true;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenDraw();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            interactIcon.SetActive(true);
            interact = true;
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(10f);
        interactIcon.SetActive(false);
        interact = false;
    }

    private void OpenDraw()
    {
        if(interact == true)
        {
            if (closed == true)
            {
                anim.SetTrigger("Open");
                contents.SetActive(true);
                interactIcon.SetActive(false);
                interact = false;
                closed = false;
            }
            else if (hasItems == false)
            {
                anim.SetTrigger("Close");
                contents.SetActive(false);
                interactIcon.SetActive(false);
                interact = false;
                closed = true;

            }
        }       
    }

}
