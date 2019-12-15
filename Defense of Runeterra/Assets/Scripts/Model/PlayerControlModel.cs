using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControlModel : MonoBehaviour
{
    public GameObject Crosshair;
    public GameObject Bullet;

    public float BulletSpeed = 10.0f;
    public float ShootCooldown = 2;
    public float BulletDamage = 1;
    public float TurretMaxHP = 50;
    public float TurretActualHP = 50;

    private Vector3 _target;
    private float _shooting_cd;
    private Vector2 _turret_position;
    private Camera _camera;

    private float _destroy_time = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        _shooting_cd = Time.time + ShootCooldown;
        _turret_position = new Vector2(-4.9f, 1.9f);
        _camera = transform.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        check_crosshair();
    }

    private void check_crosshair()
    {
        _target = _camera
               .ScreenToWorldPoint(new Vector3(
                   Input.mousePosition.x,
                   Input.mousePosition.y,
                   transform.position.z
                   )); //Getting mouse position - 
                       //Used ScreenToWorldPoint because we wont move the map

        //Moving crosshair depending on mouse position
        Crosshair.transform.position = new Vector2(_target.x, _target.y);

        //calculating difference between target and begining point
        Vector3 difference = _target - new Vector3(_turret_position.x, _turret_position.y, transform.position.z);
        float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //setting rotation

        if (Input.GetMouseButtonDown(0) && Time.time > _shooting_cd && ShootCooldown != -1)
        {

            if (EventSystem.current.IsPointerOverGameObject())
                return; //Preventing from continuing if button is pressed

            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize(); //Setting magnitude to 1

            fire(direction, rotation);

            //Reseting cooldown
            _shooting_cd = Time.time + ShootCooldown;
        }
    }

    /// <summary>
    /// Creating new bullet, setting its default position and moving it by its speed
    /// </summary>
    /// <param name="direction"></param>
    private void fire(Vector2 direction, float rotation)
    {
        GameObject bullet = Instantiate(Bullet) as GameObject;
        bullet.transform.parent = GameObject.Find("Balls").transform;
        bullet.transform.position = _turret_position;
        bullet.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotation); //Setting rotation
        bullet.GetComponent<Rigidbody2D>().velocity = direction * BulletSpeed;
        bullet.GetComponent<SpriteRenderer>().sortingOrder = 20;
        //preventing lags by destroying after time
        Destroy(bullet, _destroy_time);
    }
}

