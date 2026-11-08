using UnityEngine;

public class rotatingCamera : MonoBehaviour
{

    [SerializeField] float rotationSpeed;

    void Update()
    {
        Camera.main.transform.Rotate(new Vector3(0, rotationSpeed * Time.deltaTime, 0));

        if (Input.GetKey(KeyCode.Mouse0))
        {
            Camera.main.transform.Rotate(new Vector3(0, 2 * rotationSpeed * Time.deltaTime, 0));
        }
    }
}
