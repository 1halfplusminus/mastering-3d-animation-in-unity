using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {

        Debug.Log("On trigger enter " + other.gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            animator.ResetTrigger("Open");
            animator.SetTrigger("Open");
        }

    }
    private void OnTriggerExit(Collider other)
    {

        Debug.Log("On trigger exit " + other.gameObject.name);
        if (other.gameObject.tag == "Player")
        {
            animator.SetTrigger("Close");
        }

    }
}
