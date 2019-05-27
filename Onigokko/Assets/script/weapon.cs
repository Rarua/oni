using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider t)
    {
        if (t.gameObject.tag == "Player")
        {
            t.gameObject.GetComponent<Playercontrora>().death();
        }
    }
}
