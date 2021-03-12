using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreGenerator : MonoBehaviour
{


    [SerializeField] private float timer,timerMax;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f) {
            timer += timerMax;
            GameDataSaver.oreAmount += ((120 * GameDataSaver.stoneMineLevel) / 60);
        }
    }
}
