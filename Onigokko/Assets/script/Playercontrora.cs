using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;  // 追加しましょう

public class Playercontrora : MonoBehaviour
{
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject GameClear;
    [SerializeField] GameObject GameAbutton;
    public float KeyOpen = 3.0f;
    public int No = 1;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if ((this.transform.position - oniObject.transform.position).magnitude <= 500.0f)
        //{
        //    //this.GetComponent<Move>().enabled = false;
        //}
    }
    void OnTriggerEnter(Collider t)
    {
        if (t.gameObject.tag == "Gate")
        {
            coroutine=OpenKey(t.gameObject);
            StartCoroutine(coroutine);
        }
        //if(t.gameObject.tag == "Goal")
        //{
        //    GameClear.SetActive(true);
        //    //ここから鍵を落とす処理
        //    KeyDrop();
        //    Destroy(this.gameObject);
        //}
    }
    private IEnumerator OpenKey(GameObject Gate)
    {
        while (true)
        {
            var ma = oyako.ChildrenSearch.GetChildren(this.gameObject);
            for (int i = 0; i < ma.Length; i++)
            {
                if (ma[i].GetComponent<Keycontrotry>() != null)
                {
                    //1つ以上鍵がある
                    //ぼたんを押すと
                    var key = ma[i].GetComponent<Keycontrotry>();
                    if (Gate.GetComponent<Gate>().GateNo == key.no)
                    {
                        GameAbutton.SetActive(true);
                        Debug.Log("Aプッシュ！！");
                        while (GameAbutton.GetComponent<botun>().gauge() < 3.0f)
                        {
                            yield return null;
                        }
                        Debug.Log("終わり！！！閉廷！！！！");
                        Gate.GetComponent<Gate>().GateOpen();
                        Destroy(key.gameObject);
                        GameAbutton.GetComponent<botun>().OFF();
                        break;
                    }
                }
            }
        yield return null;
        }
    }
    void OnTriggerExit(Collider t)
    {
        if (t.gameObject.tag == "Gate") {
            StopCoroutine(coroutine);
            GameAbutton.GetComponent<botun>().OFF();
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
