using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenuPanel : MonoBehaviour
    {
        
        [SerializeField]
        private Button _exitGameButton;
        [SerializeField]
        private Button _startGameButton;
        private void OnEnable()
        {
            _startGameButton.onClick.AddListener(StartGame);
            _exitGameButton.onClick.AddListener(ExitGame);
        }

        private void ExitGame()
        {
            Application.Quit();
        }

        private void StartGame()
        {
            SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
            
        }

        private void OnDisable()
        {
            _startGameButton.onClick.RemoveListener(StartGame);
            _exitGameButton.onClick.RemoveListener(ExitGame);
        }

    }
}
