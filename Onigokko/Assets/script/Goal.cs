using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [SerializeField] GameObject GameManager;
    GameDirector game;
    // Start is called before the first frame update
    void Start()
    {
        game = GameManager.GetComponent<GameDirector>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider t)
    {
        if (t.gameObject.tag == "Player")
        {
            Debug.Log("VAJMBROJEAGBVROAEKOGVKEAGKRFA");
            game.clear(t.gameObject.GetComponent<Playercontrora>().No);
        }
    }
}
