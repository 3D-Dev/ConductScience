using UnityEngine;

public class Eye : MonoBehaviour
{
    float  position_x, position_y, position_z;
    void Update()
    {
        transform.Rotate(-Input.GetAxisRaw("Mouse Y") * 2, 0, 0, Space.Self);
    }
}