using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthBarController : MonoBehaviour
{
    //0 to 100
    public Slider hp;


    public void SetMax (int health)
    {
        hp.maxValue = health;
        hp.value = health;
    }

    public void SetHealth(int health)
    {
        hp.value = health;
    }
}


