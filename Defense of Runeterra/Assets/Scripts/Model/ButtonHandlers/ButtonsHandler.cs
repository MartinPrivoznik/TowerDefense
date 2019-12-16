using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsHandler : MonoBehaviour
{
    public float DMGCost = 5;
    public float ASCost = 5;
    public float MSCost = 5;
    public float HPCost = 5;

    public Text DMGCostText;
    public Text ASCostText;
    public Text MSCostText;
    public Text HPCostText;

    private Camera _turret;
    private PlayerControlModel _playerControl;
    private AppModel _appModel;

    void Start()
    {
        _turret = Camera.main;
        _playerControl = _turret.GetComponent<PlayerControlModel>();
        _appModel = _turret.GetComponent<AppModel>();

        DMGCostText.text = $"Cost: {DMGCost}";
        ASCostText.text = $"Cost: {ASCost}";
        MSCostText.text = $"Cost: {MSCost}";
        HPCostText.text = $"Cost: {HPCost}";
    }

    public void IncDMG()
    {
        if (CheckMoney(DMGCost))
        {
            _playerControl.BulletDamage += 1f;
            DMGCost += 5;
            DMGCostText.text = $"Cost: {DMGCost}";
        }
    }
    public void IncAS()
    {
        if (CheckMoney(ASCost))
        {
            _playerControl.ShootCooldown -= 0.1f;
            ASCost += 5;
            ASCostText.text = $"Cost: {ASCost}";
        }
    }
    public void IncMS()
    {
        if (CheckMoney(MSCost))
        {
            _playerControl.BulletSpeed += 0.5f;
            MSCost += 5;
            MSCostText.text = $"Cost: {MSCost}";
        }
    }
    public void IncHP()
    {
        if (CheckMoney(HPCost))
        {
            _playerControl.TurretActualHP += 5f;
            _playerControl.TurretMaxHP += 5f;
            HPCost += 5;
            HPCostText.text = $"Cost: {HPCost}";
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
