    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderBuilding : MonoBehaviour
{
    
    public BuildingUIDisplayForTrader buildUI;
    
    public new string name;
    public string description;

    //public Sprite artWork;


    public int buildingLevel;
    public int tradeCost;
    public int oreCost;

    public int randomOreCost;
    public int totalOre;

    
    void Update()
    {

        if (buildUI.gameObject.activeInHierarchy)
        {
            TradeAmountUpdater();
            buildUI.UITextUpdater();
        }
        
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        //6-16
        buildingLevel = GameDataSaver.healingBuildingLevel;
        RandomizeTradeOffer();
        TradeAmountUpdater();
        Invoke("TradeAmountUpdater",2);

    }

    void RandomizeTradeOffer()
    {
        randomOreCost = Random.Range(6, 17);
        buildUI.UITextUpdater();
    }

    void TradeAmountUpdater()
    {
        totalOre = GameDataSaver.oreAmount;
        tradeCost = totalOre * randomOreCost;
        oreCost = totalOre / randomOreCost;
        buildUI.UITextUpdater();

    }

    //Buttonlarin OnClickine atiyoruz
    public void TradeAll()
    {
        if (GameDataSaver.oreAmount >= 1)
        {
            GameDataSaver.coinAmount += tradeCost;
            GameDataSaver.oreAmount = 0;

            
            
            Debug.Log("Upgrade Success");
            
        }else{Debug.Log("notEnoughCoin");}
        
    }
    
    public void TradeHalf()
    {
        if (GameDataSaver.oreAmount >= 1)
        {
            GameDataSaver.coinAmount += tradeCost / 2 ;
            GameDataSaver.oreAmount = totalOre/2;

            
            
            Debug.Log("Upgrade Success");
            
        }else{Debug.Log("notEnoughCoin");}
        
    }
    
    public void ChangeOffer()
    {
        
            RandomizeTradeOffer();
            TradeAmountUpdater();
            Debug.Log("Change Success");
            buildUI.UITextUpdater();
        
    }
    
}
