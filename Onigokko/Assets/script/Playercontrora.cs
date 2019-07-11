using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう

public class Playercontrora : MonoBehaviour
{
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject GameClear;
    [SerializeField] GameObject GameAbutton;
    botun m_Abutton;
    public float KeyOpen = 3.0f;
    public int No = 1;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
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
                if (ma[i].GetComponent<Keycontrotry>())
                {
                    //1つ以上鍵がある
                    //ぼたんを押すと
                    var key = ma[i].GetComponent<Keycontrotry>();
                    if (Gate.GateNo == key.no)
                    {
                        GameAbutton.SetActive(true);
                        Debug.Log("Aプッシュ！！");
                        while (m_Abutton.gauge() < 3.0f)
                        {
                            yield return null;
                        }
                        Debug.Log("終わり！！！閉廷！！！！");
                        Gate.GateOpen();
                        Destroy(key.gameObject);
                        m_Abutton.OFF();
                    }
                    break;
                }
            }
        yield return null;
        }
    }
    void OnTriggerExit(Collider t)
    {
        if (coroutine!=null)
        {
            if (t.gameObject.tag == "Gate")
            {
                StopCoroutine(coroutine);
                coroutine = null;
                m_Abutton.OFF();
            }
            if (t.gameObject.tag == "Box")
            {
                StopCoroutine(coroutine);
                coroutine = null;
                m_Abutton.OFF();
            }
        }
    }
    public void death()
    {
        GameOver.SetActive(true);
        delete();
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
        for (int i = 0; i < Childrens.Length; i++)
        {
            if (Childrens[i].tag == "key")
            {
                manager.GetComponent<KeyManager>().KeySpawn(Childrens[i].GetComponent<Keycontrotry>().no);
                Destroy(Childrens[i]);
            }
        }
    }
}
