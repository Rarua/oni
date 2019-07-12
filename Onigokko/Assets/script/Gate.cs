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
            while (transform.position.y>=0) {
                transform.position = new Vector3(transform.position.x, transform.position.y - 10.0f, transform.position.z);
                yield return null;
            }
            ms.gate();
            Destroy(this.gameObject);
        }
        yield break;
        // コルーチンの処理  
    }
}
