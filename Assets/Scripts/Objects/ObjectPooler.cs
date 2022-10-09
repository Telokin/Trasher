using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class ObjectPooler : MonoBehaviour
    {
        private List<GameObject> pooledObjects;

        [SerializeField]
        private GameObject objectToPool;

        [SerializeField]
        private int _poolAmount;




        void Start()
        {
            pooledObjects = new List<GameObject>();
            GameObject tmp;
            for (int i = 0; i < _poolAmount; i++)
            {
                tmp = Instantiate(objectToPool);
                tmp.SetActive(false);
                pooledObjects.Add(tmp);

            }

        }

        public GameObject GetPooledObject()
        {
            for (int i = 0; i < _poolAmount; i++)
            {
                if (!pooledObjects[i].activeInHierarchy)
                {
                    return pooledObjects[i];
                }
            }
            return null;
        }

    }
}