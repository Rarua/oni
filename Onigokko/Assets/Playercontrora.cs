using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう

public class Playercontrora : MonoBehaviour
{
    [SerializeField] GameObject oniObject;
    [SerializeField] GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if((this.transform.position - oniObject.transform.position).magnitude<=500.0f)
        {
            GameOver.SetActive(true);
            this.GetComponent<Move>().enabled = false;
        }
    }
    void OnTriggerEnter(Collider t)
    {
        if(t.gameObject.tag=="Key")
        {

        }
    }
}
