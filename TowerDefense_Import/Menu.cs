using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace TowerDefence
{
    public class CMenu
    {
        private Vector2 m_gameName;   //pozycja nazwy gry
        private double m_quake_time;    //czas do drgnêcia czasu gry
        private const double m_quake_cooldown = 0.02;    //co jaki czas napis ma drgn¹æ?
        private Random Rand;    //obiekt do losowania
        private int ret;    //wartoœæ zwracana przez Check()
        private List<CButton> buttons;  //lista przycisków map
        private bool blockclick;

        private CButton b_quit;

        public CMenu()
        {
            this.m_gameName.X = StaticVectors.Menu.GameName.X;
            this.m_gameName.Y = StaticVectors.Menu.GameName.Y;
            this.m_quake_time = 0d;
            this.Rand = new Random();
            this.ret = -1;
            this.buttons = new List<CButton>();
            this.blockclick = true;
            this.b_quit = new CButton( StaticVectors.Menu.Button_quit, StaticTextures.Buttons.Menu_Quit, StaticTextures.Buttons.Menu_Quit_f, StaticTextures.Buttons.Menu_Quit );

            CreateButtons();
        }
        private void CreateButtons()
        {
            this.buttons.Add( new CButton( StaticVectors.Menu.Buttons_stage[0], StaticTextures.Menu_Button_Stage001, StaticTextures.Menu_Button_Stage001f, StaticTextures.Menu_Button_Lock ) );
            this.buttons.Add( new CButton( StaticVectors.Menu.Buttons_stage[1], StaticTextures.Menu_Button_Stage002, StaticTextures.Menu_Button_Stage002f, StaticTextures.Menu_Button_Lock ) );

            this.buttons.Add( new CButton( StaticVectors.Menu.Buttons_stage[2], StaticTextures.Menu_Button_Stage003, StaticTextures.Menu_Button_Stage003f, StaticTextures.Menu_Button_Lock ) );
        }

        public void Start() //wywo³uje siê w chwili pokazania menu
        {
            blockclick = true;
        }
        public void End()   //wywo³uje siê w chwili zamykania menu
        {
            ret = -1;
        }

        public void Update( GameTime gameTime )
        {
            //drganie napisu
            if( m_quake_time <= gameTime.TotalGameTime.TotalSeconds ){
                m_gameName.X = StaticVectors.Menu.GameName.X + Rand.Next( StaticConsts.Menu.ErrorGameName );
                m_gameName.Y = StaticVectors.Menu.GameName.Y + Rand.Next( StaticConsts.Menu.ErrorGameName );
                m_quake_time = gameTime.TotalGameTime.TotalSeconds + m_quake_cooldown;
            }

            //aktualizowanie przycisków
            for( int i = 0; i < buttons.Count(); ++i )
            {
                if( buttons[i].Update( gameTime ) && !blockclick )
                {
                    this.ret = i;
                    if( !( Mouse.GetState().LeftButton == ButtonState.Pressed ) && blockclick )
                        blockclick = true;
                }
            }
            if( this.b_quit.Update( gameTime ) )
                ret = -2;

            //odblokowanie przycisku
            if( !(Mouse.GetState().LeftButton == ButtonState.Pressed) && blockclick )
                blockclick = false;
        }
        public int Check()
        {
            return this.ret;
        }
        public void Draw( SpriteBatch spriteBatch, GameTime gameTime )
        {
            spriteBatch.Draw( StaticTextures.Menu_Main_Background, Vector2.Zero, Color.White );
            spriteBatch.Draw( StaticTextures.Menu_gamename, m_gameName, Color.White );
            spriteBatch.Draw( StaticTextures.Menu_Border_Frame, StaticVectors.Menu.Frame, Color.White );

            //rysowanie guzików map
            foreach( CButton but in buttons )
                but.Draw( spriteBatch );
            //i innych przycisków
            this.b_quit.Draw( spriteBatch );
        }
    }
}
