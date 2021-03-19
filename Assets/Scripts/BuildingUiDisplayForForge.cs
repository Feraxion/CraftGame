using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BuildingUiDisplayForForge : MonoBehaviour
{
    public ForgeBuilding build;

    public TMP_Text nameText;
    public TMP_Text buildingLevelText;
    public TMP_Text costAttackUpgradeText,costHealthUpgradeText;


    public TMP_Text descriptionText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        nameText.text = build.name;
        descriptionText.text = build.description;
        //buildingLevelText.text = $"Level {build.buildingLevel}";
        UITextUpdater();
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
        costAttackUpgradeText.text = $"{build.costForAttackUpgrade}";
        costHealthUpgradeText.text = $"{build.costForHealthUpgrade}";


    }
}
