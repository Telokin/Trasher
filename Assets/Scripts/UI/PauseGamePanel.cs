using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class PauseGamePanel : MonoBehaviour
    {
        
        [SerializeField]
        private Button _backToMainButton;
        [SerializeField]
        private Button _exitGameButton;
        [SerializeField]
        private Button _continueButton;
        private void OnEnable()
        {
            _continueButton.onClick.AddListener(ContinueGame);
            _exitGameButton.onClick.AddListener(ExitGame);
            _backToMainButton.onClick.AddListener(BackToMainMenuButton);
        }
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
        }
        private void BackToMainMenuButton()
        {
            Time.timeScale = 1f;
            SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
        }

        private void ExitGame()
        {
            Application.Quit();
        }

        public event Action onContinueGameClick;
        private void ContinueGame()
        {
            gameObject.SetActive(false);
            Time.timeScale = 1f;
            onContinueGameClick.Invoke();
        }

        private void OnDisable()

        {
            _continueButton.onClick.RemoveListener(ContinueGame);
            _exitGameButton.onClick.RemoveListener(ExitGame);
            _backToMainButton.onClick.RemoveListener(BackToMainMenuButton);
        }

    }
}
