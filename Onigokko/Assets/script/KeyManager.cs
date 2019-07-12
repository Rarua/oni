using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace oyako
{
    public static class ChildrenSearch
    {
        public static GameObject[] GetChildren(GameObject parentName)
        {
            // 子のTransform[]を取り出す
            Transform[] transforms = parentName.GetComponentsInChildren<Transform>(true);
            // 使いやすいようにtransformsからgameObjectを取り出す
            var gameObjects = from t in transforms select t.gameObject;
            // 配列に変換してreturn
            return gameObjects.ToArray();
        }
    }

}

public class KeyManager : MonoBehaviour
{
    public int Keynum = 2;
    public int Boxnum = 5;
    List<GameObject> mam = new List<GameObject>();
    List<float>  AspoonNo= new List<float>();
    List<float> BspoonNo = new List<float>();
    List<Boxcontroty> AKeylist = new List<Boxcontroty>();
    List<Boxcontroty> BKeylist = new List<Boxcontroty>();
    // Start is called before the first frame update
    void Start()
    {
        var mam1 = oyako.ChildrenSearch.GetChildren(this.gameObject);
        //int[,] Noka;
        //Dictionary<int, GameObject> fraieh = new Dictionary<int, GameObject>();

        for(int i=0;i< mam1.Length;i++)
        {
            if(mam1[i].GetComponent<Boxcontroty>())
            {
                mam.Add(mam1[i]);
            }
        }
        Debug.Log(mam1.Length);
        Debug.Log(mam.Count);
        for (int i = 0; i < mam.Count; i++)
        {
            int m = Random.Range(0, 2);
            Debug.Log(m);
            if (m != 0)
            {
                AKeylist.Add(mam[i].GetComponent<Boxcontroty>());
                AKeylist[AKeylist.Count-1].SetNo(Gate.Gatetype.One);
            }
            else
            {
                BKeylist.Add(mam[i].GetComponent<Boxcontroty>());
                BKeylist[BKeylist.Count-1].SetNo(Gate.Gatetype.Two);
            }
        }

        Debug.Log(AKeylist.Count);
        while (AKeylist.Count < (mam.Count / 2))
        {
            var masma = Random.Range(0, BKeylist.Count);
            BKeylist[masma].SetNo(Gate.Gatetype.One);
            AKeylist.Add(BKeylist[masma]);
            BKeylist.Remove(BKeylist[masma]);
        }
        while (BKeylist.Count < mam.Count / 2)
        {
            var masma = Random.Range(0, AKeylist.Count);
            AKeylist[masma].SetNo(Gate.Gatetype.Two);
            BKeylist.Add(AKeylist[masma]);
            AKeylist.Remove(AKeylist[masma]);
            BspoonNo.Add(0);
        }
        //ここで振り分けが決定
        while (AKeylist.Count > Boxnum)
        {
            Debug.Log("nananan");
            var masma = Random.Range(0, AKeylist.Count);
            var Object = AKeylist[masma];
            AKeylist.Remove(AKeylist[masma]);
            Destroy(Object.gameObject);
        }
        while (BKeylist.Count > Boxnum)
        {
            Debug.Log("nananan0121321");
            var masma = Random.Range(0, BKeylist.Count);
            var Object = BKeylist[masma];
            BKeylist.Remove(BKeylist[masma]);
            Destroy(Object.gameObject);
        }
        for(int i=0;i< Boxnum; i++)
        {
            AspoonNo.Add(0);
            BspoonNo.Add(0);
        }
        //数を調整
        for (int i = 0; i < Keynum; i++)
        {
            KeySpawn(AKeylist, AspoonNo);
            KeySpawn(BKeylist, BspoonNo);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Bomb(Gate.Gatetype No, Boxcontroty takara)
    {
        if (No == Gate.Gatetype.One)
        {
            AspoonNo.Remove(AspoonNo[AKeylist.IndexOf(takara)]);
            AKeylist.Remove(takara);
        }
        else
        {
            BspoonNo.Remove(BspoonNo[BKeylist.IndexOf(takara)]);
            BKeylist.Remove(takara);
        }
    }
    public void KeySpawn(List<Keycontrotry> No,int kosuu)
    {
        for (int i = 0; i < AspoonNo.Count; i++)
        {
            AspoonNo[i] = 0;
        }
        for (int i = 0; i < BspoonNo.Count; i++)
        {
            BspoonNo[i] = 0;
        }
        for (int i = 0; i < kosuu; i++)
        {
            if (No[i].no == Gate.Gatetype.One)
            {
                KeySpawn(AKeylist, AspoonNo);
            }
            else
            {
                KeySpawn(BKeylist, BspoonNo);
            }
        }
    }
    void KeySpawn(List<Boxcontroty> Keylist, List<float> an)
    {
        int SpawnNo = 0;
        int bagu = 0;
        do
        {
            SpawnNo = Random.Range(0, Keylist.Count);
            bagu++;
        } while (an[SpawnNo] != 0&& bagu<=10000);
        Keylist[SpawnNo].GetComponent<Boxcontroty>().sporn();
        an[SpawnNo] = 1;
    }
}