using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour {
   private Label scoreLabel;
   private Label healthLabel;

   void Start() {
      VisualElement root = GetComponent<UIDocument>().rootVisualElement;
      scoreLabel = root.Q<Label>("score");
      healthLabel = root.Q<Label>("health");
   }

   public void setScore(int score) {
      scoreLabel.text = score.ToString();
   }

   public void setHealth(int health) {
      healthLabel.text = health.ToString();
   }
}
