using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fire : MonoBehaviour
{
  
    tur Tur;
    public int a = 0;
    public bool f = false, find = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (f) { 
            f = false; 
            Tur.fire_();
            a += 1;
        }
        if (find)
        {
            find = false;
            Tur.FindEnemy();
        }
    }
    
    void fire_() {
        f = true;
    }
    public void setTur(tur t) { Tur = t; }
    public void FindEnemy()
    {
        find = true;
    }
}
