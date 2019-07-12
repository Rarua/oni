﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour
{
    [SerializeField] List<GameObject> Player;
    List<Playercontrora> oaoa = new List<Playercontrora>();
    [SerializeField] int scene;
    int m_dame = 1;
    int count = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Player.Count; i++)
        {
            oaoa.Add(Player[i].GetComponent<Playercontrora>());
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if(count>=4)
        {
            SceneManager.LoadScene(scene);
        }

    }
    public void gate()
    {
        m_dame *= 10000;
    }
    public void death(int No,int dame)
    {
        No--;
        oaoa[No].death(dame* m_dame);
        count++;
    }
    public void clear(int No)
    {
        No--;
        oaoa[No].clear();
        count++;
    }
}
