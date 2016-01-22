using UnityEngine;

namespace GalacticJanitor.Game
{
    public class AlienAlpha : AlienBase
    {
        
        public AlienSpit projectile;
        float nextAttack;

        protected override void Attack()
        {
            if (Time.time > nextAttack)
            {
                AlienSpit proj = Instantiate(projectile, sensor.position, sensor.rotation) as AlienSpit;
                if (enraged)
                {
                    proj.AddDamage(proj.baseDamage * enrageModifier);
                    proj.AddSpeed(proj.baseSpeed * enrageModifier);
                }
                nextAttack = Time.time + (enraged? attackPerSecond / enrageModifier : attackPerSecond);
            } 
        }
    } 
}
