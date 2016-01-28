using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace ObjectTesting
{
    public class SpriteManager : Microsoft.Xna.Framework.DrawableGameComponent
    {
        SpriteBatch spriteBatch; 
        UserControlledSprite player; 
        List<Sprite> spriteList = new List<Sprite>();

        UserControlledSprite playerWalking;
        UserControlledSprite playerStanding;

        Texture2D standingTexture;
        Texture2D walkingTexture;

        public SpriteManager(Game game)
            : base(game)
        {
        }
        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);

            standingTexture = Game.Content.Load<Texture2D>("StandingTest");
            walkingTexture = Game.Content.Load<Texture2D>("Walkingtest");

            playerStanding = new UserControlledSprite(Game.Content.Load<Texture2D>("StandingTest"), Vector2.Zero, new Point(80, 80), 16, new Point(0, 0), new Point(1, 0), new Vector2(6, 6));
            playerWalking = new UserControlledSprite(walkingTexture, Vector2.Zero, new Point(80, 80), 60, new Point(0, 0), new Point(4, 0), new Vector2(6, 6), 100);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyUp(Keys.A) && Keyboard.GetState().IsKeyUp(Keys.D))
            {
                player = playerStanding;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                player = playerWalking;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                player = playerWalking;
            }

            player.Update(gameTime, Game.Window.ClientBounds);

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);
            player.Draw(gameTime, spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
           
        }
    }
}
