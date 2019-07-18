using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tyen : MonoBehaviour
{
    public AudioClip SE;
    private bool furag = true;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (furag&&gameObject.transform.position.y <= -1.0f)
        {
            audioSource.PlayOneShot(SE);
            furag = false;
        }
    }
}
