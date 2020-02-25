using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public float moveSpeed = 20f;
    //public float rotationSpeed = 30f;
    public GameObject Target;
    public GameObject Walker;
    public GameObject VRCarmera;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate (Vector3.forward * moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);
        //transform.Rotate (Vector3.up * rotationSpeed*Input.GetAxis("Horizontal")*Time.deltaTime);
        if(Walker == null)//VR
            transform.position = new Vector3(VRCarmera.transform.position.x, 0, VRCarmera.transform.position.z);
        else
            transform.position = new Vector3(Walker.transform.position.x, 0, Walker.transform.position.z);
        //transform.position = new Vector3(VRCarmera.transform.position.x, 0, VRCarmera.transform.position.z);// for VR
        transform.eulerAngles = new Vector3(0, Target.transform.eulerAngles.y, Target.transform.eulerAngles.z);
        
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Sphere")
        {
            Debug.Log("Hit Sphere");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Sphere")
        {
            Debug.Log("Hit Sphere");
        }
    }
}
