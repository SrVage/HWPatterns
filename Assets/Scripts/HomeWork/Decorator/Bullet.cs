﻿using UnityEngine;

namespace Asteroids.HomeWork.Decorator
{
    internal sealed class Bullet:IAmmunition
    {
        public Rigidbody BulletInstance { get; }
        public float TimeToDestroy { get; }
        
        public Bullet(Rigidbody bulletInstance, float timeToDestroy)
        {
            BulletInstance = bulletInstance;
            TimeToDestroy = timeToDestroy;
        }

    }
}