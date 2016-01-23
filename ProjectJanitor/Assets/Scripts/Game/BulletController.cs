using UnityEngine;
using System.Collections;

namespace GalacticJanitor.Game
{
    public class BulletController : MonoBehaviour
    {

        public float speed = 10f;
        Rigidbody body;

        [Tooltip("Set time to destroy the gameobject if no collide")]
        public float destroyTime = 2.5f;

        public int bulletDmg;

        // Use this for initialization
        void Start()
        {
            body = gameObject.GetComponent<Rigidbody>();
            Destroy(gameObject, destroyTime);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            MoveForward();
        }

        private void MoveForward()
        {
            body.AddRelativeForce(Vector3.forward * speed, ForceMode.VelocityChange);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Wall" || other.tag == "Alien" || other.tag == "Indestructible Box") // Not finish, see if other tags must be add
            {
                Debug.Log("Im a bullet and i touch : " + other.tag.ToString() + ", i must be dead now");
                if (other.GetComponent<LivingEntity>() != null)
                {
                    LivingEntity target = other.GetComponent<LivingEntity>();
                    target.TakeDirectDamage(DoDamage());
                }

                //Debug
                if (other.GetComponent<LivingEntity>() == null && other.tag == "Alien")
                {
                    Debug.Log("We have a problem with an invincible alien in BulletController, wtf");
                }
                Destroy(gameObject);
            }  
        }

        int DoDamage()
        {
            return bulletDmg;
        }
    }
}