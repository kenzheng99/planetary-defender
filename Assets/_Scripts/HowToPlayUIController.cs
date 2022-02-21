using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts {
    public class HowToPlayUIController: UIController {
        private Button buttonBack;
        private void Start() {
            Root.style.display = DisplayStyle.None;
            buttonBack = Root.Q<Button>("button-back");
            buttonBack.clicked += () => Root.style.display = DisplayStyle.None;
        }
    }
}