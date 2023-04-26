/*using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public class Game1 : Game
{
    private GraphicsDeviceManager graphics;
    private SpriteBatch spriteBatch;
    private Texture2D texture;
    private Vector2 position;
    private float radius;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        texture = Content.Load<Texture2D>("texture");
        position = new Vector2(GraphicsDevice.Viewport.Width / 2f, GraphicsDevice.Viewport.Height / 2f);
        radius = 0f;
    }

    protected override void Update(GameTime gameTime)
    {
        float totalTime = (float)gameTime.TotalGameTime.TotalSeconds;
        radius = MathHelper.Lerp(0f, 500f, (float)Math.Sin(totalTime));
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);

        Color color = Color.White;
        for (int i = 0; i < texture.Width; i++)
        {
            for (int j = 0; j < texture.Height; j++)
            {
                Vector2 texturePosition = position + new Vector2(i - texture.Width / 2f, j - texture.Height / 2f);
                float distance = Vector2.Distance(texturePosition, position);
                if (distance <= radius)
                {
                    float grayScale = MathHelper.Lerp(1f, 0f, distance / radius);
                    color = new Color(grayScale, grayScale, grayScale);
                }
                else
                {
                    color = Color.White;
                }
                spriteBatch.Draw(texture, texturePosition, color);
    


        Color color = Color.White;
        for (int i = 0; i < texture.Width; i++)
        {
            for (int j = 0; j < texture.Height; j++)
            {
                Vector2 texturePosition = new Vector2(i, j);
                Vector2 textureCenter = new Vector2(texture.Width / 2f, texture.Height / 2f);
                float distance = Vector2.Distance(texturePosition, textureCenter);
                if (distance <= radius)
                {
                    float alpha = MathHelper.Lerp(0f, 1f, distance / radius);
                    color = new Color(alpha, alpha, alpha);
                }
                else
                {
                    color = Color.White;
                }
                spriteBatch.Draw(texture, position + texturePosition - textureCenter, color);
            }
        }

        spriteBatch.End();

        base.Draw(gameTime);
    }
}

}*/
