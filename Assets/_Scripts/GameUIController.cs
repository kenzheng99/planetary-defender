using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts {
    public class GameUIController : UIController {
        private Label scoreLabel;
        private Label healthLabel;

        protected override void Awake() {
            base.Awake();
            scoreLabel = Root.Q<Label>("score");
            healthLabel = Root.Q<Label>("health");
        }
        public void SetScore(int score) {
           scoreLabel.text = score.ToString();
        }

        public void SetHealth(int health) {
           healthLabel.text = health.ToString();
        }
    }
}