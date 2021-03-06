using UnityEngine;
using System.Collections;

public class ClimbUp : MonoBehaviour
{

    float speed = 5.0F;
    float rotationSpeed = 100.0F;
    float lerpSpeed = 5.0F;
    Animator anim;
    bool isHanging = false;
    bool isShimmy = false;
    Transform animRootTarget;

    public void EndShimming()
    {
        Debug.Log("EndShimming");
        isShimmy = false;
    }
    public void EndClimb()
    {
        Debug.Log("EndClimb");
        GetComponent<Rigidbody>().isKinematic = false;
        isHanging = false;
        animRootTarget = null;
    }
    public void GrabEdge(Transform rootTarget)
    {
        if (isHanging) return;
        anim.SetTrigger("grabEdge");
        GetComponent<Rigidbody>().isKinematic = true;
        isHanging = true;
        animRootTarget = rootTarget;
    }
    void AnimLerp()
    {
        if (!animRootTarget || isShimmy) return;

        if (Vector3.Distance(this.transform.position, animRootTarget.position) > 0.1f)
        {
            this.transform.rotation = Quaternion.Lerp(transform.rotation,
                                                 animRootTarget.rotation,
                                                 Time.deltaTime * lerpSpeed);
            this.transform.position = Vector3.Lerp(transform.position,
                                              animRootTarget.position,
                                              Time.deltaTime * lerpSpeed);
        }
        else
        {
            this.transform.position = animRootTarget.position;
            this.transform.rotation = animRootTarget.rotation;
        }

    }

    void Start()
    {
        anim = this.GetComponent<Animator>();
        animRootTarget = null;
    }

    void FixedUpdate()
    {
        AnimLerp();
    }

    void Update()
    {
        float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        rotation *= Time.deltaTime;

        if (!isHanging)
            transform.Rotate(0, rotation, 0);

        if (translation != 0)
        {
            anim.SetBool("isWalking", true);
            anim.SetFloat("speed", translation * 0.5f);
        }
        else
        {
            anim.SetBool("isWalking", false);
            anim.SetFloat("speed", 0);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (isHanging)
            {
                anim.SetTrigger("drop");
                GetComponent<Rigidbody>().isKinematic = false;
            }
            else
            {
                anim.SetTrigger("isJumping");
            }
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (isHanging)
            {
                anim.SetTrigger("isClimbing");
                animRootTarget = null;
            }

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (isHanging)
            {
                anim.SetTrigger("shimmyLeft");
                animRootTarget = null;
                isShimmy = true;
            }

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (isHanging)
            {
                anim.SetTrigger("shimmyRight");
                animRootTarget = null;
                isShimmy = true;
            }
        }

    }
}
