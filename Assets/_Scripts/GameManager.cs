using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private int score = 0;
    private UIController uiController;
    private void Awake() {
        uiController = FindObjectOfType<UIController>();
    }

    public void incrementScore() {
        score += 1;
        uiController.setScore(score);
    }
}
