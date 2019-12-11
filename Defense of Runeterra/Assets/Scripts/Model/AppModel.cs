using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppModel : MonoBehaviour
{

    public float Actual_Level = 1;

    private Camera _turret;
    private GameObject _explosion;

    // Start is called before the first frame update
    void Start()
    {
        _turret = Camera.main;
        _explosion = GameObject.Find("Tower/Explosion/exp1");
        _explosion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (_turret.GetComponent<PlayerControlModel>().TurretActualHP <= 0 && _explosion.activeSelf == false)
        {
            _turret.GetComponent<HeroesGenerator>().SpawningPeriod = -1; //Disable spawning
            _explosion.SetActive(true);
        }
    }
}
