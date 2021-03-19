using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildUIDisplayStoneMine : MonoBehaviour
{
    
    public StoneMillBuilding build;

    public TMP_Text nameText;
    public TMP_Text buildingLevelText;
    public TMP_Text ProductionPerMinText;
    //public TMP_Text currentStoredOreAmountText;
    public TMP_Text descriptionText;
    public TMP_Text coinCostButtonText;
    public TMP_Text adButtonText;
    
    void Start()
    {

        nameText.text = build.name;
        descriptionText.text = build.description;
        ProductionPerMinText.text = $"Production Per Minute: {build.productionPerMin}";
        coinCostButtonText.text = $"{build.upgradeCost} Coin";
        adButtonText.text = $"{build.upgradeWithAdCost} Coin + Watch AD";
        buildingLevelText.text = $"Level {build.buildingLevel}";
        
        //Startta updatelenmeyebiliyor bazen ondan 4 saniye sonra safe cagiriyorum zaten upgradeleyince herhangi bir buildi cagiriyor bunu ve CostCalculationsi
        Invoke("UITextUpdater",4);
    }

    public void UITextUpdater()
    {
        nameText.text = build.name;
        descriptionText.text = build.description;
        ProductionPerMinText.text = $"Production Per Minute: {build.productionPerMin}";
        coinCostButtonText.text = $"{build.upgradeCost} Coin";
        adButtonText.text = $"{build.upgradeWithAdCost} Coin + Watch AD";
        buildingLevelText.text = $"Level {build.buildingLevel}";
        
    }

    // private void Update()
    // {
    //     nameText.text = build.name;
    //     descriptionText.text = build.description;
    //     ProductionPerMinText.text = $"Production Per Minute: {build.productionPerMin}";
    //     coinCostButtonText.text = $"{build.upgradeCost} Coin";
    //     adButtonText.text = $"{build.upgradeWithAdCost} Coin + Watch AD";
    //     buildingLevelText.text = $"Level {build.buildingLevel}";    }
}
