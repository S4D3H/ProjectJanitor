using UnityEngine;
using System.Collections;
using GalacticJanitor.Engine;

namespace GalacticJanitor.Game
{

    /// <summary>
    /// Inventory ammo, handle also collision with AmmoBox
    /// </summary>
    public class PlayerAmmo : MonoBehaviour
    {

        public int ammoCarriedType0;
        public int ammoCarriedType1;

        /// <summary> Use to check if there is ammo in player's inventory.
        /// Take a int to know what type of ammo the function must check.
        /// 1 to weapon1 and 2 to weapon2.
        /// </summary>
        public bool checkIfThereIsAmmo(int ammoType)
        {
            if (ammoType == 0)
            {
                if (ammoCarriedType0 > 0)
                    return true;
                else
                    return false;
            }
            else
            {
                if (ammoCarriedType1 > 0)
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// Used to refile ammo when ammo box picked up
        /// </summary>
        public void PickUpAmmo(AmmoType ammoType, int amount)
        {
            if (ammoType == AmmoType.AmmoType0)
            {
                ammoCarriedType0 += amount;
            }
            else
            {
                ammoCarriedType1 += amount;
            }
            GameController.NotifyPlayer("+" + amount + " Ammo !", Color.green, 1);
        }

    } 

}
