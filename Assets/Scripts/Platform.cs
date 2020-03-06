using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Experience;

public class Platform : MonoBehaviour
{
    float ClosestDis, NearDis;
    bool trailenabled;
    public GameObject Player;
    public float Distance;
    public MeshRenderer Graphics;
    private float ClosestTime, ReachTime;
    float sumAngle;
    Vector3 fromVect, toVect;
    int num, clockwise_num, anti_clockwise_num;
    // Start is called before the first frame update
    void Start()
    {
        ClosestDis = 40;
        NearDis = 45;
        ClosestTime = 0;
        ReachTime = 0;
        fromVect = new Vector3(0, 0, 0);
        toVect = new Vector3(0, 0, 0);
        num = 0;
        clockwise_num = 0;
        anti_clockwise_num = 0;
        sumAngle = 0;
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(transform.position, Player.transform.position);
        if (!trailenabled) {
            ReachTime += Time.deltaTime;
            num++;
            GetBetweenAngle_DirectNum(transform.position, Player.transform.position, Player.transform.forward);

            if (Distance < NearDis)
            {
                ClosestTime += Time.deltaTime;
                if(Distance < ClosestDis)
                {
                    Graphics.enabled = true;
                    trailenabled = true;
                    GetComponent<MiniMapComponent>().enabled = true;
                    TrailProducer.Instance.Enabletrail();
                    ExperienceData.Instance.SetClosestDistance(Distance);
                    ExperienceData.Instance.SetClosestTime(ClosestTime);
                    ExperienceData.Instance.SetReachTime(ReachTime);
                    ExperienceData.Instance.SetPathViewer(true);
                    //ExperienceData.Instance.SetFinalData();
                    ExperienceData.Instance.SetAverageDiff(sumAngle / num);
                    ExperienceData.Instance.SetAntiClockNumPath(anti_clockwise_num);
                    ExperienceData.Instance.SetClockNumPath(clockwise_num);
                    ClosestTime = 0;
                    ReachTime = 0;
                }
            }
        }
    }
    void GetBetweenAngle_DirectNum(Vector3 target, Vector3 playerPos, Vector3 forward)
    {
        fromVect = target - playerPos;
        //--------------------BetweenAngle------------------
        float angle = Vector3.Angle(fromVect, forward);
        sumAngle += angle;
        //--------------------direction----------------------
        float angle1 = Vector3.SignedAngle(fromVect, forward, Vector3.up);
        if (angle1 < -5.0F) { 
            Debug.Log("anti_clockwise");
            anti_clockwise_num++;
        }
        else if(angle1 > 5.0F) { 
            Debug.Log("clockwise");
            clockwise_num++;
        }
        else
            Debug.Log("forward");


    }
}
