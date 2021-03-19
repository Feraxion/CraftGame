using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildingUIDisplayHealingBuild : MonoBehaviour
{
    public HealingBuilding build;

    public TMP_Text nameText;
    public TMP_Text buildingLevelText;

    public TMP_Text descriptionText;
    public TMP_Text coinCostButtonText;
    
    void Start()
    {

        nameText.text = build.name;
        descriptionText.text = build.description;
        coinCostButtonText.text = $"{build.upgradeCost} Coin";
        buildingLevelText.text = $"Level {build.buildingLevel}";
        
        //Startta updatelenmeyebiliyor bazen ondan 4 saniye sonra safe cagiriyorum zaten upgradeleyince herhangi bir buildi cagiriyor bunu ve CostCalculationsi
        Invoke("UITextUpdater",4);
    }

    public void UITextUpdater()
    {
        nameText.text = build.name;
        descriptionText.text = build.description;
        coinCostButtonText.text = $"{build.upgradeCost} Coin";
        buildingLevelText.text = $"Level {build.buildingLevel}";
        
    }
}
