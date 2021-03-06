using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gravity.Sprites
{
    public enum CollisionTypes
    {
        None,
        Full,
        Top,
    }

    public class Sprite : Component
    {
        protected float _layer { get; set; }

        protected Vector2 _origin { get; set; }

        protected Vector2 _position { get; set; }

        protected float _rotation { get; set; }

        protected Texture2D _texture;

        protected Vector2 _velocity;

        public CollisionTypes CollisionType { get; set; }

        public Color Colour { get; set; }

        public float Layer
        {
            get { return _layer; }
            set
            {
                _layer = value;
            }
        }

        public Vector2 Velocity
        {
            get { return _velocity; }
            set
            {
                _velocity = value;
            }
        }

        public Vector2 Origin
        {
            get { return _origin; }
            set
            {
                _origin = value;
            }
        }

        public Vector2 Position
        {
            get { return _position; }
            set
            {
                _position = value;
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X - (int)Origin.X, (int)Position.Y - (int)Origin.Y, _texture.Width, _texture.Height);
            }
        }

        public Vector2 Centre
        {
            get
            {
                return new Vector2(Rectangle.X + Origin.X, Rectangle.Y + Origin.Y);
            }
        }

        public float Rotation
        {
            get { return _rotation; }
            set
            {
                _rotation = value;
            }
        }

        public Sprite(Texture2D texture)
        {
            _texture = texture;

            Origin = new Vector2(_texture.Width / 2, _texture.Height / 2);

            CollisionType = CollisionTypes.None;

            Colour = Color.White;
        }

        public override void Update(GameTime gameTime)
        {
            _position -= _velocity;
        }

        public virtual void ApplyPhysics(GameTime gameTime)
        {

        }

        public virtual void OnCollide(Sprite sprite)
        {

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, null, Colour, _rotation, Origin, 1f, SpriteEffects.None, Layer);
        }

        public bool WillIntersect(Sprite sprite)
        {
            return this.WillIntersectBottom(sprite) ||
              this.WillIntersectLeft(sprite) ||
              this.WillIntersectRight(sprite) ||
              this.WillIntersectTop(sprite);
        }

        public bool WillIntersectLeft(Sprite sprite)
        {
            return this.Rectangle.Right + this._velocity.X >= sprite.Rectangle.Left &&
              this.Rectangle.Left + this._velocity.X < sprite.Rectangle.Left &&
              this.Rectangle.Top   /*+ this._velocity.Y */< sprite.Rectangle.Bottom &&
              this.Rectangle.Bottom/* + this._velocity.Y*/ > sprite.Rectangle.Top;
        }

        public bool WillIntersectRight(Sprite sprite)
        {
            return this.Rectangle.Left + this._velocity.X <= sprite.Rectangle.Right &&
              this.Rectangle.Right > sprite.Rectangle.Right &&
              this.Rectangle.Top   /*+ this._velocity.Y */< sprite.Rectangle.Bottom &&
              this.Rectangle.Bottom/* + this._velocity.Y*/ > sprite.Rectangle.Top;
        }

        public bool WillIntersectTop(Sprite sprite)
        {
            return this.Rectangle.Bottom + this._velocity.Y >= sprite.Rectangle.Top &&
              this.Rectangle.Top < sprite.Rectangle.Top &&
              this.Rectangle.Right/* + this._velocity.X*/ > sprite.Rectangle.Left &&
              this.Rectangle.Left /*+ this._velocity.Y */< sprite.Rectangle.Right;
        }

        public bool WillIntersectBottom(Sprite sprite)
        {
            return this.Rectangle.Top + this._velocity.Y <= sprite.Rectangle.Bottom &&
              this.Rectangle.Bottom > sprite.Rectangle.Bottom &&
              this.Rectangle.Right/* + this._velocity.X*/ > sprite.Rectangle.Left &&
              this.Rectangle.Left /*+ this._velocity.Y */< sprite.Rectangle.Right;
        }
    }
}

