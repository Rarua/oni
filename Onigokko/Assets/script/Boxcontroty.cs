using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boxcontroty : MonoBehaviour
{
    public GameObject kaji;
    public GameObject sprit;
    public GameObject efecto;
    public Gate.Gatetype no;
    public Sprite aka;
    private Keycontrotry kajin = null;
    private float taim = 0.0f;
    private bool m_fura = true;
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
        taim = 0.0f;
        m_fura = false;
        this.GetComponent<CapsuleCollider>().enabled = false;
    }
    public void SetTaim(float Taim)
    {
        taim = Mathf.Max(taim, Taim);
    }
    public float GetTaim()
    {
        return taim;
    }
    public bool Getfura()
    {
        return m_fura;
    }
    private IEnumerator OpenBox()
    {
        this.transform.parent.GetComponent<KeyManager>().Bomb(no, this);
        m_SpriteRenderer.sprite = aka;
        //エフェクト
        efecto.SetActive(true);
        yield return new WaitForSeconds(6.0f);
        this.gameObject.SetActive(false);
        yield return null;
    }
}
