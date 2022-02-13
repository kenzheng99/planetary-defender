using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private int score = 0;
    [SerializeField] private UIController uiController;

    public void incrementScore() {
        score += 1;
        uiController.setScore(score);
    }
}
