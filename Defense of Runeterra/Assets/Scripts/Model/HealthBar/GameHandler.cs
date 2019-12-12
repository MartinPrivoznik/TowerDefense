using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            health = (ActualHP / (MaxHP / 100)) / 100;
            healthBar.SetSize(health);
        }
        else
        {
            if (_HP.GetComponent<PlayerControlModel>().ShootCooldown != -1)
                _HP.GetComponent<PlayerControlModel>().ShootCooldown = -1;
        }
        
        
      
    }
}
