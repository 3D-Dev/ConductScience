using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public float moveSpeed = 20f;
    //public float rotationSpeed = 30f;
    public GameObject Target;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate (Vector3.forward * moveSpeed*Input.GetAxis("Vertical")*Time.deltaTime);
        //transform.Rotate (Vector3.up * rotationSpeed*Input.GetAxis("Horizontal")*Time.deltaTime);
        transform.position = new Vector3(Target.transform.position.x, 0, Target.transform.position.z);
        transform.eulerAngles = new Vector3(0, Target.transform.eulerAngles.y, Target.transform.eulerAngles.z);

    }
}
