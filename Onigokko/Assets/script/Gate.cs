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
    int Keynum = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x+10.0f, transform.position.y, transform.position.z);
    }
    public void GateOpen()
    {
        StartCoroutine(Open());
        //Open();
    }
    private IEnumerator Open()
    {
        Keynum++;
        if (Keynum >= 2)
        {
            while (transform.position.y>=0) {
                transform.position = new Vector3(transform.position.x, transform.position.y - 10.0f, transform.position.z);
                yield return null;
            }
            Destroy(this.gameObject);
        }
        yield break;
        // コルーチンの処理  
    }
}
