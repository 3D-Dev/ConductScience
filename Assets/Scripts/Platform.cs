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
    private float ClosestTime;
    // Start is called before the first frame update
    void Start()
    {
        ClosestDis = 40;
        NearDis = 185;
        ClosestTime = 0;
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(transform.position, Player.transform.position);
        if (Distance < NearDis && !trailenabled)
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
                ClosestTime = 0;
            }
        }
    }
}
