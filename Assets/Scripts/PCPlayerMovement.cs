using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCPlayerMovement : MonoBehaviour
{
    private Rigidbody PlayerRB;
    [SerializeField] private float moveSpeed;
    
    // Start is called before the first frame update
    void Start()
    {
                Application.targetFrameRate = 60;
                PlayerRB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.W))
        {
            PlayerRB.AddForce(Vector3.forward * Time.deltaTime * (moveSpeed ));
            Debug.Log("Inputttt");

        }
        
        if (Input.GetKey(KeyCode.S))
        {
            PlayerRB.AddForce(Vector3.back * Time.deltaTime * (moveSpeed));

        }
        
        if (Input.GetKey(KeyCode.A))
        {
            PlayerRB.AddForce(Vector3.left * Time.deltaTime * (moveSpeed));
        }

        if (Input.GetKey(KeyCode.D))
        {
            PlayerRB.AddForce(Vector3.right * Time.deltaTime *(moveSpeed));
        }
    }
}
