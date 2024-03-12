using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Abilities
{
    public abstract class AbilityBase : MonoBehaviour
    {
        [SerializeField] private float _duration;

        public float Duration { get => _duration; private set { } }
    }
}
