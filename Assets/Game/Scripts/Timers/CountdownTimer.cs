using System;

namespace SpaceInvaders.Timers
{
    public sealed class CountdownTimer
    {
        private readonly float _initialTime;
        private float _currentTime;
        private State _state = State.Stop;

        private enum State
        {
            Run, Stop
        }

        public CountdownTimer(float initialTime)
        {
            if (initialTime < 0)
                throw new ArgumentOutOfRangeException(nameof(initialTime));
            
            _initialTime = initialTime;
        }
        
        public event Action Finished;

        public void Start()
        {
            _state = State.Run;
        }

        public void Stop()
        {
            _state = State.Stop;
        }

        public void Reset()
        {
            _currentTime = _initialTime;
            _state = State.Run;
        }

        public void Tick(float deltaTime)
        {
            if (_state == State.Stop)
                return;
            
            _currentTime -= deltaTime;

            if (_currentTime <= 0)
            {
                _state = State.Stop;
                Finished?.Invoke();
            }
        }
    }
}