using Gravity.Sprites;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
//using XNAGifAnimationLibrary;

namespace Gravity
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        List<SoundEffect> soundEffects;
        Song song;
        

        //private SpriteSheet spriteSheet;

        public static int ScreenWidth = 1920;
        public static int ScreenHeight = 1080;

        private List<Sprite> _spritesLevel1;
        private List<Sprite> _spritesLevel2;
        private List<Sprite> _spritesLevel3;
        private List<Sprite> _spritesLevelFinal;

        private int currentLevel = 1;
        public  Boolean c1= true;
        public Boolean c2 = true;


        public Boolean c3 = true;
        public Boolean c4 = true;

        public Boolean c11 = true;
        public Boolean c21 = true;


        public Boolean c31 = true;
        public Boolean c41 = true;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            soundEffects = new List<SoundEffect>();
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            graphics.PreferredBackBufferWidth = ScreenWidth;
            graphics.PreferredBackBufferHeight = ScreenHeight;
            graphics.ApplyChanges();
            

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            soundEffects.Add(Content.Load<SoundEffect>("sounds/playerjump_01"));
            //soundEffects.Add(Content.Load<SoundEffect>("sounds/backsound"));
            soundEffects.Add(Content.Load<SoundEffect>("sounds/gamewin"));
            soundEffects.Add(Content.Load<SoundEffect>("sounds/gameover"));

            song = Content.Load<Song>("sounds/bgmnew");  // Put the name of your song here instead of "song_title"
            MediaPlayer.Play(song);

            var texture = Content.Load<Texture2D>("Square");
            var BlueBlock2Tex = Content.Load<Texture2D>("Blocks/BlueBlock2");
            var BlueBlock3Tex = Content.Load<Texture2D>("Blocks/BlueBlock3");
            var BlueBlock5Tex = Content.Load<Texture2D>("Blocks/BlueBlock5");
            var BlueBlock6Tex = Content.Load<Texture2D>("Blocks/BlueBlock6");
            var BlueBlockV6 = Content.Load<Texture2D>("Blocks/BlueBlockV6");
            var BlueBlock8Tex = Content.Load<Texture2D>("Blocks/BlueBlock8");
            var GoalBlockTex = Content.Load<Texture2D>("Blocks/Goal");
            var TurqouiseBlockTex = Content.Load<Texture2D>("Blocks/TurqouiseBlock");
            var YellowBlock3Tex = Content.Load<Texture2D>("Blocks/OrangeBlockV6");
            var YellowBlock4Tex = Content.Load<Texture2D>("Blocks/YellowBlock4");
            var RedBlock2Tex = Content.Load<Texture2D>("Blocks/RedBlock2");
            var RedBlock3Tex = Content.Load<Texture2D>("Blocks/OrangeBlockV5");
            var RedBlock4Tex = Content.Load<Texture2D>("Blocks/RedBlock4");
            var blockStripTex = Content.Load<Texture2D>("Blocks/blockStrip");
            var OrangeBlockV3Tex = Content.Load<Texture2D>("Blocks/OrangeBlockV3");
            var OrangeBlockV4Tex = Content.Load<Texture2D>("Blocks/OrangeBlockV4");
            var GreyBlock2Tex = Content.Load<Texture2D>("Blocks/GreyBlock2");
            var GreyBlock4Tex = Content.Load<Texture2D>("Blocks/GreyBlock4");
            var GreyBlock5Tex = Content.Load<Texture2D>("Blocks/GreyBlock4");
            var GreyBlock4HTex = Content.Load<Texture2D>("Blocks/GreyBlock4H");
            var GreyBlockV6Tex = Content.Load<Texture2D>("Blocks/GreyBlockV6");
            var GreyBlock6Tex = Content.Load<Texture2D>("Blocks/GreyBlock6");

            var InvisbleColTex = Content.Load<Texture2D>("Blocks/Goal");

            if (currentLevel == 1)
                _spritesLevel1 = new List<Sprite>()
      {
        new Sprite(Content.Load<Texture2D>("Backgrounds/Level_1"))
        {
          Position = new Vector2(ScreenWidth / 2, ScreenHeight / 2),
          CollisionType = CollisionTypes.None,
        },
            new Player(Content.Load<Texture2D>("Blocks/Player"),Content.Load<SoundEffect>("sounds/jump"))
        {
          Position = new Vector2(692, 690),
          CollisionType = CollisionTypes.Full,
        },
             new Sprite(GreyBlock6Tex)
        {
          Position = new Vector2(840, 750),
          Colour = Color.White,
          CollisionType = CollisionTypes.Full,
        },
             new Sprite(GoalBlockTex)
        {
          Position = new Vector2(991, 690),
          Colour = Color.White,
          CollisionType = CollisionTypes.Full,
        },
             new Sprite(Content.Load<Texture2D>("Backgrounds/winnew"))
        {
                    Position = new Vector2(ScreenWidth / 2, ScreenHeight / 2),
                    CollisionType = CollisionTypes.None,
                    Colour = Color.Transparent,
        },
        new Sprite(Content.Load<Texture2D>("Backgrounds/losenew"))
        {
                    Position = new Vector2(ScreenWidth / 2, ScreenHeight / 2),
                    CollisionType = CollisionTypes.None,
                    Colour = Color.Transparent,
        },
        
         new Sprite(Content.Load<Texture2D>("Buttons/newbutton"))
        {
         Position = new Vector2(1543, 588),
          CollisionType = CollisionTypes.None,
          Colour = Color.Transparent,
        },
          new Sprite(Content.Load<Texture2D>("Backgrounds/bgnew"))
        {
          Position = new Vector2(ScreenWidth / 2, ScreenHeight / 2),
          CollisionType = CollisionTypes.None,
        },
         new Sprite(Content.Load<Texture2D>("Buttons/newbutton"))
        {
         Position = new Vector2(1545, 888),
          CollisionType = CollisionTypes.Full,
        },
         new Sprite(Content.Load<Texture2D>("Buttons/replay"))
        {
         Position = new Vector2(1590,423),
          CollisionType = CollisionTypes.Full,
          Colour=Color.Transparent,
        },
         new Sprite(Content.Load<Texture2D>("Buttons/quit"))
        {
         Position = new Vector2(1590,912),
          CollisionType = CollisionTypes.None,
          Colour=Color.Transparent,
        },
     };
            if (currentLevel == 2)
                _spritesLevel2 = new List<Sprite>()
      {
        new Sprite(Content.Load<Texture2D>("Backgrounds/Level_2"))
        {
          Position = new Vector2(ScreenWidth / 2, ScreenHeight / 2),
          CollisionType = CollisionTypes.None,
        },
            new Player(Content.Load<Texture2D>("Blocks/Player"),Content.Load<SoundEffect>("sounds/mouseclickstart"))
        {
          Position = new Vector2(628, 692),
          CollisionType = CollisionTypes.Full,
        },
             new Sprite(GreyBlock4HTex)
        {
          Position = new Vector2(721, 753),
          Colour = Color.White,
          CollisionType = CollisionTypes.Full,
        },
             new Sprite(GreyBlock4HTex)
        {
          Position = new Vector2(1080, 753),
          Colour = Color.White,
          CollisionType = CollisionTypes.Full,
        },
             new Sprite(GoalBlockTex)
        {
          Position = new Vector2(1115,695 ),
          CollisionType = CollisionTypes.Full,
          Colour = Color.White,
        },
             new Sprite(Content.Load<Texture2D>("Backgrounds/winnew"))
        {
                    Position = new Vector2(ScreenWidth / 2, ScreenHeight / 2),
                    CollisionType = CollisionTypes.None,
                    Colour = Color.Transparent,
        },
        new Sprite(Content.Load<Texture2D>("Backgrounds/losenew"))
        {
                    Position = new Vector2(ScreenWidth / 2, ScreenHeight / 2),
                    CollisionType = CollisionTypes.None,
                    Colour = Color.Transparent,
        },
         new Sprite(Content.Load<Texture2D>("Buttons/newbutton"))
        {
         Position = new Vector2(1543, 588),
          CollisionType = CollisionTypes.None,
          Colour = Color.Transparent,
        },
         new Sprite(Content.Load<Texture2D>("Buttons/replay"))
        {
         Position = new Vector2(1590,423),
          CollisionType = CollisionTypes.None,
          Colour=Color.Transparent,
        },
         new Sprite(Content.Load<Texture2D>("Buttons/quit"))
        {
         Position = new Vector2(1590,912),
          CollisionType = CollisionTypes.None,
          Colour=Color.Transparent,
        },
         
     };
            if (currentLevel == 3)
                _spritesLevel3 = new List<Sprite>()
                {
                    new Sprite(Content.Load<Texture2D>("Backgrounds/BG"))
                        {
                          Position = new Vector2(ScreenWidth / 2, ScreenHeight / 2),
                          CollisionType = CollisionTypes.None,
                        },
                            new Player(Content.Load<Texture2D>("Blocks/Player"),Content.Load<SoundEffect>("sounds/mouseclickstart"))
                        {
                          Position = new Vector2(750, 450),
                          CollisionType = CollisionTypes.Full,
                        },
                            new Sprite(YellowBlock3Tex)
                        {
                          Position = new Vector2(1563, 873),
                          Colour = Color.White,
                          CollisionType = CollisionTypes.Full,
                        },
                            new Sprite(GreyBlock4Tex)
                        {
                          Position = new Vector2(1324, 540 ),
                          Colour = Color.White,
                          CollisionType = CollisionTypes.Full,
                        },
                            new Sprite(GreyBlock5Tex)
                        {
                          Position = new Vector2(779, 540),
                          Colour = Color.White,
                          CollisionType = CollisionTypes.Full,
                        },
                            new Sprite(GoalBlockTex)
                        {
                          Position = new Vector2(1350, 450),
                          Colour = Color.White,
                          CollisionType = CollisionTypes.Full,

                        },
                             new Sprite(Content.Load<Texture2D>("Backgrounds/winnew"))
                        {
                                    Position = new Vector2(ScreenWidth / 2, ScreenHeight / 2),
                                    CollisionType = CollisionTypes.None,
                                    Colour = Color.Transparent,
                        },
                        new Sprite(Content.Load<Texture2D>("Backgrounds/losenew"))
                        {
                                    Position = new Vector2(ScreenWidth / 2, ScreenHeight / 2),
                                    CollisionType = CollisionTypes.None,
                                    Colour = Color.Transparent,
                        },

                         new Sprite(Content.Load<Texture2D>("Buttons/arrow"))
                        {
                         Position = new Vector2(1427, 477),
                          CollisionType = CollisionTypes.None,
                          Colour=Color.Transparent,
                        },
                         new Sprite(Content.Load<Texture2D>("Buttons/replay"))
                            {
                             Position = new Vector2(1590,423),
                              CollisionType = CollisionTypes.Full,
                              Colour=Color.Transparent,
                            },
                             new Sprite(Content.Load<Texture2D>("Buttons/quit"))
                            {
                             Position = new Vector2(1590,912),
                              CollisionType = CollisionTypes.Full,
                              Colour=Color.Transparent,
                            },
                         /*new Sprite(Content.Load<Texture2D>("Buttons/replay"))
                    {
                     Position = new Vector2(ScreenWidth / 2, ScreenHeight / 2),
                      CollisionType = CollisionTypes.Full,
                      Colour=Color.Transparent,
                    },*/
                };
            if (currentLevel == 4)
            _spritesLevelFinal = new List<Sprite>()
      {
        new Sprite(Content.Load<Texture2D>("Backgrounds/BG"))
        {
          Position = new Vector2(ScreenWidth / 2, ScreenHeight / 2),
          CollisionType = CollisionTypes.None,
        },
            new Player(Content.Load<Texture2D>("Blocks/Player"),Content.Load<SoundEffect>("sounds/mouseclickstart"))
        {
          Position = new Vector2(88, 691),
          CollisionType = CollisionTypes.Full,
        },
        new Sprite(BlueBlock2Tex)
        {
          Position = new Vector2(300, 750),
          Colour = Color.White,
          CollisionType = CollisionTypes.Full,
          Velocity = new Vector2(0, 2),
        },
        new Sprite(GreyBlock2Tex)//done
        {
          Position = new Vector2(120, 751),
          Colour = Color.White,
          CollisionType = CollisionTypes.Full,
        },
        new Sprite(GreyBlock4Tex)//done
        {
          Position = new Vector2(481, 424),
          Colour = Color.White,
          CollisionType = CollisionTypes.Full,
        },
        new Sprite(GreyBlockV6Tex)//done
        {
          Position = new Vector2(1231, 421),
          Colour = Color.White,
          CollisionType = CollisionTypes.Full,
        },
         new Sprite(BlueBlock8Tex)//not
        {
          Position = new Vector2(1230, 485),
          Colour = Color.Transparent,
          CollisionType = CollisionTypes.None,
          //Velocity = new Vector2(2, 0),
        },
         new Sprite(InvisbleColTex)
        {
          Position = new Vector2(810, 400),
          Colour = Color.Transparent,
          CollisionType = CollisionTypes.None,
        },
         new Sprite(InvisbleColTex)
        {
          Position = new Vector2(1700, 400),
          Colour = Color.Transparent,
          CollisionType = CollisionTypes.None,
        },
          new Sprite(InvisbleColTex)
        {
          Position = new Vector2(300, 100),
          Colour = Color.Transparent,
          CollisionType = CollisionTypes.None,
        },
        new Sprite(InvisbleColTex)
        {
          Position = new Vector2(300, 1000),
          Colour = Color.Transparent,
          CollisionType = CollisionTypes.None,
        },
        new Sprite(BlueBlock5Tex)//not
        {
          Position = new Vector2(1680, 1000),
          Colour = Color.Transparent,
          CollisionType = CollisionTypes.None,
        },
        new Sprite(GreyBlock6Tex)
        {
          Position = new Vector2(841, 813),
          Colour = Color.White,
          CollisionType = CollisionTypes.Full,
        },
        new Sprite(YellowBlock3Tex)//orange 4
        {
          Position = new Vector2(1560, 990),
          Colour = Color.White,
          CollisionType = CollisionTypes.Full,
        },
        new Sprite(YellowBlock4Tex)//not
        {
          Position = new Vector2(1520, 925),
          Colour = Color.Transparent,
          CollisionType = CollisionTypes.None,
        },
        new Sprite(RedBlock3Tex)//orange 3
        {
          Position = new Vector2(1591, 873),
          Colour = Color.White,
          CollisionType = CollisionTypes.Full,
        },

        new Sprite(GreyBlock2Tex)
        {
          Position = new Vector2(1440,568),
          Colour = Color.White,
          CollisionType = CollisionTypes.Full,
        },
        new Sprite(GoalBlockTex)
        {
          Position = new Vector2(1470, 510),
          Colour = Color.White,
          CollisionType = CollisionTypes.Full,
        },
        new Sprite(OrangeBlockV3Tex)
        {
          Position = new Vector2(1591,873),
          Colour = Color.Transparent,
          CollisionType = CollisionTypes.None,
        },
        new Sprite(OrangeBlockV4Tex)
        {
          Position = new Vector2(1560, 990),
          Colour = Color.Transparent,
          CollisionType = CollisionTypes.None,
        },
        new Sprite(Content.Load<Texture2D>("Backgrounds/winfinal"))
        {
                    Position = new Vector2(ScreenWidth / 2, ScreenHeight / 2),
                    CollisionType = CollisionTypes.None,
                    Colour = Color.Transparent,
        },
        new Sprite(Content.Load<Texture2D>("Backgrounds/losenew"))
        {
                    Position = new Vector2(ScreenWidth / 2, ScreenHeight / 2),
                    CollisionType = CollisionTypes.None,
                    Colour = Color.Transparent,
        },
                            new Sprite(Content.Load<Texture2D>("Buttons/replay"))
                            {
                             Position = new Vector2(1590,423),
                              CollisionType = CollisionTypes.Full,
                              Colour=Color.Transparent,
                            },
                             new Sprite(Content.Load<Texture2D>("Buttons/quit"))
                            {
                             Position = new Vector2(1590,912),
                              CollisionType = CollisionTypes.Full,
                              Colour=Color.Transparent,
                            },
               
        /*
        new Sprite(texture)
        {
          Position = new Vector2(600, 350),
          Colour = Color.Black,
          CollisionType = CollisionTypes.Full,
        },*/
      };
            /*
            if(currentLevel==1)
            {
                soundEffects[1].Play();
                
            }

            if (currentLevel == 2)
            {
                soundEffects[1].Play();
            }

            if (currentLevel == 3)
            {
                soundEffects[1].Play();
            }

            if (currentLevel == 4)
            {
                soundEffects[1].Play();
            }

            */
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {


            if (currentLevel == 1)
                foreach (var sprite in _spritesLevel1)
                    sprite.Update(gameTime);

            if (currentLevel == 2)
                foreach (var sprite in _spritesLevel2)
                    sprite.Update(gameTime);

            if (currentLevel == 3)
                foreach (var sprite in _spritesLevel3)
                    sprite.Update(gameTime);

            if (currentLevel == 4)
            foreach (var sprite in _spritesLevelFinal)
                sprite.Update(gameTime);

            CheckCollision(gameTime);

            if (currentLevel == 1)
                foreach (var sprite in _spritesLevel1)
                    sprite.ApplyPhysics(gameTime);

            if (currentLevel == 2)
                foreach (var sprite in _spritesLevel2)
                    sprite.ApplyPhysics(gameTime);

            if (currentLevel == 3)
                foreach (var sprite in _spritesLevel3)
                    sprite.ApplyPhysics(gameTime);

            if (currentLevel == 4)
                foreach (var sprite in _spritesLevelFinal)
                sprite.ApplyPhysics(gameTime);

            if (currentLevel == 4)
            {
                AnimateBlocks();               
            }

            DragDropClick();
            WinGame();
            LoseGame();


            base.Update(gameTime);

            //Console.WriteLine("Player pos X : " + _spritesLevel2[1].Position.X);
            //Console.WriteLine("Player pos Y : " + _spritesLevel2[1].Position.Y);
        }

        public void AnimateBlocks()
        {
            //if (_sprites[6].Position.X <= 965)
            //    _sprites[6].Velocity = -_sprites[6].Velocity;

            //if (_sprites[6].Position.X >= 1650)
            //    _sprites[6].Velocity = -_sprites[6].Velocity;

            if (_spritesLevelFinal[2].Position.Y <= 200)
                _spritesLevelFinal[2].Velocity = -_spritesLevelFinal[2].Velocity;

            if (_spritesLevelFinal[2].Position.Y >= 870)
                _spritesLevelFinal[2].Velocity = -_spritesLevelFinal[2].Velocity;
        }

        public void DragDropClick()
        {
            var mouseState = Mouse.GetState();
            
            var mousePosition = new Vector2(mouseState.X, mouseState.Y);

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                
                    
                    if (currentLevel == 1)
                    {
                        if (_spritesLevel1[6].Rectangle.Contains(mousePosition)&&_spritesLevel1[4].Colour==Color.White)
                        {
                            _spritesLevel1[6].CollisionType = CollisionTypes.None;
                            UnloadContent();
                            currentLevel = 2;
                            LoadContent();
                            
                        }                   
                        if(_spritesLevel1[8].Rectangle.Contains(mousePosition))
                        {
                            _spritesLevel1[8].Colour = Color.Transparent;
                            _spritesLevel1[8].CollisionType = CollisionTypes.None;

                            _spritesLevel1[7].Colour = Color.Transparent;
                            
                        }
                        if(_spritesLevel1[5].Colour==Color.White)
                        {
                            //_spritesLevel1[9].Colour = Color.White;
                            if (_spritesLevel1[9].Rectangle.Contains(mousePosition))
                            {
                                LoadContent();
                            }
                            if (_spritesLevel1[10].Rectangle.Contains(mousePosition))
                            {
                                Exit();
                            }


                        }
                        /*else if(_spritesLevel1[9].Rectangle.Contains(mousePosition))
                        {
                            LoadContent();
                        }
                        */

                    }
                    if (currentLevel == 2 )
                    {
                        if (_spritesLevel2[1].Position.X >= 1040)
                        {
                            if (_spritesLevel2[7].Rectangle.Contains(mousePosition))
                            {
                                //_spritesLevel2[7].CollisionType = CollisionTypes.None;
                                UnloadContent();
                                currentLevel = 3;
                                LoadContent();
                            }
                        }
                    
                        
                        if (_spritesLevel2[6].Colour !=Color.Transparent)
                        {
                            //_spritesLevel2[8].Colour = Color.White;
                           // _spritesLevel2[9].Colour = Color.White;

                            if (_spritesLevel2[8].Rectangle.Contains(mousePosition))
                            {
                                currentLevel = 1;
                                LoadContent();
                            }
                            if (_spritesLevel2[9].Rectangle.Contains(mousePosition))
                            {
                                Exit();
                            }


                        }
                        /*else if (_spritesLevel1[9].Rectangle.Contains(mousePosition))
                        {
                            LoadContent();
                        }*/
                    }

                    if (currentLevel == 3)
                    {
                        if (_spritesLevel3[2].Rectangle.Contains(mousePosition))
                        {
                            _spritesLevel3[2].Position = mousePosition;
                        }


                        if(_spritesLevel3[1].Position.X >= 1285)
                        {
                            //_spritesLevel3[8].Colour = Color.White;
                           
                            if (_spritesLevel3[8].Rectangle.Contains(mousePosition))
                            {
                                UnloadContent();
                                currentLevel = 4;
                                LoadContent();
                            }
                        }
                    if (_spritesLevel3[7].Colour != Color.Transparent)
                    {
                        //_spritesLevel2[8].Colour = Color.White;
                        // _spritesLevel2[9].Colour = Color.White;

                        if (_spritesLevel3[9].Rectangle.Contains(mousePosition))
                        {
                            currentLevel = 1;
                            LoadContent();
                        }
                        if (_spritesLevel3[10].Rectangle.Contains(mousePosition))
                        {
                            Exit();
                        }


                    }




                }

                    if (currentLevel == 4 )
                    {

                            
                                if (_spritesLevelFinal[11].Rectangle.Contains(mousePosition))
                                {
                                    _spritesLevelFinal[11].Position = mousePosition;
                                }
                                //else if (_sprites[12].Rectangle.Contains(mousePosition))
                                //{
                                //    _sprites[12].Position = mousePosition;
                                //}
                                else if (_spritesLevelFinal[13].Rectangle.Contains(mousePosition))
                                {
                                    _spritesLevelFinal[13].Position = mousePosition;
                                }
                                else if (_spritesLevelFinal[14].Rectangle.Contains(mousePosition))
                                {
                                    _spritesLevelFinal[14].Position = mousePosition;
                                }
                                else if (_spritesLevelFinal[15].Rectangle.Contains(mousePosition))
                                {
                                    _spritesLevelFinal[15].Position = mousePosition;
                                }
                                else if (_spritesLevelFinal[18].Rectangle.Contains(mousePosition))
                                {
                                    _spritesLevelFinal[18].Position = mousePosition;
                                }
                                else if (_spritesLevelFinal[19].Rectangle.Contains(mousePosition))
                                {
                                    _spritesLevelFinal[19].Position = mousePosition;
                                }
                            
                            

                        // Check if the mouse position is inside the rectangle
                        
                    
                    if (_spritesLevelFinal[21].Colour != Color.Transparent)
                    {
                        //_spritesLevel2[8].Colour = Color.White;
                        // _spritesLevel2[9].Colour = Color.White;

                        if (_spritesLevelFinal[22].Rectangle.Contains(mousePosition))

                        {
                            currentLevel = 1;
                            LoadContent();
                        }
                        if (_spritesLevelFinal[23].Rectangle.Contains(mousePosition))
                        {
                            Exit();
                        }


                    }

                }   
                
            }                       
        }

        public void CheckCollision(GameTime gameTime)
        {
            if (currentLevel == 1)
            {
                var collidableSprites = _spritesLevel1.Where(c => c.CollisionType != CollisionTypes.None);

                foreach (var spriteA in collidableSprites)
                {
                    foreach (var spriteB in collidableSprites)
                    {
                        // Don't do anything if they're the same sprite!
                        if (spriteA == spriteB)
                            continue;

                        if (spriteA.WillIntersect(spriteB))
                            //if (spriteA.Rectangle.Intersects(spriteB.Rectangle))
                            spriteA.OnCollide(spriteB);
                    }
                }
            }

            if (currentLevel == 2)
            {
                var collidableSprites = _spritesLevel2.Where(c => c.CollisionType != CollisionTypes.None);

                foreach (var spriteA in collidableSprites)
                {
                    foreach (var spriteB in collidableSprites)
                    {
                        // Don't do anything if they're the same sprite!
                        if (spriteA == spriteB)
                            continue;

                        if (spriteA.WillIntersect(spriteB))
                            //if (spriteA.Rectangle.Intersects(spriteB.Rectangle))
                            spriteA.OnCollide(spriteB);
                    }
                }
            }

            if (currentLevel == 3)
            {
                var collidableSprites = _spritesLevel3.Where(c => c.CollisionType != CollisionTypes.None);

                foreach (var spriteA in collidableSprites)
                {
                    foreach (var spriteB in collidableSprites)
                    {
                        // Don't do anything if they're the same sprite!
                        if (spriteA == spriteB)
                            continue;

                        if (spriteA.WillIntersect(spriteB))
                            //if (spriteA.Rectangle.Intersects(spriteB.Rectangle))
                            spriteA.OnCollide(spriteB);
                    }
                }
            }

            if (currentLevel == 4)
            {
                var collidableSprites = _spritesLevelFinal.Where(c => c.CollisionType != CollisionTypes.None);

                foreach (var spriteA in collidableSprites)
                {
                    foreach (var spriteB in collidableSprites)
                    {
                        // Don't do anything if they're the same sprite!
                        if (spriteA == spriteB)
                            continue;

                        if (spriteA.WillIntersect(spriteB))
                            //if (spriteA.Rectangle.Intersects(spriteB.Rectangle))
                            spriteA.OnCollide(spriteB);
                    }
                }
            }
        }

        public void WinGame()
        {
            //int c = 0;
            if (currentLevel == 1)
            {
               
                if (_spritesLevel1[1].Position.X >= 930 )
                {
                    soundwin();
                    
                    
                    
                    _spritesLevel1[4].Colour = Color.White;
                    _spritesLevel1[6].Colour = Color.White;
                    _spritesLevel1[6].CollisionType = CollisionTypes.Full;
                    
                   
                    
                }

            }

            if (currentLevel == 2)
            {
               // c = 0;
                //Console.WriteLine("Player pos X : " + _spritesLevel2[1].Position.X);
                //Console.WriteLine("Player pos Y : " + _spritesLevel2[1].Position.Y);                

                if (_spritesLevel2[1].Position.X >= 1040 )
                {
                    //Console.WriteLine("_sprite 2 collision type : " + _spritesLevel2[7].CollisionType);
                   
                    soundwin();


                    _spritesLevel2[5].Colour = Color.White;
                    _spritesLevel2[7].Colour = Color.White;
                    _spritesLevel2[7].CollisionType = CollisionTypes.Full;
                    
                }
            }

            if(currentLevel==3)
            {
                //c = 0;
                
                if (_spritesLevel3[1].Position.X >= 1285)
                {
                    soundwin();
                    _spritesLevel3[6].Colour = Color.White;
                   
                }
            }

            if (currentLevel == 4)
            {
               // c = 0;
               
                if (_spritesLevelFinal[1].Position.X >= 1400 && _spritesLevelFinal[1].Position.Y >= 450)   
                {
                    soundwin();
                    _spritesLevelFinal[20].Colour = Color.White;
                    
                }
            }
        }

        private void soundwin()
        {
            //bool c =true;
            if(currentLevel==1)
            {
                if (c1)
                {

                    soundEffects[2].Play();

                }
                c1 = false;
            }

            if (currentLevel == 2)
            {
                if (c2)
                {

                    soundEffects[2].Play();

                }
                c2 = false;
            }

            if (currentLevel == 3)
            {
                if (c3)
                {

                    soundEffects[2].Play();

                }
                c3 = false;
            }
            if (currentLevel == 4)
            {
                if (c4)
                {

                    soundEffects[2].Play();

                }
                c4 = false;
            }

        }


        

        public void LoseGame()
        {
            if (currentLevel == 1)
            {
                if (_spritesLevel1[1].Position.Y >= 950)
                {
                    soundlose();
                    _spritesLevel1[5].Colour = Color.White;

                    
                }
            }
            if (currentLevel == 2)
            {
                if (_spritesLevel2[1].Position.Y >= 950)
                {
                    soundlose();
                    _spritesLevel2[6].Colour = Color.White;
                }
            }
            if (currentLevel == 3)
            {
                if (_spritesLevel3[1].Position.Y >= 950)
                {
                    soundlose();
                    _spritesLevel3[7].Colour = Color.White;
                }
            }
            if (currentLevel == 4)
            {
                if (_spritesLevelFinal[1].Position.Y >= 950)
                {
                    soundlose();
                    _spritesLevelFinal[21].Colour = Color.White;
                }
            }
        }

        private void soundlose()
        {
            //bool c =true;
            if (currentLevel == 1)
            {
                if (c11)
                {

                    soundEffects[3].Play();

                }
                c11 = false;
            }

            if (currentLevel == 2)
            {
                if (c21)
                {

                    soundEffects[3].Play();

                }
                c21 = false;
            }

            if (currentLevel == 3)
            {
                if (c31)
                {

                    soundEffects[3].Play();

                }
                c31 = false;
            }
            if (currentLevel == 4)
            {
                if (c41)
                {

                    soundEffects[3].Play();

                }
                c41 = false;
            }

        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //soundEffects[1].Play();

            spriteBatch.Begin();

            if (currentLevel == 1)
                foreach (var sprite in _spritesLevel1)
                    sprite.Draw(gameTime, spriteBatch);

            if (currentLevel == 2)
                foreach (var sprite in _spritesLevel2)
                    sprite.Draw(gameTime, spriteBatch);

            if (currentLevel == 3)
                foreach (var sprite in _spritesLevel3)
                    sprite.Draw(gameTime, spriteBatch);

            if (currentLevel == 4)
            foreach (var sprite in _spritesLevelFinal)
                sprite.Draw(gameTime, spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }       
    }
}
