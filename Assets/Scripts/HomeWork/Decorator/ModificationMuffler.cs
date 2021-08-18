using UnityEngine;

namespace Asteroids.HomeWork.Decorator
{
    internal sealed class ModificationMuffler:ModificationWeapon
    {
        private readonly AudioSource _audioSource;
        private readonly IMuffler _muffler;
        private readonly Vector3 _mufflerPosition;
        private GameObject _mufflerRef;
        private float _volume;
        private AudioClip _clip;
        
        protected override Weapon AddModification(Weapon weapon)
        {
            _mufflerRef = Object.Instantiate(_muffler.MufflerInstance, _mufflerPosition, Quaternion.identity);
            _volume = _audioSource.volume;
            _audioSource.volume = _muffler.VolumeFireOnMuffler;
            _clip = weapon.GetAudioClip();
            weapon.SetAudioClip(_muffler.AudioClipMuffler);
            weapon.SetBarrelPosition(_muffler.BarrelPositionMuffler);
            weapon.IsMuffler = true;
            return weapon;
        }

        protected override Weapon DeleteModification(Weapon weapon)
        {
            GameObject.Destroy(_mufflerRef);
            weapon.SetAudioClip(_clip);
            _audioSource.volume = _volume;
            weapon.IsMuffler = false;
            return weapon;
        }


        public ModificationMuffler(AudioSource audioSource, IMuffler muffler, Vector3 mufflerPosition)
        {
            _audioSource = audioSource;
            _muffler = muffler;
            _mufflerPosition = mufflerPosition;
        }

    }
}