using System;
using _Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {
    public bool disableMovement = false;
        
    [SerializeField] private UIManager uiManager;
    
    private int health = 100;
    private GameScore score;
    private float gameOverTime = 0;

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
        health -= GameBalance.DamageBullet;
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

    public void DelayedGameOver(float time) {
        disableMovement = true;
        gameOverTime = time;
    }
    
    public void GameOver() {
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
        disableMovement = false;
        SceneManager.LoadScene("MainScene");
    }

    public void QuitToMenu() {
        uiManager.ToggleMainMenuUI();
        SceneManager.LoadScene("MainMenuScene");
    } 

    public void Quit() {
        Debug.Log("quit");
        Application.Quit();
    }

    public void ToggleHowToPlay() {
        Debug.Log("How to play clicked");
        uiManager.ToggleHowToPlayUI();
    }

    private void Update() {
        if (gameOverTime > 0 && Time.time > gameOverTime) {
            gameOverTime = 0;
            GameOver();
        }
    }
}

public enum AsteroidSize {
    SMALL,
    MEDIUM,
    LARGE,
}