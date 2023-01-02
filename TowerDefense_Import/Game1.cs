using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
//using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

public enum GameState
{
    MENU,
    PLAY_LEVEL,
    QUIT_THE_GAME
}

namespace TowerDefence
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        string copyrighttext = " Grzegorz Kupczyk\nCopyright (c) 2014";
        Vector2 copyrightposshadow, copyrightpos;

        bool lastMenu;  //czy ostatnio by³o update'owane menu? (ostatnio, czyli w poprzedniej klatce gry)
        bool tutorial;  //czy samouczek zostal wywo³any?
        CStage Plansza;
        CMenu Menu;
        GameState g_GameState;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
        //wykonuje siê przed LoadContent
        protected override void Initialize()
        {
            lastMenu = false;
            tutorial = false;
            g_GameState = GameState.MENU;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            StaticTextures.Load(Content);
            StaticFonts.Load(Content);
            StaticSprites.Load();
            StaticTowers.Load();
            StaticEnemies.Load();
            StaticStages.CreateStages();

            Menu = new CMenu();

            copyrightposshadow = new Vector2( GraphicsDevice.Viewport.TitleSafeArea.Right - StaticFonts.CopyRight.MeasureString( copyrighttext ).X - 20, GraphicsDevice.Viewport.TitleSafeArea.Bottom - StaticFonts.CopyRight.MeasureString( copyrighttext ).Y - 2 );
            copyrightpos = copyrightposshadow - new Vector2( 1 );
        }

        
        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState stan = Keyboard.GetState();
            
            switch(g_GameState)
            {
                case GameState.MENU:
                    {
                        if( !lastMenu )
                            Menu.Start();
                        Menu.Update( gameTime );
                        lastMenu = true;
                        int ret = Menu.Check(); //-2=exit//-1=nic//(0=<x<=5)=plansza//
                        if( ret >= 0 )
                        {
                            Plansza = new CStage( StaticStages.stages[ret] );  //w³¹cz odpowiedni level
                            if( !tutorial ){
                                tutorial = true;
                                Plansza.StartTutorial();
                            }
                            g_GameState = GameState.PLAY_LEVEL;
                            Menu.End();
                            lastMenu = false;
                        }
                        if( ret == -2 )
                        {
                            Menu.End();
                            g_GameState = GameState.QUIT_THE_GAME;
                        }
                        break;
                    }
                case GameState.PLAY_LEVEL:
                    {
                        lastMenu = false;
                        switch( Plansza.Update( gameTime ) )
                        {
                            case 1:
                                g_GameState = GameState.MENU; //powrót do menu
                                Menu.Start();
                                break;
                            case -1:
                                g_GameState = GameState.QUIT_THE_GAME;  //wyjœcie z gry
                                break;
                        }
                        break;
                    }
                case GameState.QUIT_THE_GAME:
                    {
                        this.Exit();
                        break;
                    }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);  //ten kolor ma okazjê mign¹æ przy wy³¹czaniu gry ;)
            spriteBatch.Begin();
            switch( g_GameState )
            {
                case GameState.MENU:
                    {
                        Menu.Draw( spriteBatch, gameTime );
                        break;
                    }
                case GameState.PLAY_LEVEL:
                    {
                        Plansza.Draw( spriteBatch, gameTime );
                        break;
                    }
            }

            //COPYRIGHT (C) PRAWA AUTORSKIE
            spriteBatch.DrawString( StaticFonts.CopyRight, copyrighttext, copyrightposshadow, Color.Black );
            spriteBatch.DrawString( StaticFonts.CopyRight, copyrighttext, copyrightpos, Color.Azure );

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
