using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gun
{
    public class GunController : MonoBehaviour
    {
        [SerializeField]
        private ObjectType _type;
        public ObjectType Type { get => _type; set => _type = value; }


        [SerializeField]
        [Range(0, 100)]
        private int _damage;

        [SerializeField]
        private LineRenderer _lineRenderer;

        [SerializeField]
        private Material[] _lasers;


        private void Update()
        {
            _lineRenderer.SetPosition(0, _lineRenderer.gameObject.transform.position);
            RaycastHit hit;
            if (Physics.Raycast(_lineRenderer.gameObject.transform.position, _lineRenderer.gameObject.transform.forward, out hit))
            {
                if (hit.collider && hit.transform.CompareTag(Type.ToString()))
                {
                    _lineRenderer.SetPosition(1, hit.point);

                    _lineRenderer.material = _lasers[0];

                }
                else
                {
                    _lineRenderer.SetPosition(1, hit.point);
                    _lineRenderer.material = _lasers[1];
                }


            }
            else
            {
                _lineRenderer.SetPosition(1, transform.forward * 100);
                _lineRenderer.material = _lasers[1];
            }
            if (Input.GetButtonDown("Fire1") && hit.transform.gameObject.GetComponent<ObjectDefinition>().ObjectType == Type)
            {
                hit.transform.gameObject.GetComponent<ObjectDefinition>().Health -= _damage;
            }
        }
    }
}
