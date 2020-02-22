using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMoveController : MonoBehaviour
{
    //public OVRInput.Controller Controller = OVRInput.Controller.RTouch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(TrailProducer.Instance.canmove)
        {
            transform.Translate(Input.GetAxis("Horizontal") * Time.smoothDeltaTime * 25, 0, Input.GetAxis("Vertical") * Time.smoothDeltaTime * 25, Space.Self);
         //   transform.Translate(OVRInput.Get(OVRInput.Axis1D) * Time.smoothDeltaTime * 25, 0, Input.GetAxis("Vertical") * Time.smoothDeltaTime * 25, Space.Self);
        }
    }
}
