using UnityEngine;

public class TriggerGrabbing : MonoBehaviour
{
    public GameObject rootPos;

    void OnTriggerEnter(Collider obj)
    {
        Debug.Log(obj.name);
        GrabCollider grabCollider;
        if (obj.TryGetComponent<GrabCollider>(out grabCollider))
        {
            grabCollider.GrabEdge(rootPos.transform);
        }
        MoveAnchor(obj);
    }
    void OnTriggerStay(Collider other)
    {
        MoveAnchor(other);
    }
    private void MoveAnchor(Collider obj)
    {
        ClimbUp climbUp;
        if (obj.TryGetComponent<ClimbUp>(out climbUp))
        {
            var animRootTarget = rootPos.transform;
            Plane rootPlane = new Plane(animRootTarget.position, animRootTarget.position + animRootTarget.right, animRootTarget.position + animRootTarget.up);

            Vector3 adjustedPos = new Vector3(climbUp.gameObject.transform.position.x, animRootTarget.position.y, climbUp.gameObject.transform.position.z);

            Ray ray = new Ray(adjustedPos, animRootTarget.forward);
            float rayDistance;
            if (rootPlane.Raycast(ray, out rayDistance))
            {
                animRootTarget.position = ray.GetPoint(rayDistance);
            }
        }
    }
}
