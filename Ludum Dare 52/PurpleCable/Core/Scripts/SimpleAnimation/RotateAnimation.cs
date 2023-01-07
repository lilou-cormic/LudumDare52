using Godot;

namespace PurpleCable
{
    public class RotateAnimation : SimpleAnimation
    {
        private readonly float _originalLocalRotation = 0f;

        public float EndLocalRotation = 0f;

        public RotateAnimation(Node2D node)
            : base(node)
        {
            _originalLocalRotation = Node.Rotation;
        }

        protected override void SetEndValue()
        {
            Node.Rotation = EndLocalRotation;
        }

        protected override bool MustUpdate()
        {
            Vector2 currentRotation = Mathf.Polar2Cartesian(1, Node.Rotation);
            Vector2 endRotation = Mathf.Polar2Cartesian(1, EndLocalRotation);

            return currentRotation.DistanceTo(endRotation) > 0.01f;
        }

        protected override void UpdateValue(float deltaTime, float t)
        {
            Node.Rotation = Mathf.LerpAngle(Node.Rotation, _originalLocalRotation, t);
        }

        public override void Reset()
        {
            base.Reset();

            Node.Rotation = _originalLocalRotation;
        }
    }
}
