using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManager : MonoBehaviour
{
    public int health = 3;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Update()
    {
        foreach (Image hp in hearts)
        {
            hp.sprite = emptyHeart;
        }
        for (int i = 0; i < health; i++)
        {
            hearts[i].sprite = fullHeart; 
        }
    }
    
    public void DamageDealt(int damage)
    {
        health -= damage;
    }
}
