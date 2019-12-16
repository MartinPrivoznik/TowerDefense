using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppModel : MonoBehaviour
{

    public float Actual_Level = 0;
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
    private float _actualLevel;
    private PlayerControlModel _playerControlModel;
    private HeroesGenerator _heroesGenerator;

    // Start is called before the first frame update
    void Start()
    {
        _turret = Camera.main;
        _playerControlModel = _turret.GetComponent<PlayerControlModel>();
        _heroesGenerator = _turret.GetComponent<HeroesGenerator>();
        _turretHP = _playerControlModel.TurretActualHP;
        _turretMaxHP = _playerControlModel.TurretMaxHP;
        _actualLevel = Actual_Level;

        HPText.text = $"{_turretHP}/{_turretMaxHP}";

        _renderer = Defeat.GetComponent<SpriteRenderer>();

        _alphaColor = _renderer.material.color;
        _alphaColor.a = 0;

        Defeat.SetActive(false);
        Explosion.SetActive(false);

        Actual_Level = 1;
    }

    // Update is called once per frame
    void Update()
    {
        CheckTurret();
        CheckMoney();
        CheckLevel();
    }

    private void CheckTurret()
    {
        if (_playerControlModel.TurretActualHP <= 0 && Explosion.activeSelf == false)
        { //Check defeat
            _heroesGenerator.SpawningPeriod = -1; //Disable spawning

            Explosion.SetActive(true);
            Defeat.SetActive(true);
        }
        if (_turretHP != _playerControlModel.TurretActualHP)
        { //Check current HP
            _turretHP = _playerControlModel.TurretActualHP;
            var hp = _turretHP;
            HPText.text = $"{hp}/{_turretMaxHP}";
        }
        if (_turretMaxHP != _playerControlModel.TurretMaxHP)
        { //Check max HP
            _turretMaxHP = _playerControlModel.TurretMaxHP;
            var hp = _playerControlModel.TurretMaxHP;
            HPText.text = $"{_turretHP}/{hp}";
        }
    }

    private void CheckMoney()
    {
        if (_actualMoney != Actual_Money)
        {
            _actualMoney = Actual_Money;
            MoneyText.text = $"Money : {_actualMoney}";
        }
    }

    private void CheckLevel()
    {
        if (_actualLevel != Actual_Level)
        {
            _actualLevel = Actual_Level;

            switch (_actualLevel)
            {
                case 1f:
                    _heroesGenerator.SpawningPeriod = 5.0f;
                    break;
                case 2f:
                    _heroesGenerator.SpawningPeriod = 4.0f;
                    break;
                case 3f:
                    _heroesGenerator.SpawningPeriod = 3.0f;
                    break;
                case 4f:
                    _heroesGenerator.SpawningPeriod = 2.0f;
                    break;
                case 5f:
                    _heroesGenerator.SpawningPeriod = 1.0f;
                    break;
            }
        }
    }
}