using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxcontroty : MonoBehaviour
{
    // public GameObject[] Gatepoint;
    public Gate.Gatetype no;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SetNo(Gate.Gatetype No)
    {
        no = No;
    }
    public void sporn()
    {
        var ma = oyako.ChildrenSearch.GetChildren(this.gameObject);
        for (int i = 0; i < ma.Length; i++)
        {
            var n = ma[i].GetComponent<Keycontrotry>();
            if (n)
            {
                n.SetNo(no);
                ma[i].SetActive(true);
                break;
            }
        }
    }
    public void BoxOpen(Transform player)
    {
        var ma = oyako.ChildrenSearch.GetChildren(this.gameObject);
        for (int i = 0; i < ma.Length; i++)
        {
            var n = ma[i].GetComponent<Keycontrotry>();
            if (n)
            {
                if(ma[i].activeSelf)
                {
                   n.GetKey(player);
                }
                else
                {
                    this.transform.parent.GetComponent<KeyManager>().Bomb(no, this);
                    //エフェクト
                    this.gameObject.SetActive(false);

                }
                Debug.Log("???????");
                break;
            }
        }
    }
}
