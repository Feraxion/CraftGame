using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BuildingUIDisplayForTrader : MonoBehaviour
{
    
    public TraderBuilding build;

    public TMP_Text nameText;
    public TMP_Text buildingLevelText;
    public TMP_Text tradeAllText,tradeHalfText;


    public TMP_Text descriptionText;
    public TMP_Text adButtonText;
    public TMP_Text changeOfferText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = build.name;
        descriptionText.text = build.description;
        buildingLevelText.text = $"Level {build.buildingLevel}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
    public void UITextUpdater()
    {
        nameText.text = build.name;
        descriptionText.text = build.description;
        buildingLevelText.text = $"Level {build.buildingLevel}";
        tradeAllText.text = $"{build.totalOre} ore  for {build.oreCost} coin";
        tradeHalfText.text = $"{build.totalOre /2} ore  for {build.oreCost / 2} coin";
        changeOfferText.text = "Change Offer";

    }
}
