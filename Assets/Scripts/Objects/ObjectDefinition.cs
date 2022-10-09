using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ObjectDefinition : MonoBehaviour
{
    [SerializeField]
    private ObjectType _objectType;

    [SerializeField]
    private int _health;

    private int _resetHealth;

    private float _timer = 0f;

    public int Health { get => _health; set => _health = value; }
    public ObjectType ObjectType { get => _objectType; set => _objectType = value; }
    public int ResetHealth { get => _resetHealth; set => _resetHealth = value; }

    private void Start()
    {
        ResetHealth = _health;
    }

    private void Update()
    {

        //if (Health <= 0)
        //{
        //    gameObject.SetActive(false);
        //    _timer += Time.deltaTime;
        //    if(_timer >= 2f)
        //    {
        //        Health = ResetHealth;
        //        _timer = 0f;
        //    }
        //}

    }
}
