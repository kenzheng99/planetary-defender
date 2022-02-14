using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour {
    [SerializeField] private GameUIController gameUI;
    [SerializeField] private GameOverUIController gameOverUI;

    private void Start() {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "MainScene") {
            ToggleGameUI(); 
        } else if (scene.name == "GameOverScene") {
            ToggleGameOverUI();
        }
    }

    public void ToggleGameUI() {
        gameUI.ToggleVisibility(true);
        gameOverUI.ToggleVisibility(false);
    }
    public void ToggleGameOverUI() {
        gameUI.ToggleVisibility(false);
        gameOverUI.ToggleVisibility(true);
    }

    public void SetScore(int score) {
        gameUI.SetScore(score);
    }

    public void SetHealth(int health) {
        gameUI.SetHealth(health);
    }

    public void SetGameOver(GameScore score) {
        ToggleGameOverUI();
        gameOverUI.SetGameOverStatistics(score);
    }
}
