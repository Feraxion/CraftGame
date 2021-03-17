using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    protected Joystick joystick;
    public Animator animator;
    public float turnSpeed;
    public Rigidbody rigidbody;
    //private float joyAngle;
    //public float rotationSpeed;
    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {

        rigidbody.velocity = new Vector3(joystick.Horizontal * 5f, rigidbody.velocity.y, joystick.Vertical * 5f);

        transform.eulerAngles = new Vector3(0,Mathf.Atan2(joystick.Horizontal, joystick.Vertical) * 180 / Mathf.PI,0);

        animator.SetFloat("Speed", Mathf.Abs(joystick.Horizontal));
        
        
        

    }
}
