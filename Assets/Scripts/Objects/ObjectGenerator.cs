using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Objects
{
    public class ObjectGenerator : MonoBehaviour
    {
        private ObjectPooler _objectPooler;

        private float _resetTimer;

        [SerializeField]
        [Range(0, 60)]
        private float _terrainObjectGenerationTimer;

        private void Start()
        {
            _objectPooler = GetComponent<ObjectPooler>();
        }

        private void Update()
        {
            _resetTimer += Time.deltaTime;
            if (_resetTimer >= _terrainObjectGenerationTimer)
            {
                SpawnTerrainObject();
                _resetTimer = 0f;
            }
        }

        private void SpawnTerrainObject()
        {
            GameObject terrainObject = _objectPooler.GetPooledObject();
            var xAxis = Random.Range(-15f, 3f);
            var zAxis = Random.Range(-15f, 19f);
            if (terrainObject != null)
            {
                terrainObject.transform.position = new Vector3(xAxis, 0, zAxis);
                terrainObject.SetActive(true);
            }

        }
    }
}