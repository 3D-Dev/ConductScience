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
    // Start is called before the first frame update
    void Start()
    {
        ClosestDis = 40;
        NearDis = 45;
        ClosestTime = 0;
        ReachTime = 0;
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(transform.position, Player.transform.position);
        if (!trailenabled) {
            ReachTime += Time.deltaTime;
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
                    ClosestTime = 0;
                    ReachTime = 0;
                }
            }
        }
    }
}
