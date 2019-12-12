using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppModel : MonoBehaviour
{

    public float Actual_Level = 1;
    public GameObject Defeat;
    public GameObject Explosion;
    public Text HPText;

    private Camera _turret;
    private SpriteRenderer _renderer;
    private Color _alphaColor;

    // Start is called before the first frame update
    void Start()
    {
        _turret = Camera.main;

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
        {
            _turret.GetComponent<HeroesGenerator>().SpawningPeriod = -1; //Disable spawning

            Explosion.SetActive(true);
            Defeat.SetActive(true);
        }
        else
        {
            HPText.text = $"{_turret.GetComponent<PlayerControlModel>().TurretActualHP}/{_turret.GetComponent<PlayerControlModel>().TurretMaxHP}";
        }
    }
}