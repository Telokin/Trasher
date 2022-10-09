using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

namespace Gun
{
    public class GunAnimationHandler : MonoBehaviour
    {
        [SerializeField]
        private Animator _gunAnimation;

        private GunController _gunController;

        private void Start()
        {
            gameObject.SetActive(false);
            _gunAnimation.SetTrigger(GunAnimation.changeGun);
            PlayerController.PlayerControllerInstance.onGunChanged += SwitchGun;
            _gunController = GetComponent<GunController>();
        }

        private void Update()
        {
            if (Input.GetButtonDown("Fire1"))
            {
                _gunAnimation.SetTrigger(GunAnimation.fire);
            }
        }

        private void SwitchGun(ObjectType type)
        {
            if (type == _gunController.Type)
            {
                gameObject.SetActive(true);
                _gunAnimation.SetTrigger(GunAnimation.changeGun);
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        private void OnDestroy()
        {
            PlayerController.PlayerControllerInstance.onGunChanged -= SwitchGun;
        }
    }
}
