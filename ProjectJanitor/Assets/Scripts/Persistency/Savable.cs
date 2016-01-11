using UnityEngine;
using System.Collections;
using GalacticJanitor.Engine;

namespace GalacticJanitor.Persistency
{
    public class Savable : MonoBehaviour
    {

        [UniqueIdentifier]
        public string uniqueID;

        public SavableObject savableObject;

        // Use this for initialization
        void Start()
        {
            savableObject = Instantiate(savableObject, transform.position, transform.rotation) as SavableObject;
            savableObject.uniqueId = uniqueID;
            savableObject.transform.SetParent(gameObject.transform);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                savableObject.Save();
            }
        }

        public void RegisterData()
        {
            if (savableObject != null)
            {
                savableObject.uniqueId = uniqueID;

                Registery r = GameController.Controller.Registery;

                if (r.objectData.ContainsKey(savableObject.uniqueId))
                {
                    r.objectData[savableObject.uniqueId] = savableObject.GetData();
                }
                else
                {
                    r.objectData.Add(savableObject.uniqueId, savableObject.GetData());
                }

            }
        }

    } 
}
