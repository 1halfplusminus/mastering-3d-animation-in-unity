using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterPhys : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("entered");
        other.gameObject.GetComponent<Rigidbody>().useGravity = false;
        other.gameObject.GetComponent<Swim>().enabled = true;
        other.gameObject.GetComponent<Drive>().enabled = false;
        other.gameObject.GetComponent<Animator>().SetBool("isInWater", true);
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("exit");
        other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        other.gameObject.GetComponent<Swim>().enabled = false;
        other.gameObject.GetComponent<Drive>().enabled = true;
        other.gameObject.GetComponent<Animator>().SetBool("isInWater", false);
        other.gameObject.GetComponent<Animator>().SetBool("isSwimming", false);
        other.gameObject.transform.Translate(0, 0, 1);
    }
}
