using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;

    private Vector3 moveDirection = Vector3.zero;

    public float jumpForce = 10.0f;

    public float gravity = 20.0f;

    public float speed = 50.0f;
    public float turnSpeed = 50.0f;

    public GameObject runFace;

    public GameObject jumpFace;

    public GameObject idleFace;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = gameObject.GetComponentInChildren<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded && (Input.GetKey("up")))
        {
            animator.SetInteger("AnimPar", 1);
            moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
            float turn = Input.GetAxis("Horizontal");
            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);

            runFace.SetActive(true);
            jumpFace.SetActive(false);
            idleFace.SetActive(false);
        }
        else if (controller.isGrounded)
        {
            animator.SetInteger("AnimPar", 0);
            moveDirection = transform.forward * Input.GetAxis("Vertical") * 0;
            float turn = Input.GetAxis("Horizontal");
            transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);

            idleFace.SetActive(true);
            jumpFace.SetActive(false);
            runFace.SetActive(false);

        }

        if (Input.GetButton("Jump") && controller.isGrounded)
        {
            animator.SetInteger("AnimPar", 2);
            moveDirection.y = jumpForce;

            jumpFace.SetActive(true);
            idleFace.SetActive(false);
            runFace.SetActive(false);

        }

        controller.Move(moveDirection * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;
    }
}
