using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Experience;
using Firebase;
using Firebase.Extensions;
using Firebase.Storage;
using Firebase.Database;
using Firebase.Unity.Editor;
using System;

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
    
    private DependencyStatus dependencyStatus = DependencyStatus.UnavailableOther;
    protected FirebaseStorage storage;
    protected bool isFirebaseInitialized = false;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        ClosestDis = 400;
        NearDis = 450;
        ClosestTime = 0;
        ReachTime = 0;
        fromVect = new Vector3(0, 0, 0);
        toVect = new Vector3(0, 0, 0);
        num = 0;
        clockwise_num = 0;
        anti_clockwise_num = 0;
        sumAngle = 0;
        Player = GameObject.FindWithTag("Player");

        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
            dependencyStatus = task.Result;
            if (dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError(
                  "Could not resolve all Firebase dependencies: " + dependencyStatus);
            }
        });
    }

    protected virtual void InitializeFirebase()
    {
        FirebaseApp app = FirebaseApp.DefaultInstance;
        app.SetEditorDatabaseUrl("https://conduct-6968d.firebaseio.com/");

        storage = FirebaseStorage.DefaultInstance;
        var appBucket = FirebaseApp.DefaultInstance.Options.StorageBucket;
        if (!String.IsNullOrEmpty(appBucket))
        {
            //MyStorageBucket = String.Format("gs://{0}/", appBucket);
        }
        isFirebaseInitialized = true;
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
                    if (isFirebaseInitialized)
                        GetComponent<MiniMapComponent>().miniMapController.takeScreenShot();

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
