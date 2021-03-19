using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneMillBuilding : MonoBehaviour
{

    public int maxOreLimit;
    public float timer,timerMax;
    public BuildUIDisplayStoneMine buildUI;
    
    public new string name;
    public string description;
    public bool playerIsNear;

    //public Sprite artWork;

    public bool showAd;
    public int buildingLevel;
    public int upgradeCost;
    public int upgradeWithAdCost;
    public int productionPerMin;
    public int currentStoredOreAmount;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
        buildingLevel = GameDataSaver.stoneMineLevel;
        currentStoredOreAmount = GameDataSaver.stoneMineStoredOreAmount;
       
        
        CostCalculations();
        
    }

    // Update is called once per frame
    void Update()
    {
       
        
        //Ore generation
        timer -= Time.deltaTime;
        if (timer <= 0f) {
            timer += timerMax;
            currentStoredOreAmount += productionPerMin / 60;
        }

        if (maxOreLimit <= currentStoredOreAmount)
        {
            currentStoredOreAmount = maxOreLimit;
        }
        
        //Player triggera girdiginde binada depolanan orelari oyuncuya aktariyor
        playerIsNear = gameObject.GetComponent<BuildingUI>().playerIsNear;
        if (playerIsNear)
        {
            GameDataSaver.oreAmount += currentStoredOreAmount;
            currentStoredOreAmount = 0;
        }
    }

    public void CostCalculations()
    {
        //Uida gostermek icin
        productionPerMin = 120 * buildingLevel;
        maxOreLimit = buildingLevel * 240;
        
        
        //Upgrade cost hesaplamasi
        upgradeCost = 40 * buildingLevel;
        upgradeWithAdCost = 30 * buildingLevel ;
    }

    
    
    //Buttonlarin OnClickine atiyoruz
    public void Upgrade()
    {
        if (GameDataSaver.coinAmount >= upgradeCost)
        {
            GameDataSaver.coinAmount -= upgradeCost;
            buildingLevel++;
            Debug.Log("Upgrade Success");
            
            CostCalculations();
        }else{Debug.Log("notEnoughCoin");}
        
        buildUI.UITextUpdater();
    }
    
    //Buttonlarin OnClickine atiyoruz
    public void UpgradeWithAd()
    {
        if (GameDataSaver.coinAmount >= upgradeWithAdCost)
        {
            GameDataSaver.coinAmount -= upgradeWithAdCost;
            buildingLevel++;
            showAd = true;
            Debug.Log("Upgrade Success");
            
            CostCalculations();
            
        }else{Debug.Log("notEnoughCoin");}
        buildUI.UITextUpdater();

    }
}
