using UnityEngine;
using UnityEngine.UI;
using Zenject;
using FSM.GameManager.States;
using Zenject.Asteroids;
using TMPro;
using UI;

namespace FSM.GameManager
{
    public class GameManager : MonoBehaviour
    {
        private GameStateFactory _gameStateFactory;

        private GameStateEntity _gameStateEntity = null;

        private StateChangeManager _stateChangeManager;

        [SerializeField]
        private GameState _currentGameState;
        [SerializeField]
        private GameState _previousGameState;

        

        [Inject]
        public void Construct(GameStateFactory gameStateFactory, StateChangeManager stateChangeManager)
        {
            _gameStateFactory = gameStateFactory;
            _stateChangeManager = stateChangeManager;
        }

        private void Start()
        {
            ChangeState(GameState.Menu);
        }

        /// <summary>
        /// Changes the game state
        /// </summary>
        /// <param name="gameState">The state to transition to</param>
        internal void ChangeState(GameState gameState)
        {
            if (_gameStateEntity != null)
            {
                _gameStateEntity.Dispose();
                _gameStateEntity = null;
            }

            _previousGameState = _currentGameState;
            _currentGameState = gameState;

            _stateChangeManager.SetText(gameState);

            _gameStateEntity = _gameStateFactory.CreateState(gameState);
            _gameStateEntity.Start();
        }
    }
}
