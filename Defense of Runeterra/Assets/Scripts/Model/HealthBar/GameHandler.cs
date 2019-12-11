using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class GameHandler : MonoBehaviour {

    [SerializeField] private HealthBar healthBar;
    private Camera _HP;
    
    private float MaxHP;
    private float ActualHP;
    float onePercent;
    float health;
    float HealthNow;
    float dmg;

    void Start()
    {
        health = 1f;
        _HP = Camera.main;
        MaxHP = _HP.GetComponent<PlayerControlModel>().TurretMaxHP;
       
        healthBar.SetSize(health);
        healthBar.SetColor(Color.red);
        
        
        
    }
    
 
 
    void Update()   
    {
        
        ActualHP = _HP.GetComponent<PlayerControlModel>().TurretActualHP;
        if (ActualHP >= 0)
        {
            onePercent = MaxHP / 100;
            dmg = ActualHP / onePercent;
            HealthNow = dmg / 100;
            
         
            healthBar.SetSize(HealthNow);
        }
        
        
      
    }
}
