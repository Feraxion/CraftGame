using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]private Transform playerTransform;

    [SerializeField]private float offsetX;
    [SerializeField]private float offsetY;

    [SerializeField]private float offsetZ;
    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {

        if (playerTransform == null)
        {
            return;
        }else{Vector3 camPos = transform.position;

            camPos.x = playerTransform.position.x;
            camPos.y = playerTransform.position.y;
            camPos.z = playerTransform.position.z;



            camPos.x += offsetX;
            camPos.y += offsetY;
            camPos.z += offsetZ;


            transform.position = camPos;}
    }
}
