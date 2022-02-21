using System;
using System.Collections;
using System.Collections.Generic;
using _Scripts;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {
    [SerializeField] private UIManager uiManager;
    
    private int health = 100;
    private GameScore score;

    public override void Awake() {
        base.Awake();
        score = new GameScore();
    }

    public void ProjectileFired() {
        score.Score = score.Score < GameBalance.ScoreBullet ? 0 : score.Score - GameBalance.ScoreBullet;
        score.BulletsFired++;
        uiManager.SetScore(score.Score);
    }
    public void AsteroidDestroyed(AsteroidSize asteroidSize) {
        score.Score += asteroidSize switch {
            AsteroidSize.SMALL => GameBalance.ScoreSmall,
            AsteroidSize.MEDIUM => GameBalance.ScoreMedium,
            AsteroidSize.LARGE => GameBalance.ScoreLarge,
            _ => throw new ArgumentOutOfRangeException(nameof(asteroidSize), asteroidSize, null)
        };
        score.CountAsteroid(asteroidSize);
        uiManager.SetScore(score.Score);
        // Debug.Log($"Size {asteroidSize} asteroid destroyed");
    }

    public void AsteroidHitPlanet(AsteroidSize asteroidSize) {
        health -= asteroidSize switch {
            AsteroidSize.SMALL => GameBalance.DamageSmall,
            AsteroidSize.MEDIUM => GameBalance.DamageMedium,
            AsteroidSize.LARGE => GameBalance.DamageLarge,
            _ => throw new ArgumentOutOfRangeException(nameof(asteroidSize), asteroidSize, null)
        };
        if (health <= 0) {
            health = 0;
            GameOver();
        }
        uiManager.SetHealth(health);
        // Debug.Log($"Size {asteroidSize} asteroid hit planet");
    }

    public void ProjectileHitPlanet() {
        health -= 50;
        if (health <= 0) {
            health = 0;
            GameOver();
        }
        uiManager.SetHealth(health);
        // Debug.Log("Projectile hit planet");
    }

    //SCENE CHANGES

    public void NewGame() {
        Retry();
    }
    
    private void GameOver() {
        if (score.Score > score.HighScore) {
            score.HighScore = score.Score;
        }
        SceneManager.LoadScene("GameOverScene");
        uiManager.SetGameOver(score);
    }

    public void Retry() {
        score.ResetScore();
        health = 100;
        uiManager.SetHealth(health);
        uiManager.SetScore(score.Score);
        uiManager.ToggleGameUI();
        SceneManager.LoadScene("MainScene");
    }

    public void QuitToMenu() {
        uiManager.ToggleMainMenuUI();
        SceneManager.LoadScene("MainMenuScene");
    } 

    public void Quit() {
        Debug.Log("quit");
    }

    public void ToggleHowToPlay() {
        Debug.Log("How to play clicked");
        uiManager.ToggleHowToPlayUI();
    }
}

public enum AsteroidSize {
    SMALL,
    MEDIUM,
    LARGE,
}