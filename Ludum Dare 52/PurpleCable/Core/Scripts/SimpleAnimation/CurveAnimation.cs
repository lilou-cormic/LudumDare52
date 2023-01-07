using Godot;
using System.Collections.Generic;
using System.Linq;

namespace PurpleCable
{
    public class CurveAnimation : SimpleAnimation
    {
        private readonly Vector2 _startGlobalPosition;

        private readonly Vector2[] _globalPositions;

        private int _index = 0;

        private Vector2 _nextGlobalPosition = Vector2.Zero;

        private Vector2 _positionVelocity = Vector2.Zero;

        private float _tLerp = 0f;

        public bool IsLine = false;

        public CurveAnimation(Node2D node, IEnumerable<Vector2> globalPositions)
            : base(node)
        {
            _globalPositions = globalPositions.ToArray();

            _startGlobalPosition = Node.GlobalPosition;

            _nextGlobalPosition = _globalPositions[0];
        }

        protected override void SetEndValue()
        {
            Node.GlobalPosition = _globalPositions.Last();
        }

        protected override bool MustUpdate()
        {
            if (_index >= _globalPositions.Length || _nextGlobalPosition == null)
                return false;

            return Node.GlobalPosition.DistanceTo(_nextGlobalPosition) > (GameUI.TileSize * 0.01f);
        }

        protected override void UpdateValue(float deltaTime, float t)
        {
            if (!IsLine)
                Node.GlobalPosition = VectorEx.SmoothDamp(Node.GlobalPosition, _nextGlobalPosition, ref _positionVelocity, Duration / _globalPositions.Length, deltaTime);
            else
                Node.GlobalPosition = VectorEx.Lerp(Node.GlobalPosition, _nextGlobalPosition, _tLerp / (Duration / _globalPositions.Length));

            if (Node.GlobalPosition.DistanceTo(_nextGlobalPosition) <= (GameUI.TileSize * 0.01f))
            {
                _index++;
                _tLerp = 0;

                _nextGlobalPosition = _globalPositions.ElementAtOrDefault(_index);

                return;
            }

            _tLerp += deltaTime;
        }

        public override void Reset()
        {
            base.Reset();

            Node.GlobalPosition = _startGlobalPosition;

            _index = 0;
            _positionVelocity = Vector2.Zero;
            _tLerp = 0;

            _nextGlobalPosition = _globalPositions[0];
        }
    }
}
