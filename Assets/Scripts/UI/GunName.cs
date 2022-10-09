using UnityEngine;
using TMPro;
using Player;

namespace UI
{
    public class GunName : MonoBehaviour
    {

        [SerializeField]
        private TextMeshProUGUI _gunName;

        private void Start()
        {
            _gunName.text = " ";
            PlayerController.PlayerControllerInstance.onGunChanged += ChangeGunNameOnCanvas;
            
        }

        private void ChangeGunNameOnCanvas(ObjectType type)
        {
            _gunName.text = $"Gun for: {type}";
        }

        private void OnDestroy()
        {
            PlayerController.PlayerControllerInstance.onGunChanged -= ChangeGunNameOnCanvas;
        }
    }
}
