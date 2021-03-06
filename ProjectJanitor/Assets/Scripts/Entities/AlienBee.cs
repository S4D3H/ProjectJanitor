using UnityEngine;
using System.Collections;

namespace GalacticJanitor.Game
{
    public class AlienBee : AlienBase
    {

        [Header("CaC damage", order = 2)]
        public int damagePerHit;
        public float dammageDistanceOffset;
        float nextAttack;

        protected override void Attack()
        {
            if (Time.time > nextAttack)
            {
                if (rigging)
                {
                    rigging.SetTrigger("attack");

                    if (sndOnAttack && Random.Range(0f, 1f) > .5f)
                        listener.PlayOneShot(sndOnAttack, .1f);
                }
                if (target.gameObject.tag == "Player")
                {
                    LivingEntity entity = target.GetComponent<LivingEntity>();

                    if (entity != null && GetDistanceFromTarget() < maxAttackRange + dammageDistanceOffset)
                    {
                        entity.TakeDirectDamage(damagePerHit);
                    }
                }

                nextAttack = Time.time + (enraged ? attackPerSecond / enrageModifier : attackPerSecond);
            }
        }
    } 
}
