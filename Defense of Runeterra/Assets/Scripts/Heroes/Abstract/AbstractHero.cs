using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Heroes.Abstract
{
    public abstract class AbstractHero : ExposableMonobehaviour
    {
        [ExposeProperty]
        public float AD { get; set; }
        [ExposeProperty]
        public float HP { get; set; }
        [ExposeProperty]
        public float AS { get; set; }
        [ExposeProperty]
        public float MS { get; set; }
        [ExposeProperty]
        public bool Ranged { get; set; }
        [ExposeProperty]
        public bool Attacking { get; set; }

        private Transform _transform;
        private Rigidbody2D _rigidbody;
        private Camera _turret;
        

        public void StartDefault(float _ad, 
                                    float _hp, 
                                    float _as, 
                                    float _ms,
                                    bool _ranged,
                                    bool _attacking = false)
        {
            AD = _ad;
            HP = _hp;
            AS = _as;
            MS = _ms;
            Ranged = _ranged;
            Attacking = _attacking;
            _transform = GetComponent<Transform>();
            _rigidbody = GetComponent<Rigidbody2D>();
            _rigidbody.velocity = Vector2.left * MS; //Make it moving left
            _turret = Camera.main;

        }

        protected void UpdateDefault()
        {

            if (Ranged)
            {
                if (_transform.position.x > -2.0f && _transform.position.x < -1.0f)
                {
                    _rigidbody.velocity = Vector2.zero;
                }
            }
            else
            {
                if (_transform.position.x > -4.2f && _transform.position.x < -4.0f)
                {
                    _rigidbody.velocity = Vector2.zero;
                }
            }

            if(_rigidbody.velocity == Vector2.zero)
            {
                Attacking = true;
                if(!IsInvoking(nameof(Attacc)))
                    InvokeRepeating(nameof(Attacc), 1.5f, AS);
            }
            else
            {
                Attacking = false;
                CancelInvoke(nameof(Attacc));
            }


        }
        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.CompareTag("Bullet"))
            {
                HP -= _turret.GetComponent<PlayerControlModel>().BulletDamage;
                //scoreText.text = _score.ToString();
                Destroy(collider.gameObject);
                if (HP <= 0)
                {
                    Destroy(gameObject);
                }
            } 
        }

        void Attacc()
        {
            _turret.GetComponent<PlayerControlModel>().TurretHP -= AD;
            Debug.Log(_turret.GetComponent<PlayerControlModel>().TurretHP.ToString());
        }

    }
}
