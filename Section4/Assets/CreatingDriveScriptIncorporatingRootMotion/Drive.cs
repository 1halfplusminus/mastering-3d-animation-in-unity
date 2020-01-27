using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drive : MonoBehaviour
{
    float speed = 5.0f;
    float rotationSpeed = 100.0f;

    public float animationSpeed = 0.0f;

    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;

        animator.SetFloat("animationSpeed", translation);

        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Rotate(0, rotation, 0);

        if (translation != 0)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }
}
