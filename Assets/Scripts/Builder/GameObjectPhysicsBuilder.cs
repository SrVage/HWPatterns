using UnityEngine;

namespace Asteroids.Builder
{
    internal sealed class GameObjectPhysicsBuilder : GameObjectBuilder
    {
        public GameObjectPhysicsBuilder(GameObject gameObject) : base(gameObject) {}

        public GameObjectPhysicsBuilder BoxCollider2D()
        {
            GetOrAddComponent<BoxCollider2D>();
            return this;
        }

        public GameObjectPhysicsBuilder Rigidbody2D(float mass)
        {
            var component = GetOrAddComponent<Rigidbody2D>();
            component.mass = mass;
            return this;
        }
    }
}
