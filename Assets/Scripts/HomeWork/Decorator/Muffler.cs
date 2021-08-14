using UnityEngine;

namespace Asteroids.HomeWork.Decorator
{
    public class Muffler:IMuffler
    {
        public AudioClip AudioClipMuffler { get; }
        public float VolumeFireOnMuffler { get; }
        public Transform BarrelPositionMuffler { get; }
        public GameObject MufflerInstance { get; }

        public Muffler(AudioClip clip, float volume, Transform barrel, GameObject muffler)
        {
            AudioClipMuffler = clip;
            VolumeFireOnMuffler = volume;
            BarrelPositionMuffler = barrel;
            MufflerInstance = muffler;
        }
    }
}