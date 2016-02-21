using UnityEngine;

namespace GalacticJanitor.Game
{
    public class AlienSpit : Projectile
    {
        protected override void OnHit(RaycastHit hit)
        {
            if (hit.collider.CompareTag("Player"))
            {
                LivingEntity entity = hit.collider.GetComponent<LivingEntity>();
                entity.TakeDirectDamage(baseDamage);
            }

            Destroy(gameObject);
        }
    } 
}
