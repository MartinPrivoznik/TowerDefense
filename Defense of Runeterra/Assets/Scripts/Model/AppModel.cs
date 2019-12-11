using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppModel : MonoBehaviour
{

    public float Actual_Level = 1;

    private Camera _turret;

    // Start is called before the first frame update
    void Start()
    {
        _turret = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (_turret.GetComponent<PlayerControlModel>().TurretHP <= 0)
        {

        }
    }
}
