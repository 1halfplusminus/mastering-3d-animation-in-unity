using UnityEngine;

public class GrabCollider : MonoBehaviour
{
    public GameObject climber;
    public void GrabEdge(Transform rootTarget)
    {
        ClimbUp climbUp;
        if (climber.TryGetComponent<ClimbUp>(out climbUp))
        {
            climbUp.GrabEdge(rootTarget);
        }
    }
}
