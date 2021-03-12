using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Build UI", menuName = "Build Card")]
public class BuildingSO : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite artWork;

    public int oreCost;
    public int freeOreCost;
    public int buildingLevel;
    




}
