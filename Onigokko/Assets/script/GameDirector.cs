using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameDirector : MonoBehaviour
{
    [SerializeField] List<GameObject> Player;
    List<Playercontrora> oaoa = new List<Playercontrora>();
    [SerializeField] int scene;
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
    public void death(int No)
    {
        No--;
        oaoa[No].death();
        count++;
    }
    public void clear(int No)
    {
        No--;
        oaoa[No].clear();
        count++;
    }
}
