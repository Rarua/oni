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
    public GameObject ka1;
    int Keynum = 2;
    GameObject[] mam;
    List<GameObject> AKeylist = new List<GameObject>();
    List<GameObject> BKeylist = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        mam = oyako.ChildrenSearch.GetChildren(this.gameObject);
        //int[,] Noka;
        //Dictionary<int, GameObject> fraieh = new Dictionary<int, GameObject>();


        for (int i = 1; i < mam.Length; i++)
        {
            int m = Random.Range(0, 2);
            Debug.Log(m);
            if (m != 0)
            {
                AKeylist.Add(mam[i]);
                mam[i].GetComponent<Keycontrotry>().SetNo(Gate.Gatetype.One);
            }
            else
            {
                BKeylist.Add(mam[i]);
                mam[i].GetComponent<Keycontrotry>().SetNo(Gate.Gatetype.Two);
            }
        }
        while (AKeylist.Count < (mam.Length / 2))
        {
            Debug.Log("a");
            var masma = Random.Range(0, BKeylist.Count);
            BKeylist[masma].GetComponent<Keycontrotry>().SetNo(Gate.Gatetype.One);
            AKeylist.Add(BKeylist[masma]);
            BKeylist.Remove(BKeylist[masma]);
        }
        while (BKeylist.Count < mam.Length / 2)
        {
            Debug.Log("b");
            var masma = Random.Range(0, AKeylist.Count);
            AKeylist[masma].GetComponent<Keycontrotry>().SetNo(Gate.Gatetype.Two);
            BKeylist.Add(AKeylist[masma]);
            AKeylist.Remove(AKeylist[masma]);
        }
        for(int i=0;i< Keynum;i++)
        {
          KeySpawn(AKeylist);
          KeySpawn(BKeylist);
        }

    }

    // Update is called once per frame
    void Update()
    {

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
    void KeySpawn(List<GameObject> Keylist)
    {
        var SpawnNo = Random.Range(0, Keylist.Count);
        Keylist[SpawnNo].SetActive(true);
        Keylist[SpawnNo].transform.parent = null;
        Keylist.Remove(Keylist[SpawnNo]);
    }
}