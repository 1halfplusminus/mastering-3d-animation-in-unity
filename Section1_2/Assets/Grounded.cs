using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    bool isGrounded = false;
    // Start is called before the first frame update

    void OnCollisionStay(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "GROUND")
        {
            isGrounded = true;
        }

    }

    void OnCollisionExit(Collision collisionInfo)
    {
        if (collisionInfo.gameObject.tag == "GROUND")
        {
            isGrounded = false;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded)
        {
            GetComponent<Rigidbody>().drag = 0;
        }
    }
}
