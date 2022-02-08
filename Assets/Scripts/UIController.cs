using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour {
   private Label counterLabel;
   private int counter = 0;

   void Start() {
      VisualElement root = GetComponent<UIDocument>().rootVisualElement;
      counterLabel = root.Q<Label>("counter");
   }

   public void incrementCounter() {
      counter++;
      counterLabel.text = "Asteroids Destroyed: " + counter;
   }
}
