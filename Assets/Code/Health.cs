using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{

    public float health;
    public int numberOfHearts;

    public Image[] hearts;
    public Sprite hearts_0; public Sprite hearts_1;public Sprite hearts_2;public Sprite hearts_3;public Sprite hearts_4;


    // Update is called once per frame
    void Update()
    {
        if (health/4 > numberOfHearts)
        {
            health = numberOfHearts*4;
        }

        for (int i = 0; i < hearts.Length; i++)
        {

            if(i+1 <= health/4)
            {
                hearts[i].sprite = hearts_0;
            } 
            else if(i+0.75 <= health/4)
            {
                hearts[i].sprite = hearts_1;
            } 
            else if(i+0.5 <= health/4)
            {
                hearts[i].sprite = hearts_3;
            } 
            else if(i+0.25 <= health/4)
            {
                hearts[i].sprite = hearts_2;
            } 
            else 
            {
                hearts[i].sprite = hearts_4;
            }


            if(i < numberOfHearts)
            {
                hearts[i].enabled = true;
            } else
            {
                hearts[i].enabled = false;
            }


        }

    }
}
