using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour {
   private Label scoreLabel;
   private Label healthLabel;

   private void Start() {
      VisualElement root = GetComponent<UIDocument>().rootVisualElement;
      scoreLabel = root.Q<Label>("score");
      healthLabel = root.Q<Label>("health");
   }

   public void SetScore(int score) {
      scoreLabel.text = score.ToString();
   }

   public void SetHealth(int health) {
      healthLabel.text = health.ToString();
   }
}
