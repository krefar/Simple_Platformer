using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Abilities
{
    public abstract class AffectBase<TEffect> : MonoBehaviour
    {
        public abstract void ProcessAffect(TEffect effect);
        public abstract bool CanBeAffected(TEffect effect);
    }
}