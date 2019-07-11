using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keycontrotry : MonoBehaviour
{
   // public GameObject[] Gatepoint;
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
    public void GetKey(Transform transform)
    {
        var mam1 = oyako.ChildrenSearch.GetChildren(this.gameObject);
        mam1[1].gameObject.GetComponent<MeshRenderer>().enabled = false;
        this.transform.parent = transform;
    }
}
