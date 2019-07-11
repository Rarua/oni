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
        //数を調整
        for (int i = 0; i < Keynum; i++)
        {
            KeySpawn(AKeylist);
            KeySpawn(BKeylist);
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
            AKeylist.Remove(takara);
        }
        else
        {
            BKeylist.Remove(takara);
        }
    }
    public void KeySpawn(Gate.Gatetype No)
    {

        if(No== Gate.Gatetype.One)
        {
            KeySpawn(AKeylist);
        }
        else
        {
            KeySpawn(BKeylist);
        }
    }
    void KeySpawn(List<Boxcontroty> Keylist)
    {
        var SpawnNo = Random.Range(0, Keylist.Count);
        Keylist[SpawnNo].GetComponent<Boxcontroty>().sporn();
    }
}