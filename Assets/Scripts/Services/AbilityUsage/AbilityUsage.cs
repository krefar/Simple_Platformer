using Assets.Scripts.Abilities;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Services.AbilityUsage
{
    public class AbilityUsage : MonoBehaviour
    {
        public void CastVampiricAura()
        {
            var vampiricAura = GetComponentInChildren<VampiricAura>(true);

            if (vampiricAura != null)
            {
                vampiricAura.EnableAura();

                StartCoroutine(DisableVampiricAura(vampiricAura));
            }
        }

        private IEnumerator DisableVampiricAura(VampiricAura vampiricAura)
        {
            yield return new WaitForSeconds(vampiricAura.Duration);

            vampiricAura.DisableAura();
        }
    }
}