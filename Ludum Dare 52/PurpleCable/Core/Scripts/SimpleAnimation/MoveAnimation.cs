using Godot;

namespace PurpleCable
{
    public class MoveAnimation : SimpleAnimation
    {
        private readonly Vector2 _originalGlobalPosition = Vector2.Zero;

        private Vector2 _positionVelocity = Vector2.Zero;

        public Vector2 EndGlobalPosition = Vector2.Zero;

        public bool IsLine = false;

        public MoveAnimation(Node2D node)
            : base(node)
        { 
            _originalGlobalPosition = Node.GlobalPosition;
        }

        protected override void SetEndValue()
        {
            Node.GlobalPosition = EndGlobalPosition;
        }

        protected override bool MustUpdate()
        {
            return Node.GlobalPosition.DistanceTo(EndGlobalPosition) > (GameUI.TileSize * 0.01f);
        }

        protected override void UpdateValue(float deltaTime, float t)
        {
            if (!IsLine)
                Node.GlobalPosition = VectorEx.SmoothDamp(Node.GlobalPosition, EndGlobalPosition, ref _positionVelocity, Duration, deltaTime);
            else
                Node.GlobalPosition = VectorEx.Lerp(Node.GlobalPosition, EndGlobalPosition, t);
        }

        public override void Reset()
        {
            base.Reset();

            _positionVelocity = Vector2.Zero;

            Node.GlobalPosition = _originalGlobalPosition;
        }

        protected override void StartExtended()
        {
            GD.Print($"{Node.GlobalPosition}, {EndGlobalPosition}");
        }
    }
}
