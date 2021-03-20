using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Scene scene = SceneManager.GetActiveScene();
        
        if (other.gameObject.tag == "Player")
        {

            if (scene.buildIndex == 0)
            {
                SceneManager.LoadScene(1);
            }
            
            if (scene.buildIndex == 1)
            {
                SceneManager.LoadScene(0);
            }
            
        }
    }
}
