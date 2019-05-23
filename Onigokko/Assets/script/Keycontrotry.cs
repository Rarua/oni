using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycontrotry : MonoBehaviour
{
    public GameObject[] Gatepoint;
    public Gate.Gatetype no;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(this.name);
        //Debug.Log(no);
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SetNo(Gate.Gatetype No)
    {
        no = No;
    }
    void OnTriggerStay(Collider t)
    {
        if (t.gameObject.tag == "Player"&& this.transform.parent==null)
        {
            this.transform.parent = t.transform;
            this.GetComponent<MeshRenderer>().enabled = false;
            //this.GetComponent<CapsuleCollider>().enabled = false;
        }
        //Debug.Log(t.gameObject.tag);

    }
}
