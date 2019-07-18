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
    private Animator animator;
    botun m_Abutton;
    public int m_Keynum = 0;
    public float KeyOpen = 200.0f;
    public int No = 1;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
                var m = Box.GetComponent<Boxcontroty>();
                m_Abutton.Boxopentime(m.GetTaim());
                while (m_Abutton.gauge() < KeyOpen&& m.Getfura())
                {
                    m_Abutton.Boxopentime(m.GetTaim());
                    m.SetTaim(m_Abutton.gauge());
                    yield return null;
                }

                if (m.Getfura())
                {
                    m.BoxOpen(this.transform);
                }
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
                        m_Abutton.Boxopentime(Gate.GetTaim());
                        Debug.Log("Aプッシュ！！");
                        while (m_Abutton.gauge() < KeyOpen)
                        {
                            m_Abutton.Boxopentime(Gate.GetTaim());
                            Gate.SetTaim(m_Abutton.gauge());
                            yield return null;
                        }
                        Debug.Log("終わり！！！閉廷！！！！");
                        Gate.GateOpen();
                        m_Keynum--;
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
            t.gameObject.GetComponent<Gate>().SetTaim(m_Abutton.gauge());
            m_Abutton.OFF();
        }
        if (t.gameObject.tag == "Box")
        {
            StopCoroutine(coroutine);
            t.gameObject.GetComponent<Boxcontroty>().SetTaim(m_Abutton.gauge());
            m_Abutton.OFF();
        }
    }
    public bool death(int dame)
    {
        HP -= dame;
        if (HP <= 0&& HP > -10000000)
        {
           // Debug.Log("atata");
          //  StartCoroutine(anim());
           // animator.SetTrigger("Die");
            GameOver.SetActive(true);
            delete();
            HP = -10000000;
            return true;
            
        }
        return false;
    }
    public bool clear()
    {
        GameClear.SetActive(true);
        KeyDrop();
        delete();
        return true;
    }
    void delete()
    {
        //ここから鍵を落とす処理

        KeyDrop();
        Destroy(this.gameObject);

    }
    private IEnumerator anim()
    {
        //yield return new WaitForSeconds(2.0f);
        //var ma = StartCoroutine(WaitAnimationEnd("idle"));
        yield return null;
    }
    private IEnumerator WaitAnimationEnd(string animatorName)
    {
        bool finish = false;
        while (!finish)
        {
            AnimatorStateInfo nowState = animator.GetCurrentAnimatorStateInfo(0);
            if (nowState.IsName(animatorName))
            {
                finish = true;
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
    void KeyDrop()
    {
        var Childrens = oyako.ChildrenSearch.GetChildren(this.gameObject);
        var manager = GameObject.FindWithTag("KeyManager");
        int j = 0;
        Debug.Log("!!!!!!!!!!!!!!!!!!!!!!!!");
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
        Debug.Log(ma.Count);
        manager.GetComponent<KeyManager>().KeySpawn(ma,j);

    }
}
