using UnityEngine;

namespace Asteroids.HomeWork.Decorator
{
    internal interface IAmmunition
    {
        Rigidbody BulletInstance { get; }
        float TimeToDestroy { get; }

    }
}