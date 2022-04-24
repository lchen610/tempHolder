using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ability : MonoBehaviour
{
    public Image ability1;
    public float cd1 = 5;
    public KeyCode ability1key = KeyCode.K;
    bool is1Cooldown = false;

    public Image ability2;
    public float cd2 = 5;
    public KeyCode ability2key = KeyCode.L;
    bool is2Cooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        ability1.fillAmount = 0;
        ability2.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        ab1();
        ab2();
    }

    void ab1()
    {
        if(Input.GetKey(ability1key) && is1Cooldown == false)
        {
            is1Cooldown = true;
            ability1.fillAmount = 1;
        }
        if (is1Cooldown == true)
        {
            ability1.fillAmount -= 1 / cd1 * Time.deltaTime;

            if(ability1.fillAmount <= 0)
            {
                ability1.fillAmount = 0;
                is1Cooldown = false;
            }
        }
    }

    void ab2()
    {
        if (Input.GetKey(ability2key) && is2Cooldown == false)
        {
            is2Cooldown = true;
            ability2.fillAmount = 1;
        }
        if (is2Cooldown == true)
        {
            ability2.fillAmount -= 1 / cd2 * Time.deltaTime;

            if (ability2.fillAmount <= 0)
            {
                ability2.fillAmount = 0;
                is2Cooldown = false;
            }
        }
    }
}
