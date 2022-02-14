using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts {
    public class GameOverUIController : UIController {
        private Label labelAsteroidsLarge, labelAsteroidsMed, labelAsteroidsSmall, labelBulletsFired;
        private Label numAsteroidsLarge, numAsteroidsMed, numAsteroidsSmall, numBulletsFired;
        private Label numScore, numHighScore;
        private Button buttonRetry, buttonQuit;
        private GameManager gameManager;
        protected override void Awake() {
            base.Awake();
            labelAsteroidsLarge = Root.Q<Label>("label-asteroids-large");
            labelAsteroidsMed = Root.Q<Label>("label-asteroids-med");
            labelAsteroidsSmall = Root.Q<Label>("label-asteroids-small");
            labelBulletsFired = Root.Q<Label>("label-bullets-fired");
            numBulletsFired = Root.Q<Label>("num-bullets-fired");
            numAsteroidsLarge = Root.Q<Label>("num-asteroids-large");
            numAsteroidsMed = Root.Q<Label>("num-asteroids-med");
            numAsteroidsSmall = Root.Q<Label>("num-asteroids-small");
            numScore = Root.Q<Label>("num-score");
            numHighScore = Root.Q<Label>("num-high-score");

        }

        private void Start() {
            gameManager = GameManager.Instance;
            Debug.Log(gameManager);
            buttonRetry = Root.Q<Button>("button-retry");
            buttonRetry.clicked += gameManager.Retry;
            buttonQuit = Root.Q<Button>("button-quit");
            buttonQuit.clicked += gameManager.Quit;
        }

        public void SetGameOverStatistics(GameScore score) {
            numScore.text = score.Score.ToString();
            numHighScore.text = score.HighScore.ToString();
            numAsteroidsLarge.text = score.NumLarge.ToString();
            numAsteroidsMed.text = score.NumMedium.ToString();
            numAsteroidsSmall.text = score.NumSmall.ToString();
            numBulletsFired.text = score.BulletsFired.ToString();

            labelAsteroidsLarge.text = $"Large Asteroids Destroyed (+{GameBalance.ScoreLarge} each)";
            labelAsteroidsMed.text = $"Medium Asteroids Destroyed (+{GameBalance.ScoreMedium} each)";
            labelAsteroidsSmall.text = $"Small Asteroids Destroyed (+{GameBalance.ScoreSmall} each)";
            labelBulletsFired.text = $"Bullets Fired (-{GameBalance.ScoreBullet} each)";
        }
    }
}