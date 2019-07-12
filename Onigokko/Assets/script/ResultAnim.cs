using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultAnim : MonoBehaviour
{
    public Animator TabAnimController;
    public GameObject m_Object;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(anim());
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator anim()
    {
        var ma = StartCoroutine(WaitAnimationEnd("atack1"));
        yield return ma;
        TabAnimController.SetTrigger("idel");
        Debug.Log(m_Object.GetComponent<Rigidbody>().isKinematic);
        m_Object.GetComponent<Rigidbody>().isKinematic = false;
    }
    private IEnumerator WaitAnimationEnd(string animatorName)
    {
        bool finish = false;
        while (!finish)
        {
            AnimatorStateInfo nowState = TabAnimController.GetCurrentAnimatorStateInfo(0);
            if (nowState.IsName(animatorName))
            {
                finish = true;
            }
            else
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
