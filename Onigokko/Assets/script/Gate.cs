using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate : MonoBehaviour
{
    public enum Gatetype
    {
        One, Two
    }
    public Gatetype GateNo;
    public GameObject manager;
    public GameObject sprite;
    public GameObject[] kusari = new GameObject[2];
    private float taim = 0.0f;
    GameDirector ms;
    Gatesprite sp;
    int Keynum = 0;
    // Start is called before the first frame update
    void Start()
    {
        ms = manager.GetComponent<GameDirector>();
        sp = sprite.GetComponent<Gatesprite>();

    }

    // Update is called once per frame
    void Update()
    {
    }
    public void GateOpen()
    {
        StartCoroutine(Open());
        taim = 0.0f;
    }
    private IEnumerator Open()
    {
        Keynum++;
        var pos = kusari[Keynum - 1].transform;
        while (pos.position.y >= -10.0f)
        {
            pos.position = new Vector3(pos.position.x, pos.position.y - 1.0f, pos.position.z);
            yield return null;
        }
        if (Keynum >= 2)
        {
            float kaku = 0.0f;
            sp.ChangSprite();
            this.GetComponent<BoxCollider>().enabled = false;
            while (kaku <= 90.0f)
            {
                kaku += 30.0f * Time.deltaTime;
                transform.eulerAngles = new Vector3(0, kaku, 0);
                yield return null;
            }
            transform.eulerAngles = (new Vector3(0, 90, 0));
            ms.gate();
        }
        yield break;
        // コルーチンの処理  
    }
    public void SetTaim(float Taim)
    {
        taim = Taim;
    }
    public float GetTaim()
    {
        return taim;
    }
}
