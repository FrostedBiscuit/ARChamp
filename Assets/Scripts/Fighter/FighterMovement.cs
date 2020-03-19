using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FighterMovement : MonoBehaviour
{
    public float MovementSpeed = 10f;

    public Transform LookAtPoint;

    public JoystickInput Input;

    private Rigidbody Rigidbody;

    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input != null)
        {
            transform.LookAt(LookAtPoint);

            Vector3 newPos = (transform.right * Input.MoveDirection.x + transform.forward * Input.MoveDirection.z) * MovementSpeed * Time.deltaTime;

            Rigidbody.MovePosition(transform.position + newPos);
        }
    }
}
