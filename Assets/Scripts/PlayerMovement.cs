using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    protected Joystick joystick;
    public Animator animator;
    public float turnSpeed;
    public Rigidbody rigidbody;

    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {

        rigidbody.velocity = new Vector3(joystick.Horizontal * 5f, rigidbody.velocity.y, joystick.Vertical * 5f);

        // that code useful for character rotation
        transform.eulerAngles = new Vector3( 0, Mathf.Atan2( joystick.Vertical, joystick.Horizontal) * 180 / Mathf.PI, 0 );
        //rigidbody.rotation = rigidbody.rotation * Quaternion.AngleAxis(joystick.Horizontal * turnSpeed, Vector3.up);  // PIVOT ISSUE - AFTER SOLVE IT OPEN THAT CODE
        animator.SetFloat("Speed", Mathf.Abs(joystick.Horizontal));
        
        
        //transform.Rotate(new Vector3(transform.position.x, transform.position.y * (joystick.Horizontal * 5f), transform.position.z));
    }
}
