using UnityEngine;
using System.Collections;

public class Drive : MonoBehaviour
{

    float speed = 5.0F;
    float rotationSpeed = 100.0F;
    Animator anim;
    bool isDead;
    void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "DEATH_CUBE")
        {
            anim.SetBool("isDead", true);
            enabled = false;
            GetComponent<Rigidbody>().constraints |= RigidbodyConstraints.FreezeAll;
        }
    }
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        if (translation != 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

    }
}
