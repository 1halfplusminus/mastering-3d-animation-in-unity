using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlendController : MonoBehaviour
{
    SkinnedMeshRenderer blendShapes;
    float translation = 0;
    // Start is called before the first frame update
    void Start()
    {
        blendShapes = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        translation = Mathf.Abs(Input.GetAxis("Vertical") * 100);
        blendShapes.SetBlendShapeWeight(0, translation);
    }
}
