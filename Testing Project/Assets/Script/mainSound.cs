using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainSound : MonoBehaviour
{
    public AudioSource attackSound;
    public AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.L))
        {
            attackSound.Play();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpSound.Play();
        }
    }
}
