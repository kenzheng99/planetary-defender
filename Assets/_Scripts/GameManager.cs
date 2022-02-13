using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager> {
    private int score = 0;
    private int health = 100;
    [SerializeField] private UIController uiController;

    public void ProjectileFired() {
        score = score < 10 ? 0 : score - 10;
        uiController.SetScore(score);
    }
    public void AsteroidDestroyed(AsteroidSize asteroidSize) {
        score += asteroidSize switch {
            AsteroidSize.SMALL => 50,
            AsteroidSize.MEDIUM => 100,
            AsteroidSize.LARGE => 200,
            _ => throw new ArgumentOutOfRangeException(nameof(asteroidSize), asteroidSize, null)
        };
        uiController.SetScore(score);
        // Debug.Log($"Size {asteroidSize} asteroid destroyed");
    }

    public void AsteroidHitPlanet(AsteroidSize asteroidSize) {
        health -= asteroidSize switch {
            AsteroidSize.SMALL => 5,
            AsteroidSize.MEDIUM => 10,
            AsteroidSize.LARGE => 20,
            _ => throw new ArgumentOutOfRangeException(nameof(asteroidSize), asteroidSize, null)
        };
        uiController.SetHealth(health);
        // Debug.Log($"Size {asteroidSize} asteroid hit planet");
    }

    public void ProjectileHitPlanet() {
        health -= 5;
        uiController.SetHealth(health);
        // Debug.Log("Projectile hit planet");
    }
}

public enum AsteroidSize {
    SMALL,
    MEDIUM,
    LARGE,
}