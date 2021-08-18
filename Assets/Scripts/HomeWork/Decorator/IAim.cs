using UnityEngine;

namespace Asteroids.HomeWork.Decorator
{
    public interface IAim
    {
        Transform Position { get; }
        GameObject AimInstance { get; }
    }
}