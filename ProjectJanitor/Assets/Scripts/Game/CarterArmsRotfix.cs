using UnityEngine;
using System.Collections;

namespace GalacticJanitor.Game
{
    public class CarterArmsRotfix : MonoBehaviour
    {

        public float maxAngle;

        void Update()
        {
            AngleLook(transform.up);
        }

        void AngleLook(Vector3 forward)
        {
            float a = Vector3.Distance(transform.parent.position, PointerTracker.MousePosition);
            float b = transform.localPosition.x;
            float rad = Mathf.Atan2(b, a);
            float deg = rad * Mathf.Rad2Deg;

            if (deg > 0 && deg > maxAngle)
            {
                deg = maxAngle;
            }
            else if (deg < 0 && deg < maxAngle)
            {
                deg = maxAngle;
            }

            transform.localRotation = Quaternion.Euler(new Vector3(0, 0, deg));
        }
    } 
}