using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainCamera : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, Input.GetAxisRaw("Mouse X") * 2, 0, Space.Self);
        if (TrailProducer.Instance.canmove)
        {
            transform.Translate(Input.GetAxis("Horizontal") * Time.smoothDeltaTime * 25, 0, Input.GetAxis("Vertical") * Time.smoothDeltaTime * 25, Space.Self);
        }
        else
        {
            //transform.Rotate(-Input.GetAxisRaw("Mouse Y") * 2, 0, 0, Space.Self);
            //transform.Rotate(0, Input.GetAxisRaw("Mouse X") * 2, 0, Space.World);
        }
    }
}
