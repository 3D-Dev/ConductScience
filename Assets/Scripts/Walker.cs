using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, Input.GetAxisRaw("Mouse X") * 2, 0, Space.Self);
        if (TrailProducer.Instance.canmove)
        {
            transform.Translate(Input.GetAxis("Horizontal") * Time.smoothDeltaTime * 25, 0, Input.GetAxis("Vertical") * Time.smoothDeltaTime * 25, Space.Self);
        }
    }
}
