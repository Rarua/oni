using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : MonoBehaviour
{
    public List<GameObject> Player= new List<GameObject>();
    public List<GameObject> spornpos = new List<GameObject>();
    public List<GameObject> camerpos = new List<GameObject>();
    public GameObject ennsyutu;
    public GameObject camer;
    private List<GameObject> pre = new List<GameObject>();
    int no = 0;
    // Start is called before the first frame update
    void Start()
    {
        Data.Instance.score.Add(false);
        Data.Instance.score.Add(false);
        Data.Instance.score.Add(false);
        Data.Instance.score.Add(false);
        for (int i = 0; i < Data.Instance.score.Count; i++)
        {
            if (Data.Instance.score[i])
            {
                pre.Add(Instantiate(Player[i], spornpos[no++].transform.position, Quaternion.identity) as GameObject);
            }

        }
        if(no==0)
        {
            camer.transform.position = camerpos[1].transform.position;
            camer.transform.rotation = camerpos[1].transform.rotation;
            camer.transform.parent = ennsyutu.transform;
            //鬼側に
        }
        else
        {
            for(int i=0;i< pre.Count; i++)
            {
                pre[i].transform.localScale = new Vector3(2.0f, 2.0f, 2.0f);
            }
            camer.transform.position = camerpos[0].transform.position;
            camer.transform.rotation = camerpos[0].transform.rotation;
            camer.transform.parent = camerpos[0].transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (no != 0)
        {
            for (int i = 0; i < pre.Count; i++)
            {
                pre[i].transform.position = new Vector3(pre[i].transform.position.x, pre[i].transform.position.y, pre[i].transform.position.z + 1.0f);

            }
        }
        else
        {

        }
    }
}
