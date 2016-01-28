using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics; 

namespace ObjectTesting
{
    class AutomatedSprite:Sprite
    {
        public AutomatedSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed) 
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed) //uses default animation speed
        { 

        }

        public AutomatedSprite(Texture2D textureImage, Vector2 position, Point frameSize, int collisionOffset, Point currentFrame, Point sheetSize, Vector2 speed, int millisecondsPerFrame) 
            : base(textureImage, position, frameSize, collisionOffset, currentFrame, sheetSize, speed, millisecondsPerFrame) //uses specific animation speed
        { 

        }

        public override Vector2 direction 
        { 
            get 
            { 
                return speed; 
            } 
        }

        public override void Update(GameTime gameTime, Rectangle clientBounds)
        {
            position += direction; //simply moves in whatever speed is specified in the constructor
            base.Update(gameTime, clientBounds);
        }



    }
}
