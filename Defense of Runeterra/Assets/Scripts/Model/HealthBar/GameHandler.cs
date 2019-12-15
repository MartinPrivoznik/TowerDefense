using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour {

    [SerializeField] private HealthBar healthBar;
    private Camera _HP;
    
    private float MaxHP;
    private float ActualHP;
    private float health;
    private PlayerControlModel _playerControlModel;

    void Start()
    {
        health = 1f;
        _HP = Camera.main;
        _playerControlModel = _HP.GetComponent<PlayerControlModel>();

        healthBar.SetSize(health);
        healthBar.SetColor(Color.red);
    }
    
 
 
    void Update()   
    {
        
        ActualHP = _playerControlModel.TurretActualHP;
        MaxHP = _playerControlModel.TurretMaxHP;
        if (ActualHP >= 0)
        {
            health = (ActualHP / (MaxHP / 100)) / 100;
            healthBar.SetSize(health);
        }
        else
        {
            if (_playerControlModel.ShootCooldown != -1)
                _playerControlModel.ShootCooldown = -1;
        }
        
        
      
    }
}
