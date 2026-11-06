using UnityEngine;

public class Movement : MonoBehaviour
{


    Vector2 movementVec;
    Rigidbody RB;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {   movementVec += Vector2.up;  }
        if (Input.GetKey(KeyCode.S))
        {   movementVec += Vector2.down; }
        if (Input.GetKey(KeyCode.A))
        {   movementVec += Vector2.left; }
        if (Input.GetKey(KeyCode.D))
        {   movementVec += Vector2.right; }

        RB.AddForce(movementVec);
    }
}
