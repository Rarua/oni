using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public enum Gatetype
    {
        One, Two
    }
    public Gate.Gatetype GateNo;
    public GameObject manager;
    GameDirector ms;
    int Keynum = 0;
    // Start is called before the first frame update
    void Start()
    {
        ms = manager.GetComponent<GameDirector>();

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void GateOpen()
    {
        StartCoroutine(Open());
    }
    private IEnumerator Open()
    {
        Keynum++;
        if (Keynum >= 2)
        {
            this.GetComponent<BoxCollider>().enabled = false;
            while (transform.rotation.y <= 90.0) {
                transform.rotation = new Quaternion(0.0f, transform.rotation.y+1.5f, 0.0f,1.0f);
                yield return null;
            }
            transform.rotation = new Quaternion(0.0f,90.0f, 0.0f, 1.0f);
            ms.gate();
        }
        yield break;
        // コルーチンの処理  
    }
}
