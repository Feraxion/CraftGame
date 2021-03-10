﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    protected Joystick joystick;


    void Start()
    {
        joystick = FindObjectOfType<Joystick>();
    }
    void Update()
    {
        var rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = new Vector3(joystick.Horizontal * 5f, rigidbody.velocity.y, joystick.Vertical * 5f);
    }
}
