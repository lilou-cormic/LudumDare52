using Godot;

namespace PurpleCable
{
    public class ScaleAnimation : SimpleAnimation
    {
        private readonly Vector2 _originalLocalScale = Vector2.One;

        public Vector2 EndLocalScale = Vector2.One;

        public ScaleAnimation(Node2D node)
            : base(node)
        {
            _originalLocalScale = Node.Scale;
        }

        protected override void SetEndValue()
        {
            Node.Scale = EndLocalScale;
        }

        protected override bool MustUpdate()
        {
            return Node.Scale.DistanceTo(EndLocalScale) > 0.01f;
        }

        protected override void UpdateValue(float deltaTime, float t)
        {
            Node.Scale = VectorEx.Lerp(Node.Scale, EndLocalScale, t);
        }

        public override void Reset()
        {
            base.Reset();

            Node.Scale = _originalLocalScale;
        }
    }
}
