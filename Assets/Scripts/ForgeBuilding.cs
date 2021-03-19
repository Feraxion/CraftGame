using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForgeBuilding : MonoBehaviour
{
    public BuildingUiDisplayForForge buildUI;
    
    public new string name;
    public string description;

    public int buildingLevel;
    public int costForAttackUpgrade;
    public int costForHealthUpgrade;


    
    void Update()
    {

        if (buildUI.gameObject.activeInHierarchy)
        {
            CostArranger();
            Debug.Log("serkannnnnnn");
        }
    }
    
    
    // Start is called before the first frame update
    void Start()
    {
        //6-16
        buildingLevel = 1;
        
        CostArranger();
        
    }

     void CostArranger()
    {
        costForAttackUpgrade = 30 * (GameDataSaver.forgeAttackLevel);
        costForHealthUpgrade = 30 * (GameDataSaver.forgeHealthLevel);
        buildUI.UITextUpdater();
    }

    

    //Buttonlarin OnClickine atiyoruz
    public void AttackUpgrade()
    {
        if (GameDataSaver.coinAmount >= costForAttackUpgrade)
        {
            GameDataSaver.coinAmount -= costForAttackUpgrade;
            GameDataSaver.forgeAttackLevel++;

            Debug.Log("Upgrade Success");
            CostArranger();
            
        }else{Debug.Log("notEnoughCoin");}
        
    }
    
    public void HealthUpgrade()
    {
        if (GameDataSaver.coinAmount >= costForHealthUpgrade)
        {
            GameDataSaver.coinAmount -= costForHealthUpgrade;
            GameDataSaver.forgeHealthLevel++;

            Debug.Log("Upgrade Success");
            CostArranger();

            
        }else{Debug.Log("notEnoughCoin");}
        
    }
    
    
}
