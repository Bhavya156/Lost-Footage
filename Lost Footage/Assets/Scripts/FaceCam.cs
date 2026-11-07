using UnityEngine;

public class FaceCam : MonoBehaviour
{
    void Update()
    {
        // transform.localRotation = Quaternion.Euler();
        transform.LookAt(Camera.main.transform.position);
        transform.Rotate(0f, 180, 0f);

        Vector3 rot = transform.eulerAngles;
        rot.z = 0f;
        rot.x = 0f;
        transform.eulerAngles = rot;
    }
}
