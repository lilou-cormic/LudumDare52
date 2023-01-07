using Godot;

namespace PurpleCable
{
    public class ColorAnimation : SimpleAnimation
    {
        private readonly Color _originalColor = Colors.White;

        private Sprite Sprite => Node as Sprite;

        public Color EndColor = Colors.White;

        public ColorAnimation(Sprite sprite)
            : base(sprite)
        {
            _originalColor = Sprite.Modulate;
        }

        protected override void SetEndValue()
        {
            Sprite.Modulate = EndColor;
        }

        protected override bool MustUpdate()
        {
            return Sprite.Modulate.Equals(EndColor);
        }

        protected override void UpdateValue(float deltaTime, float t)
        {
            Sprite.Modulate = ColorEx.Lerp(Sprite.Modulate, EndColor, t);
        }

        public override void Reset()
        {
            base.Reset();

            Sprite.Modulate = _originalColor;
        }
    }
}
