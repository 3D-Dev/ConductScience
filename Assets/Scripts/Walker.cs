using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Experience;

public class Walker : MonoBehaviour
{
    private Vector3 PastPostion;
    private Vector3 CurPostion;
    private Vector3 OrgPostion;
    float StartTime, inActiveTime;
    float PercentageTime1, PercentageTime2, PercentageTime3, PercentageTime4;
    private float AverageLength;
    // Start is called before the first frame update
    void Start()
    {
        AverageLength = 0;
        PastPostion = new Vector3(0, 0, 0);
        CurPostion = new Vector3(0, 0, 0);
        OrgPostion = new Vector3(0, 0, 0);
        StartTime = 0;
        inActiveTime = 0;
        PercentageTime1 = PercentageTime2 = PercentageTime3 = PercentageTime4 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        StartTime += Time.deltaTime;
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
            if (PastPostion != CurPostion)//move
            {
                if (PastPostion == OrgPostion)
                {
                    ExperienceData.Instance.SetStartTime(StartTime);
                    StartTime = 0;
                }
                GetAveragelengh(PastPostion, CurPostion);
            }
            else if (PastPostion == CurPostion) { 
                inActiveTime += Time.deltaTime;
                ExperienceData.Instance.SetInactivTime(inActiveTime);
            }
            GetPercentageTime(CurPostion);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.name + "has Waler_Exit!");
    }
    private void GetAveragelengh(Vector3 vect1, Vector3 vect2)
    {
        float sum = Vector3.Distance(vect1, vect2);
        AverageLength += sum;
        //if(ExperienceData.Instance.isActive)
        ExperienceData.Instance.AverageLength = AverageLength;
    }
    private void GetPercentageTime(Vector3 pos)
    {
        switch(ExperienceData.Instance.GetEachQuad(pos))
        {
            case 1: 
                PercentageTime1 += Time.deltaTime;
                ExperienceData.Instance.SetPercentageTime(PercentageTime1, 1);
                break;
            case 2:
                PercentageTime2 += Time.deltaTime;
                ExperienceData.Instance.SetPercentageTime(PercentageTime2, 2);
                break;
            case 3:
                PercentageTime3 += Time.deltaTime;
                ExperienceData.Instance.SetPercentageTime(PercentageTime3, 3);
                break;
            case 4:
                PercentageTime4 += Time.deltaTime;
                ExperienceData.Instance.SetPercentageTime(PercentageTime4, 4);
                break;
            default:
                break;
        }
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
}
