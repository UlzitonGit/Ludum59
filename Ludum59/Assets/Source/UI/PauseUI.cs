using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PauseUI : MonoBehaviour
{ 
        [SerializeField] private bool canPause = true;
        [SerializeField] private GameObject pauseUI;
        
        private bool isPaused = false;
        [SerializeField] private InputActionReference pauseAction;
        

        private void OnEnable()
        {
                if (pauseAction != null)
                {
                        pauseAction.action.Enable();
                        pauseAction.action.performed += OnPausePerformed;
                }
        }
    
        private void OnDisable()
        {
                if (pauseAction != null)
                {
                        pauseAction.action.performed -= OnPausePerformed;
                        pauseAction.action.Disable();
                }
        }
        private void OnPausePerformed(InputAction.CallbackContext context)
        {
                if (canPause)
                {
                        TogglePause();
                }
        }
    
        private void TogglePause()
        {
                if (isPaused)
                {
                        ResumeGame();
                }
                else
                {
                        PauseGame();
                }
        }
    
        private void PauseGame()
        {
               Time.timeScale = 0;
               pauseUI.SetActive(true);
               isPaused = true;
        }
    
        private void ResumeGame()
        {
               Time.timeScale = 1;
               pauseUI.SetActive(false);
               isPaused = false;
        }

        public void PausePerformedFromUI()
        {
                if (canPause)
                {
                        TogglePause();
                }
        }

        public void BackToMainMenu()
        {
                Time.timeScale = 1;
                SceneManager.LoadScene(0);
        }
}

