using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // 追加しましょう
public class botun : MonoBehaviour
{
    [SerializeField] GameObject Playerpoint;
    //fillAmount
    float opentaim;
    public Image UIobj;
    float time = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        opentaim = Playerpoint.GetComponent<Playercontrora>().KeyOpen;
    }

    // Update is called once per frame
    void Update()
    {
        if(Playerpoint.GetComponent<Move>().GetkeyState().A)
        {
            time += Time.deltaTime;
            UIobj.fillAmount = time / opentaim;
            if (time>= opentaim)
            {
                time = opentaim;
            }
        }
        else
        {
            Debug.Log("ばかやろーーーー");
            UIobj.fillAmount = 0.0f;
            time = 0.0f;
        }
    }
    public float gauge()
    {
        return time;
    }
    public void OFF()
    {
        time = 0.0f;
        UIobj.fillAmount = 0.0f;
        this.gameObject.SetActive(false);
    }
}
