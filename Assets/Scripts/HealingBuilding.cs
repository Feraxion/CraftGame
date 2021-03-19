using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealingBuilding : MonoBehaviour
{
    
    
    
    public StatSystem statSystem;
    
    
    public new string name;
    public string description;

    //public Sprite artWork;


    public int buildingLevel;
    public int upgradeCost;

    
    void Update()
    {
       
        
        
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        buildingLevel = GameDataSaver.healingBuildingLevel;

        upgradeCost = 50;
    }


    //Buttonlarin OnClickine atiyoruz
    public void Heal()
    {
        if (GameDataSaver.coinAmount >= upgradeCost)
        {
            GameDataSaver.coinAmount -= upgradeCost;
            statSystem.playerHealth *= 1.30f;
            Debug.Log("Upgrade Success");
            
        }else{Debug.Log("notEnoughCoin");}
        
    }
    
    
}
