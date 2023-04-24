using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

// The Command interface defines a method for executing a command
public interface ICommand
{
    void Execute();
}

// A concrete implementation of the Command interface that represents a specific command
public class MoveCommand : ICommand
{
    private Vector2 _movement;
    private Player _player;

    public MoveCommand(Player player, Vector2 movement)
    {
        _player = player;
        _movement = movement;
    }

    public void Execute()
    {
        _player.Move(_movement);
    }
}

// A composite command that can hold a collection of other commands
public class CompositeCommand : ICommand
{
    private List<ICommand> _commands = new List<ICommand>();

    public void AddCommand(ICommand command)
    {
        _commands.Add(command);
    }

    public void RemoveCommand(ICommand command)
    {
        _commands.Remove(command);
    }

    public void Execute()
    {
        foreach (var command in _commands)
        {
            command.Execute();
        }
    }
}

// The Invoker class that will execute the commands
public class InputHandler
{
    private Dictionary<Keys, ICommand> _commands = new Dictionary<Keys, ICommand>();

    public void SetCommand(Keys key, ICommand command)
    {
        _commands[key] = command;
    }

    public void HandleInput(KeyboardState keyboardState)
    {
        foreach (Keys key in keyboardState.GetPressedKeys())
        {
            if (_commands.ContainsKey(key))
            {
                _commands[key].Execute();
            }
        }
    }
}

// The Player class that will be moved by the MoveCommand
public class Player
{
    private Vector2 _position;

    public Player(Vector2 position)
    {
        _position = position;
    }

    public void Move(Vector2 movement)
    {
        _position += movement;
    }

    public void Draw(SpriteBatch spriteBatch, Texture2D texture)
    {
        spriteBatch.Draw(texture, _position, Color.White);
    }
}

// The Game class that will create and manage the objects
public class Game1 : Game
{
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    InputHandler inputHandler;
    Player player;
    Texture2D playerTexture;

    public Game1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
        inputHandler = new InputHandler();
        player = new Player(new Vector2(100, 100));
        base.Initialize();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        playerTexture = Content.Load<Texture2D>("Player");
    }

    protected override void Update(GameTime gameTime)
    {
        KeyboardState keyboardState = Keyboard.GetState();
        inputHandler.HandleInput(keyboardState);
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        spriteBatch.Begin();
        player.Draw(spriteBatch, playerTexture);
        spriteBatch.End();
        base.Draw(gameTime);
    }

    static void Main()
    {
        using (var game = new Game1())
            game.Run();
    }
}
