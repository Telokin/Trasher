using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        private static PlayerController _playerControllerInstance;

        public static PlayerController PlayerControllerInstance { get => _playerControllerInstance; set => _playerControllerInstance = value; }

        private void Awake()
        {
            PlayerControllerInstance = this;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                ChangeGun(ObjectType.Wood);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                ChangeGun(ObjectType.Metal);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                ChangeGun(ObjectType.Plastic);
            }
        }

        public event Action<ObjectType> onGunChanged;
        public void ChangeGun(ObjectType type)
        {
            if(onGunChanged != null)
            {
                onGunChanged.Invoke(type);
            }
        }

    }
}