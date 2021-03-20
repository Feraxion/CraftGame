using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuild : MonoBehaviour
{
    public GameObject TowerUI;
    public bool isBuilt;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildTower()
    {
        if (GameDataSaver.oreAmount > 50)
        {
            GameDataSaver.oreAmount -= 50;
            isBuilt = true;
            Instantiate(GameAssets.Instance.pfArrowTower, gameObject.transform.position, new Quaternion(0f,-180f,0f,0f));
            TowerUI.SetActive(false);

        }else {Debug.Log("Failed to build");}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!isBuilt)
            {
                TowerUI.SetActive(true);
            }
        }

        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            TowerUI.SetActive(false);
        }    
    }
}
