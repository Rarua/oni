using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    
    [SerializeField] GameObject GameManager;
    GameDirector Director;
    int dame = 1;
    // Start is called before the first frame update
    void Start()
    {
        Director = GameManager.GetComponent<GameDirector>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider t)
    {
        if (t.gameObject.tag == "Player")
        {
            Director.death(t.gameObject.GetComponent<Playercontrora>().No, dame);
        }
    }
}
