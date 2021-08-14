using UnityEngine;

namespace Asteroids.Extensions
{
    public static class BuilderExtension
    {
        public static GameObject SetName(this GameObject gameObject, string name)
        {
            gameObject.name = name;
            return gameObject;
        }

        public static GameObject AddTrigger(this GameObject gameObject)
        {
            var component = gameObject.GetOrAddComponent<BoxCollider>();
            component.isTrigger = true;
            return gameObject;
        }

        public static GameObject AddTrail(this GameObject gameObject, Color color)
        {
            var component = gameObject.GetOrAddComponent<TrailRenderer>();
            component.startColor = color;
            component.endColor = Color.gray;
            return gameObject;
        }

        public static GameObject AddForce(this GameObject gameObject, Vector3 force)
        {
            var component = gameObject.GetOrAddComponent<Rigidbody>();
            component.mass = 0.1f;
            component.AddForce(force, ForceMode.Impulse);
            return gameObject;
        }
    }
}