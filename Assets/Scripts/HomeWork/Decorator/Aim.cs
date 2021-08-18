using UnityEngine;

namespace Asteroids.HomeWork.Decorator
{
    public class Aim:IAim
    {
        public Transform Position { get; }
        public GameObject AimInstance { get; }

        public Aim(GameObject aim, Transform position)
        {
            AimInstance = aim;
            Position = position;
        }
    }
}