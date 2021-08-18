using UnityEngine;

namespace Asteroids.HomeWork.Decorator
{
    internal sealed class ModificationAim:ModificationWeapon
    {
        private GameObject _aimRef;
        private readonly IAim _aim;
        private readonly Vector3 _aimPosition;

        protected override Weapon AddModification(Weapon weapon)
        {
            weapon.IsAim = true;
            _aimRef = Object.Instantiate(_aim.AimInstance, _aimPosition, Quaternion.identity);
            return weapon;
        }

        protected override Weapon DeleteModification(Weapon weapon)
        {
            weapon.IsAim = false;
            GameObject.Destroy(_aimRef);
            return weapon;
        }
        
        public ModificationAim(IAim aim, Vector3 aimPosition)
        {
            _aim = aim;
            _aimPosition = aimPosition;
        }
    }
}