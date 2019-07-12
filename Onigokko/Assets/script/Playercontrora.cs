using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう

public class Playercontrora : MonoBehaviour
{
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject GameClear;
    [SerializeField] GameObject GameAbutton;
    [SerializeField] int HP = 2;
    botun m_Abutton;
    public float KeyOpen = 3.0f;
    public int No = 1;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Staaaaato");
        m_Abutton = GameAbutton.GetComponent<botun>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter(Collider t)
    {
        if (t.gameObject.tag == "Gate")
        {
            coroutine = OpenKey(t.gameObject.GetComponent<Gate>());
            StartCoroutine(coroutine);
        }
        if (t.gameObject.tag == "Box")
        {
            coroutine = OpenBox(t.gameObject);
            StartCoroutine(coroutine);
        }
    }
    private IEnumerator OpenBox(GameObject Box)
    {
        while (true)
        {
            {
                Debug.Log("nana");
                GameAbutton.SetActive(true);
                while (m_Abutton.gauge() < 3.0f)
                {
                    yield return null;
                }
                Debug.Log("終わり！！！閉廷！！！！");
                Box.GetComponent<Boxcontroty>().BoxOpen(this.transform);
                m_Abutton.OFF();
                break;
            }
        }
        yield return null;
    }


    private IEnumerator OpenKey(Gate Gate)
    {
        while (true)
        {
            var ma = oyako.ChildrenSearch.GetChildren(this.gameObject);
            for (int i = 0; i < ma.Length; i++)
            {
                Debug.Log("Aプッシュ！！");
                var nm = ma[i].GetComponent<Keycontrotry>();
                if (nm)
                {
                    Debug.Log("Aプッシュ！！");
                    //1つ以上鍵がある
                    //ぼたんを押すと

                    if (Gate.GateNo == nm.no)
                    {
                        GameAbutton.SetActive(true);
                        Debug.Log("Aプッシュ！！");
                        while (m_Abutton.gauge() < 3.0f)
                        {
                            yield return null;
                        }
                        Debug.Log("終わり！！！閉廷！！！！");
                        Gate.GateOpen();
                        Destroy(nm.gameObject);
                        m_Abutton.OFF();
                    }
                }
            }
            yield break;
        }
    }
    void OnTriggerExit(Collider t)
    {
        if (t.gameObject.tag == "Gate")
        {
            StopCoroutine(coroutine);
            m_Abutton.OFF();
        }
        if (t.gameObject.tag == "Box")
        {
            StopCoroutine(coroutine);
            m_Abutton.OFF();
        }
    }
    public void death(int dame)
    {
        HP -= dame;
        if (HP <= 0)
        {
            GameOver.SetActive(true);
            delete();
        }
    }
    public void clear()
    {
        Debug.Log("五ーーーーーる");
        GameClear.SetActive(true);
        delete();
    }
    void delete()
    {
        //ここから鍵を落とす処理

        KeyDrop();
        Destroy(this.gameObject);

    }
    void KeyDrop()
    {
        var Childrens = oyako.ChildrenSearch.GetChildren(this.gameObject);
        var manager = GameObject.FindWithTag("KeyManager");
        int j = 00;
        List<Keycontrotry> ma = new List<Keycontrotry>();
        for (int i = 0; i < Childrens.Length; i++)
        {
            if (Childrens[i].tag == "key")
            {
                ma.Add(Childrens[i].GetComponent<Keycontrotry>());
                j++;
                //Destroy(Childrens[i]);
            }
        }
        Debug.Log(ma);

        manager.GetComponent<KeyManager>().KeySpawn(ma,j);

    }
}
