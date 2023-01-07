using Godot;

namespace PurpleCable
{
    public abstract class SimpleAnimation
    {
        public float Duration { get; set; } = 0.3f;

        public float Delay { get; set; } = 0.0f;

        public float TotalDuration => Delay + Duration;

        public bool IsAnimating { get; private set; } = false;

        public bool IsDoneAnimating { get; private set; } = false;

        protected float Timer { get; private set; } = 0f;

        private bool _isUpdateDone = false;

        private readonly Node2D _Node;
        protected Node2D Node => _Node;

        public SimpleAnimation(Node2D node)
        {
            _Node = node;
        }

        public void PhysicsProcess(float delta)
        {
            if (!IsAnimating || IsDoneAnimating)
                return;

            if (_isUpdateDone || Timer >= TotalDuration * 5)
            {
                SetEndValue();

                End();

                return;
            }

            Timer += delta;

            if (Timer >= Delay)
            {
                if (!_isUpdateDone)
                {
                    if (MustUpdate())
                        UpdateValue(delta, Timer / Duration);
                    else
                        _isUpdateDone = true;
                }
            }
        }

        public void Start()
        {
            Timer = 0f;
            _isUpdateDone = false;
            IsAnimating = true;
            IsDoneAnimating = false;

            StartExtended();
        }

        protected virtual void StartExtended()
        { }


        public void End()
        {
            IsAnimating = false;
            IsDoneAnimating = true;

            EndExtended();
        }

        protected virtual void EndExtended()
        { }

        public virtual void Reset()
        {
            Timer = 0f;
            _isUpdateDone = false;
            IsAnimating = false;
            IsDoneAnimating = false;
        }

        protected abstract void SetEndValue();

        protected abstract bool MustUpdate();

        protected abstract void UpdateValue(float deltaTime, float t);
    }
}
