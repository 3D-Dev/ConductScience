using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name + "has Exit!");
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Debug.Log(collision.transform.name + "Has collided with me!");
    }

}
