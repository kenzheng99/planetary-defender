using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour {
   private Label scoreLabel;

   void Start() {
      VisualElement root = GetComponent<UIDocument>().rootVisualElement;
      scoreLabel = root.Q<Label>("counter");
   }

   public void setScore(int score) {
      scoreLabel.text = "Asteroids Destroyed: " + score;
   }
}
