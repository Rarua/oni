using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public GameObject ka1;
    public int Keynum = 2;
    GameObject[] mam;
    // Start is called before the first frame update
    void Start()
    {
        mam = GetChildren(this.name);
        int[,] Noka;
        Debug.Log(0);
        Noka = new int[,] { { 100, 1 }, { 200, 1 }, { 300, 1 }, { 400, 1 } };
        for (int i = 0; i < Keynum * 2; i++)
        {
            int count = 0;
            int No = 0;
            while (count < i + 1)
            {
                count = 0;
                Debug.Log(i);
                No = Random.Range(1, mam.Length);
                for (int j = 0; j <= i; j++)
                {
                    Debug.Log(j);
                    if (No != Noka[j,0])
                    {
                        count++;
                    }
                }
            }
            Noka[i,0] = No;
            Noka[i, 1] = i % 2;
        }
        for (int i = Keynum * 2; i > 0; i--)
        {
            for (int j = 1; j < i; j++)
            {
                if (Noka[j,0] < Noka[j-1,0])
                {
                    int k = 0;
                    k = Noka[j-1,0];
                    Noka[j - 1,0] = Noka[j,0];
                    Noka[j,0] = k;
                }
            }
        }
        //ここで発生する番号を決定
        //for (int i = 0; i < 4; i++)
        //{
        //    Debug.Log(Noka[i]);
        //}
        int ba = 0;
        //Debug.Log("jhujkisaf");
        for (int i = 1; i < mam.Length; i++)
        {
            if (Noka[ba,0] == i)
            {
                //ここで発生
                mam[Noka[ba,0]].SetActive(true);
                mam[Noka[ba,0]].GetComponent<Keycontrotry>().no = Noka[ba, 1];
                if (ba < 3)
                {
                    ba++;
                }
            }
            else
            {
                Destroy(mam[i]);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
    GameObject[] GetChildren(string parentName)
    {
        // 子のTransform[]を取り出す
        Transform[] transforms = this.GetComponentsInChildren<Transform>(true);
        // 使いやすいようにtransformsからgameObjectを取り出す
        var gameObjects = from t in transforms select t.gameObject;
        // 配列に変換してreturn
        return gameObjects.ToArray();
    }
}