using UnityEngine;

public class Movement : MonoBehaviour
{


<<<<<<< HEAD
    Vector3 movementVec;
=======
    Vector2 movementVec;
>>>>>>> origin/main
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
<<<<<<< HEAD
        {   movementVec += Vector3.forward;  }
        if (Input.GetKey(KeyCode.S))
        {   movementVec += Vector3.back; }
        if (Input.GetKey(KeyCode.A))
        {   movementVec += Vector3.left; }
        if (Input.GetKey(KeyCode.D))
        {   movementVec += Vector3.right; }
        if (Input.GetKeyDown(KeyCode.Space)) 
        { movementVec += Vector3.up * 10; }
=======
        {   movementVec += Vector2.up;  }
        if (Input.GetKey(KeyCode.S))
        {   movementVec += Vector2.down; }
        if (Input.GetKey(KeyCode.A))
        {   movementVec += Vector2.left; }
        if (Input.GetKey(KeyCode.D))
        {   movementVec += Vector2.right; }
>>>>>>> origin/main

        RB.AddForce(movementVec);
    }
}
