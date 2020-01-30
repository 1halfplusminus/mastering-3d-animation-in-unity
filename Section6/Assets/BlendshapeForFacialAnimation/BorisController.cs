using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorisController : MonoBehaviour
{
    SkinnedMeshRenderer blendShapes;
    float blink = 0;
    float open = 0;
    float mouseY = 0;

    // Start is called before the first frame update
    void Start()
    {
        blendShapes = GetComponent<SkinnedMeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        blink = Mathf.Clamp(Input.GetAxis("Vertical") * 100, 0, 100);
        open = Mathf.Clamp(Input.GetAxis("Horizontal") * 100, 0, 100);
        mouseY = Mathf.Clamp((Input.mousePosition.y * 100) / Screen.height, 0, 100);
        blendShapes.SetBlendShapeWeight(0, blink);
        blendShapes.SetBlendShapeWeight(1, open);
        blendShapes.SetBlendShapeWeight(2, mouseY);
    }
}
