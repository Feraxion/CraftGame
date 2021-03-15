using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineableOre : MonoBehaviour
{
    
    public GameObject shatteredVersion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
       
            //Shatter();
            
        
    }

    public void Shatter()
    {
        //shatteredVersion.transform.localScale = gameObject.transform.localScale;
        Instantiate(shatteredVersion, transform.position, transform.rotation);
        Destroy(gameObject);
        
    }
}
