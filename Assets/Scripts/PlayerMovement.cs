using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    protected Joystick joystick;
    public Animator animator;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(joystick.Horizontal * 5f, rigidbody.velocity.y, joystick.Vertical * 5f);

        // that code useful for character rotation
        rigidbody.rotation = rigidbody.rotation * Quaternion.AngleAxis(joystick.Horizontal * 5f, Vector3.forward);  // PIVOT ISSUE - AFTER SOLVE IT OPEN THAT CODE
        animator.SetFloat("Speed", Mathf.Abs(joystick.Horizontal));
    }
}
