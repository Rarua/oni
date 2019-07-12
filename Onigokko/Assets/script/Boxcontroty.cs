using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxcontroty : MonoBehaviour
{
    public GameObject kaji;
    public GameObject sprit;
    public Gate.Gatetype no;
    public Sprite aka;
    private Keycontrotry kajin = null;
    private SpriteRenderer m_SpriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        m_SpriteRenderer = sprit.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SetNo(Gate.Gatetype No)
    {
        no = No;
    }
    public void sporn()
    {

        kajin = (Instantiate(kaji, this.transform.position, Quaternion.identity) as GameObject).GetComponent<Keycontrotry>();
        kajin.transform.parent = this.transform;
        kajin.SetNo(no);
        this.GetComponent<CapsuleCollider>().enabled = true;
        kajin.gameObject.SetActive(true);
    }
    public void BoxOpen(Transform player)
    {
        if (kajin)
        {
            kajin.GetKey(player);
        }
        else
        {
            StartCoroutine(OpenBox());
        }
            this.GetComponent<CapsuleCollider>().enabled = false;
    }
    private IEnumerator OpenBox()
    {
        this.transform.parent.GetComponent<KeyManager>().Bomb(no, this);
        m_SpriteRenderer.sprite = aka;
        //エフェクト
        yield return new WaitForSeconds(6.0f);
        this.gameObject.SetActive(false);
        yield return null;
    }
}
