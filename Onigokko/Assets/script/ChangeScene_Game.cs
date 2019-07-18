using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene_Game : MonoBehaviour
{
    [SerializeField] int scene = 1;
    public bool m_fade = false;
    private bool frag = false;
     [SerializeField] GameObject[] m_Fade = new GameObject[2];
    Fade[] fade = new Fade[2];
    // Start is called before the first frame update

    void Start()
    {
        //    DontDestroyOnLoad(this);

        for (int i = 0; i < m_Fade.Length; i++)
        {
            fade[i] = m_Fade[i].GetComponent<Fade>();
            fade[i].FadeOut(3.0f, a213n);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_fade)
        {
            for (int i = 0; i < m_Fade.Length; i++)
            {
                fade[i].FadeIn(5.0f, an);
            }
            m_fade = false;
            frag = false;
        }
    }
    private void a213n()
    {
        frag = true;
    }
    public bool Getfura()
    {
        return frag;
    }
    private void an()
    {
        if (scene >= 4)
        {
            scene = 0;
        }
        SceneManager.LoadScene(scene);
    }
}
