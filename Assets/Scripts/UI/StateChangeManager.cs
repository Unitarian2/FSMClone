using UnityEngine;
using Zenject;
using FSM.GameManager;
using TMPro;
using Zenject.Asteroids;


namespace UI
{
    public class StateChangeManager : MonoBehaviour
    {
        [Inject]
        readonly GameManager _gameManager;

        public TextMeshProUGUI stateText;

        public void ChangeToMenu()
        {
            _gameManager.ChangeState(GameState.Menu);
        }

        public void ChangeToGameplay()
        {
            _gameManager.ChangeState(GameState.Gameplay);
        }

        public void ChangeToGameOver()
        {
            _gameManager.ChangeState(GameState.GameOver);
        }

        public void ChangeToVictory()
        {
            _gameManager.ChangeState(GameState.Victory);
        }

        public void SetText(GameState state)
        {
            stateText.text = state.ToString();
        }
    }
}