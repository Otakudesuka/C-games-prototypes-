using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System.Text;

namespace Gravity.Sprites
{
    public class Player : Sprite
    {
        private bool _onGround;

        private bool _jumping;
        SoundEffect s1;
       // bool c1;

        public Player(Texture2D texture, SoundEffect jumpsound)
          : base(texture)
        {
            s1 = jumpsound;
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.A))
                _velocity.X = -2f;
            else if (Keyboard.GetState().IsKeyDown(Keys.D))
                _velocity.X = 2f;
            else _velocity.X = 0f;

            if (Keyboard.GetState().IsKeyDown(Keys.Space) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
               
                _jumping = true;
                //s1.Play();
                //sound(true);
            }
                //_jumping = true;
        }

        
        
        /*public void sound(bool c1)
        {
           
            
                if (c1)
                {

                    s1.Play();

                }
                c1 = false;
            
        }
        */
        
        public override void OnCollide(Sprite sprite)
        {
            var test = sprite.Centre - (this.Centre);

            var onTop = this.WillIntersectTop(sprite);
            var onLeft = this.WillIntersectLeft(sprite);
            var onRight = this.WillIntersectRight(sprite);
            var onBottom = this.WillIntersectBottom(sprite);

            if (onTop)
            {
                _onGround = true;
                _velocity.Y = sprite.Rectangle.Top - this.Rectangle.Bottom;
                //this.Position = new Vector2(this.Position.X, sprite.Rectangle.Top - this.Origin.Y);
                //this._velocity.Y = 0;
            }
            else if (onLeft && _velocity.X > 0)
            {
                _velocity.X = 0;
            }
            else if (onRight && _velocity.X < 0)
            {
                _velocity.X = 0;
            }
            else if (onBottom)
            {
                _velocity.Y = 1;
            }
        }

        public override void ApplyPhysics(GameTime gameTime)
        {
            if (!_onGround)
                _velocity.Y += 0.2f;

            if (_onGround && _jumping)
            {
                _velocity.Y = -5f;
            }

            _onGround = false;
            _jumping = false;

            Position += _velocity;
        }
    }
}

