using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    public GameObject Walker;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
       // Debug.Log(other.name + "has Stay!");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name + "has Exit!");
        if(TrailProducer.Instance.canmove) { 
            TrailProducer.Instance.collisionflag = true;
            TrailProducer.Instance.rotation = Walker.transform.rotation;
        }
    }
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Debug.Log(collision.transform.name + "Has collided with me!");
    }

}
