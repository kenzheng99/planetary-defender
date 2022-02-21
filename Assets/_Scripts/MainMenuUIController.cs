using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Scripts {
    public class MainMenuUIController: UIController {
        private Button buttonNewGame, buttonHowToPlay, buttonQuit;
        private GameManager gameManager;
        protected override void Awake() {
            base.Awake();
            buttonNewGame = Root.Q<Button>("button-newgame");
            buttonHowToPlay = Root.Q<Button>("button-howtoplay");
            buttonQuit = Root.Q<Button>("button-quit");
        }

        private void Start() {
            gameManager = GameManager.Instance;
            buttonNewGame.clicked += gameManager.NewGame;
            buttonHowToPlay.clicked += gameManager.ToggleHowToPlay;
            buttonQuit.clicked += gameManager.Quit;
        }
    }
}