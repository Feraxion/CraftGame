using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Mine UI System")]
   // [SerializeField] GameObject mineNumPrefab;  ------> IF WE ADD VISUAL SYSTEM WE WILL NEED THIS CODE 
    [SerializeField] TMP_Text oresCount;

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Ore"))
        {
            GameDataSaver.oreAmount++;
            Destroy(col.gameObject);
            oresCount.text = GameDataSaver.oreAmount.ToString();
            
            


            //Adding mine visual system
        }
    }

}
