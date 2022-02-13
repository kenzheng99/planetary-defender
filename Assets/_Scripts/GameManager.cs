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
        uiController.setScore(score);
    }
    public void AsteroidDestroyed(AsteroidSize asteroidSize) {
        switch (asteroidSize) {
            case AsteroidSize.SMALL:
                score += 50;
                break;
            case AsteroidSize.MEDIUM:
                score += 100;
                break;
            case AsteroidSize.LARGE:
                score += 200;
                break;
        }
        uiController.setScore(score);
    }

    public void AsteroidHitPlanet(AsteroidSize asteroidSize) {
        switch (asteroidSize) {
            case AsteroidSize.SMALL:
                health -= 5;
                break;
            case AsteroidSize.MEDIUM:
                health -= 10;
                break;
            case AsteroidSize.LARGE:
                health -= 20;
                break;
        }
        uiController.setHealth(health);
    }

    public void ProjectileHitPlanet() {
        health -= 5;
        uiController.setHealth(health);
    }
}

public enum AsteroidSize {
    SMALL,
    MEDIUM,
    LARGE,
}