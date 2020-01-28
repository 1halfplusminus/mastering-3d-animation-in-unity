using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitOn : MonoBehaviour
{
    public GameObject character;
    bool sittingOn;
    bool isWalkingTowards = false;
    Animator animator;

    public GameObject anchor;
    // Start is called before the first frame update
    void Start()
    {
        animator = character.GetComponent<Animator>();
        sittingOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalkingTowards && !sittingOn)
        {
            AutoWalkToward();
        }
    }
    void AutoWalkToward()
    {
        Vector3 targetDir = new Vector3(anchor.transform.position.x - character.transform.position.x, 0f, anchor.transform.position.z - character.transform.position.z);
        Quaternion quat = Quaternion.LookRotation(targetDir);
        character.transform.rotation = Quaternion.Slerp(character.transform.rotation, quat, 0.05f);
        character.transform.Translate(Vector3.forward * 0.01f);
        if (Vector3.Distance(character.transform.position, anchor.transform.position) < 0.9f)
        {
            animator.SetBool("isWalking", false);
            animator.SetBool("isSitting", true);
            character.transform.rotation = Quaternion.LookRotation(new Vector3(anchor.transform.forward.x, 0.0f, anchor.transform.forward.z));
            character.transform.position = new Vector3(anchor.transform.position.x, character.transform.position.y, anchor.transform.position.z);
            character.GetComponent<Rigidbody>().freezeRotation = true;
            isWalkingTowards = false;
            sittingOn = true;
        }
    }
    void OnMouseDown()
    {
        animator = character.GetComponent<Animator>();
        if (!sittingOn)
        {
            animator.SetFloat("speed", 1);
            animator.SetBool("isWalking", true);
            character.GetComponent<Controller>().enabled = false;
            isWalkingTowards = true;
        }
        else
        {
            animator.SetBool("isSitting", false);
            isWalkingTowards = false;
            sittingOn = false;
            character.GetComponent<Controller>().enabled = true;

        }
    }
}
