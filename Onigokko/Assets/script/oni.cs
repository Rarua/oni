using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GamepadInput;

public class oni : MonoBehaviour
{
    public Collider sword;
    private bool attak = true;
    private IEnumerator coroutine;
    private Animator animator;
    public Move m_move;
    //Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        m_move = this.GetComponent<Move>();
        //coroutine = attac();
    }

    // Update is called once per frame
    void Update()
    {
        var k = m_move.GetkeyState();

       // Debug.Log(attak);
        if (k != null)
        {
            if (k.A && attak == true)
            {
                coroutine = attac();
                StartCoroutine(coroutine);
                attak = false;
                animator.SetTrigger("Attack 01");
            }
        }
    }
    private IEnumerator attac()
    {
        //Debug.Log(1);
        yield return new WaitForSeconds(2.0f);
        attak = true;
        yield break;
        // yield return null;
    }
    void attackStart()
    {
        sword.enabled = true;
    }
    void attackEnd()
    {
        sword.enabled = false;
    }
}
