using UnityEngine;

namespace Asteroids.HomeWork.Decorator
{
    public class Example:MonoBehaviour
    {
        private IFire _fire;
        private Weapon _weapon;
        private ModificationWeapon _modificationWeaponMuffler;
        private ModificationWeapon _modificationWeaponAim;
        

        [Header("Start Gun")]
        [SerializeField] private Rigidbody _bullet;
        [SerializeField] private Transform _barrelPosition;
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private AudioClip _audioClip;
        
        [Header("Muffler Gun")] 
        [SerializeField] private AudioClip _audioClipMuffler;
        [SerializeField] private float _volumeFireOnMuffler;
        [SerializeField] private Transform _barrelPositionMuffler;
        [SerializeField] private GameObject _muffler;

        [Header("Aim Gun")] 
        [SerializeField] private GameObject _aimPrefab;
        [SerializeField] private Transform _aimPosition;

        private void Start()
        {
            IAmmunition ammunition = new Bullet(_bullet, 3.0f);
            _weapon = new Weapon(ammunition, _barrelPosition, 999.0f, _audioSource, _audioClip);
            var muffler = new Muffler(_audioClipMuffler, _volumeFireOnMuffler, _barrelPositionMuffler, _muffler);
            _modificationWeaponMuffler = new ModificationMuffler(_audioSource, muffler, _barrelPositionMuffler.position);
            _modificationWeaponMuffler.ApplyModification(_weapon);
            var aim = new Aim(_aimPrefab, _aimPosition);
            _modificationWeaponAim = new ModificationAim(aim, _aimPosition.position);
            _modificationWeaponAim.ApplyModification(_weapon);
            _fire = _modificationWeaponAim;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (!_weapon.IsMuffler)
                {
                    _modificationWeaponMuffler.ApplyModification(_weapon);
                    _fire = _modificationWeaponMuffler;
                }
                else
                {
                    _modificationWeaponMuffler.ApplyUnmodification(_weapon);
                    _fire = _modificationWeaponMuffler;
                }
                
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (!_weapon.IsAim)
                {
                    _modificationWeaponAim.ApplyModification(_weapon);
                    _fire = _modificationWeaponAim;
                }
                else
                {
                    _modificationWeaponAim.ApplyUnmodification(_weapon);
                    _fire = _modificationWeaponAim;
                }
            }
            
            if (Input.GetMouseButtonDown(0))
            {
                _fire.Fire();
            }

            if (Input.GetMouseButton(0) && _weapon.IsAim)
            {
                _weapon.RechargeTime -= Time.deltaTime;
                if (_weapon.RechargeTime <= 0)
                {
                    _fire.Fire();
                    _weapon.RechargeTime = 0.1f;
                }
                
            }
        }

    }
}