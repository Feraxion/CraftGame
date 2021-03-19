using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingUI : MonoBehaviour
{
    public GameObject upgradePopup;
    public LayerMask whatIsPlayer;
    public bool playerIsNear;
    public Vector3 colliderPosition,scaleSize;
    
    
    // Start is called before the first frame update
    /*void Start()
    {
        //elle ayarladim degistirilebilir
        colliderPosition = gameObject.transform.position;
        colliderPosition.y -= 5f;
        colliderPosition.x -= 10f;
    }*/

    // Update is called once per frame
    void Update()
    {
        playerIsNear = Physics.CheckBox(colliderPosition, scaleSize / 2,Quaternion.identity,whatIsPlayer);

        if (playerIsNear == true)
        {
            upgradePopup.SetActive(true);
        }else{upgradePopup.SetActive(false);}
    }
    
    
    private void OnDrawGizmosSelected()
    {
        //elle ayarladim degisir
        
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(colliderPosition, scaleSize);
        
    }

    public void OnLeave()
    {
        upgradePopup.SetActive(false);
    }
}
