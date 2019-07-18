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
    private Animator animator;
    private Keycontrotry kajin = null;
    private float taim = 0.0f;
    private bool m_fura = true;
    public AudioClip[] SE = new AudioClip[2];
    private SpriteRenderer m_SpriteRenderer;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
        kajin.gameObject.SetActive(true);
        this.GetComponent<CapsuleCollider>().enabled = true;
        taim = 0.0f;
        m_fura = true;
        animator.Play("CloseAnime");
    }
    public void BoxOpen(Transform player)
    {
        if (kajin)
        {
            var n = oyako.ChildrenSearch.GetChildren(this.gameObject);
            audioSource.PlayOneShot(SE[0]);
            for (int i=0;i<n.Length;i++)
            {
                if(n[i].GetComponent<Keycontrotry>())
                {
                    n[i].GetComponent<Keycontrotry>().GetKey(player);
                }
            }
            this.transform.parent.GetComponent<KeyManager>().Bomb1(no, this);
        }
        else
        {
            audioSource.PlayOneShot(SE[1]);
            StartCoroutine(OpenBox());
        }
        animator.Play("Take 001");
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
        yield return new WaitForSeconds(4.5f);
        this.gameObject.SetActive(false);
        yield return null;
    }
}
