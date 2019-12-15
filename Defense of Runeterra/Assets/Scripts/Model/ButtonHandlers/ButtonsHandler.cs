using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsHandler : MonoBehaviour
{
    public float DMGCost = 5;
    public float ASCost = 5;
    public float MSCost = 5;
    public float HPCost = 5;

    private Camera _turret;
    private PlayerControlModel _playerControl;
    private AppModel _appModel;

    void Start()
    {
        _turret = Camera.main;
        _playerControl = _turret.GetComponent<PlayerControlModel>();
        _appModel = _turret.GetComponent<AppModel>();
    }

    public void IncDMG()
    {
        if (CheckMoney(DMGCost))
        {
            _playerControl.BulletDamage += 1f;
            DMGCost += 5;
        }
    }
    public void IncAS()
    {
        if (CheckMoney(ASCost))
        {
            _playerControl.ShootCooldown -= 0.1f;
            ASCost += 5;
        }
    }
    public void IncMS()
    {
        if (CheckMoney(MSCost))
        {
            _playerControl.BulletSpeed += 0.5f;
            MSCost += 5;
        }
    }
    public void IncHP()
    {
        if (CheckMoney(HPCost))
        {
            _playerControl.TurretActualHP += 5f;
            _playerControl.TurretMaxHP += 5f;
            HPCost += 5;
        }
    }

    private bool CheckMoney(float cost)
    {
        if (_appModel.Actual_Money >= cost)
        {
            _appModel.Actual_Money -= cost;
            return true;
        }
        else
        {
            return false;
        }
    }
}
