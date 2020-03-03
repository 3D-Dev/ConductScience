using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Experience;

public class Walker : MonoBehaviour
{
    private Vector3 PastPostion;
    private Vector3 CurPostion;
    private float AverageLength;
    // Start is called before the first frame update
    void Start()
    {
        AverageLength = 0;
        PastPostion = new Vector3(0, 0, 0);
        CurPostion = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxisRaw("Mouse X") * 2, 0, Space.Self);

        if (TrailProducer.Instance.collisionflag) { 
            if (Mathf.Abs(transform.rotation.eulerAngles.y - TrailProducer.Instance.rotation.eulerAngles.y) > 90)
                TrailProducer.Instance.collisionflag = false;
            else
                TrailProducer.Instance.collisionflag = true;
        }

        if (TrailProducer.Instance.canmove && TrailProducer.Instance.collisionflag == false)
        {
            PastPostion.Set(transform.position.x, transform.position.y, transform.position.z);
            transform.Translate(Input.GetAxis("Horizontal") * Time.smoothDeltaTime * 25, 0, Input.GetAxis("Vertical") * Time.smoothDeltaTime * 25, Space.Self);
            CurPostion.Set(transform.position.x, transform.position.y, transform.position.z);
            if (PastPostion != CurPostion)
                GetAveragelengh(PastPostion, CurPostion);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name + "has Waler_Exit!");
    }
    /*
    private void OnCollisionEnter(UnityEngine.Collision collision)
    {
        Debug.Log(collision.transform.name + "Has collided with me!");
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log(other.name + "has Waler_Stay!");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name + "has Waler_Exit!");
    }
    */
    private void GetAveragelengh(Vector3 vect1, Vector3 vect2)
    {
        float sum = Vector3.Distance(vect1, vect2);
        AverageLength += sum;
        ExperienceData.Instance.SetAveragepathLength(AverageLength);
        
    }
}
