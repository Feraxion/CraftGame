using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuildUIDisplay : MonoBehaviour
{
    public BuildingSO build;

    public TMP_Text nameText;
    public TMP_Text buildingLevelText;

    public TMP_Text descriptionText;

    public Image artWorkImage;
    public TMP_Text oreCost;
    public TMP_Text freeOreCost;
    
    void Start()
    {
        build.buildingLevel = GameDataSaver.stoneMineLevel;
        nameText.text = build.name;
        descriptionText.text = build.description;

        artWorkImage.sprite = build.artWork;
        oreCost.text = build.oreCost.ToString();
        freeOreCost.text = build.freeOreCost.ToString();
        buildingLevelText.text = build.buildingLevel.ToString();

    }
    
    

}
