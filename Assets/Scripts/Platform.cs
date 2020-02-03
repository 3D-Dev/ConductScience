using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    bool trailenabled;
    public GameObject Player;
    public float Distance;
    public MeshRenderer Graphics;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Distance = Vector3.Distance(transform.position, Player.transform.position);
        if (Distance < 50 && !trailenabled)
        {
            Graphics.enabled = true;
            trailenabled = true;
            GetComponent<MiniMapComponent>().enabled = true;
            TrailProducer.Instance.Enabletrail();
        }
    }
}
