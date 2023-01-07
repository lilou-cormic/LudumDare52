using Godot;

namespace PurpleCable
{
    public class StayAnimation : SimpleAnimation
    {
        private readonly Vector2 _position = Vector2.Zero;

        private readonly float _rotation = 0f;

        private readonly Vector2 _scale = Vector2.One;

        public StayAnimation(Node2D node)
            : base(node)
        { 
            _position = Node.GlobalPosition;
            _rotation = Node.GlobalRotation;
            _scale = Node.GlobalScale;
        }

        protected override void SetEndValue()
        {
            Node.GlobalPosition = _position;
            Node.GlobalRotation = _rotation;
            Node.GlobalScale = _scale;
        }

        protected override bool MustUpdate()
        {
            return true;
        }

        protected override void UpdateValue(float deltaTime, float t)
        {
            SetEndValue();
        }
    }
}
