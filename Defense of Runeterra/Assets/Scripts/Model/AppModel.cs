using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppModel : MonoBehaviour
{

    public float Actual_Level = 1;
    public float Actual_Money = 0;
    public GameObject Defeat;
    public GameObject Explosion;
    public Text HPText;
    public Text MoneyText;

    private Camera _turret;
    private SpriteRenderer _renderer;
    private Color _alphaColor;
    private float _turretHP;
    private float _turretMaxHP;
    private float _actualMoney;

    // Start is called before the first frame update
    void Start()
    {
        _turret = Camera.main;
        _turretHP = _turret.GetComponent<PlayerControlModel>().TurretActualHP;
        _turretMaxHP = _turret.GetComponent<PlayerControlModel>().TurretMaxHP;

        HPText.text = $"{_turretHP}/{_turretMaxHP}";

        _renderer = Defeat.GetComponent<SpriteRenderer>();

        _alphaColor = _renderer.material.color;
        _alphaColor.a = 0;

        Defeat.SetActive(false);
        Explosion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_turret.GetComponent<PlayerControlModel>().TurretActualHP <= 0 && Explosion.activeSelf == false)
        { //Check defeat
            _turret.GetComponent<HeroesGenerator>().SpawningPeriod = -1; //Disable spawning

            Explosion.SetActive(true);
            Defeat.SetActive(true);
        }
        if (_turretHP != _turret.GetComponent<PlayerControlModel>().TurretActualHP)
        { //Check current HP
            _turretHP = _turret.GetComponent<PlayerControlModel>().TurretActualHP;
            var hp = _turretHP;
            HPText.text = $"{hp}/{_turretMaxHP}";
        }
        if (_turretMaxHP != _turret.GetComponent<PlayerControlModel>().TurretMaxHP)
        { //Check max HP
            _turretMaxHP = _turret.GetComponent<PlayerControlModel>().TurretMaxHP;
            var hp = _turret.GetComponent<PlayerControlModel>().TurretMaxHP;
            HPText.text = $"{_turretHP}/{hp}";
        }
        if(_actualMoney != Actual_Money)
        {
            _actualMoney = Actual_Money;
            MoneyText.text = $"Money : {_actualMoney}";
        }
    }
}