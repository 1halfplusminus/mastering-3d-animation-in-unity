using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum State
{
    Walking = 1,
    Idle = 0,
}
public class Drive : MonoBehaviour
{

    public float speed = 5.0f;
    public float rotationSpeed = 100.0f;
    public float jump = 1.0f;
    int playerState;

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
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);
        if (translation != 0)
        {
            animator.SetInteger("state", (int)State.Walking);
            animator.SetFloat("speed", translation);
        }
        else
        {
            animator.SetInteger("state", (int)State.Idle);
            animator.SetFloat("speed", translation);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jumping");
        }
    }
}
