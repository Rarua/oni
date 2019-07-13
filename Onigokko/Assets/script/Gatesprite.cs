using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatesprite : MonoBehaviour
{
    public GameObject sprit;
    public Sprite aka;
    private SpriteRenderer m_SpriteRenderer;
    void Start()
    {
        m_SpriteRenderer = sprit.GetComponent<SpriteRenderer>();
    }
    public void ChangSprite()
    {
        m_SpriteRenderer.sprite = aka;
    }
}
