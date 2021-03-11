using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    [Header("Mine UI System")]
    [SerializeField] GameObject mineNumPrefab;
    [SerializeField] public int mines;
    [SerializeField] TMP_Text minesCount;

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Mine"))
        {
            mines++;
            Destroy(col.gameObject);
            minesCount.text = mines.ToString();

            //Adding mine visual system
        }
    }

}
