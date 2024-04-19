using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

namespace _Assets.Scripts.Services.Gameplay
{
    public class PlayerController : NetworkBehaviour
    {
        [SerializeField] private WeaponController weaponController;
        private Dictionary<PlayerState, State> _states;
        private PlayerState _state = PlayerState.Standing;
        private State _currentState;
        private bool _inTransition;

        private void Awake()
        {
            _states = new Dictionary<PlayerState, State>
            {

            };
        }

        private void Update()
        {
            if (!IsOwner) return;
            _currentState?.OnUpdate();
        }

        public void ChangeState(PlayerState state)
        {
            _state = state;
        }

        public enum PlayerState
        {
            Standing,
            Crouching,
            Sprinting,
            Reloading,
            Attacking,
            Jumping,
            InAir,
            Dead
        }
    }

    [Serializable]
    public struct Transition
    {
        public State From;
        public State To;
        public float EnterDuration;
        public float ExitDuration;
    }

    public abstract class State
    {
        private Transition _transition;
        public Transition Transition => _transition;

        public State(Transition transition)
        {
            _transition = transition;
        }

        public virtual void OnEnter()
        {
        }

        public virtual void OnUpdate()
        {
        }

        public virtual void OnExit()
        {
        }
    }
}