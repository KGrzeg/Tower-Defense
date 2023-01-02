using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefence
{
    public enum MyButtonState
    {
        Normal, //=0
        Lock,   //=1
        Focus,  //=2
        Special //=3
    }
    public enum EnemyType
    {
        Normal, //=0
        Fly     //=1
    }
    public struct MenuTowerItem
    {
        public CTower tower;
        public CButton button;
        public int id;

        public MenuTowerItem(CTower towwer, CButton but, int id)
        {
            this.tower = towwer;
            this.button = but;
            this.id = id;
        }
    }
    public class CWave : ICloneable
    {
        public List<CEnemy> Enemies;
        private int CurEnemy;

        public CWave()
        {
            this.Enemies = new List<CEnemy>();
            this.CurEnemy = 0;
        }
        public CWave( CWave wave )
            :this()
        {
            this.Enemies = new List<CEnemy>( wave.Enemies );
        }
        public CEnemy GetEnemy()
        {
            if (CurEnemy >= Enemies.Count())
            {
                return null;
            }

            CEnemy ret = Enemies[CurEnemy];

            ++CurEnemy;
            return ret;
        }
        object ICloneable.Clone()
        {
            return this.Clone();
        }
        public CWave Clone()
        {
            return ( CWave )this.MemberwiseClone();
        }
    }

    public class Line
    {
        //źródło: http://stackoverflow.com/questions/270138/how-do-i-draw-lines-using-xna
        protected Texture2D pixel = StaticTextures.Dot;
        public Vector2 p1, p2; //this will be the position in the center of the line
        protected int length;
        public int thickness; //length and thickness of the line, or width and height of rectangle
        protected Rectangle rect; //where the line will be drawn
        protected float rotation; // rotation of the line, with axis at the center of the line
        public Color color;

        //p1 and p2 are the two end points of the line
        public Line( Vector2 p1, Vector2 p2, int thickness, Color color )
        {
            this.p1 = p1;
            this.p2 = p2;
            this.thickness = thickness;
            this.color = color;
        }

        public void Update( GameTime gameTime )
        {
            length = ( int )Vector2.Distance( p1, p2 ); //gets distance between the points
            rotation = getRotation( p1.X, p1.Y, p2.X, p2.Y ); //gets angle between points(method on bottom)
            rect = new Rectangle( ( int )p1.X, ( int )p1.Y, length, thickness );

            //To change the line just change the positions of p1 and p2
        }

        public void Draw( SpriteBatch spriteBatch, GameTime gameTime )
        {
            spriteBatch.Draw( pixel, rect, null, color, rotation, Vector2.Zero, SpriteEffects.None, 0f );
        }

        //this returns the angle between two points in radians 
        private float getRotation( float x, float y, float x2, float y2 )
        {
            float adj = x - x2;
            float opp = y - y2;
            float tan = opp / adj;
            float res = MathHelper.ToDegrees( ( float )Math.Atan2( opp, adj ) );
            res = ( res - 180 ) % 360;
            if( res < 0 ) { res += 360; }
            res = MathHelper.ToRadians( res );
            return res;
        }
    }

    public class MyFunctions
    {
        public static void DrawVector(SpriteBatch spriteBatch, Vector2 where, int size, Color color)
        {
            Rectangle rec = new Rectangle((int)where.X - size / 2, (int)where.Y - size / 2, size, size);
            spriteBatch.Draw(StaticTextures.Dot, rec, color);
        }
        public static void DrawCircle(SpriteBatch spriteBatch, Vector2 O, float range, int total, int pointsize, Color color)
        {
            Vector2 point = new Vector2();
            for (int i = 1; i <= total; ++i)
            {
                point = MyFunctions.CirclePoint(O, range, total, i);
                MyFunctions.DrawVector(spriteBatch, point, pointsize, color);
            }
        }
        public static void DrawRectangle(SpriteBatch spriteBatch, Rectangle rec, Color color)
        {
            spriteBatch.Draw(StaticTextures.Dot, rec, color);
        }

        public static bool Intersects(Rectangle rectangle, Vector2 point)
        { //sprawdza, czy punkt znajduje się wewnątrz prostokątu
            if ((int)point.X < rectangle.Left)
                return false;
            if ((int)point.X > rectangle.Left + rectangle.Width)
                return false;

            if ((int)point.Y < rectangle.Top)
                return false;
            if ((int)point.Y > rectangle.Top + rectangle.Height)
                return false;

            return true;
        }

        public static float NextFloat(Random random, float range)
        {
            //losowa liczba z zakresu (-range do range)
            double val = random.NextDouble(); // range 0.0 to 1.0
            val -= 0.5; // expected range now -0.5 to +0.5
            val *= 2; // expected range now -1.0 to +1.0
            return range * (float)val;
        }
        public static float Angle(Vector2 from, Vector2 to)
        {
            float ret = MathHelper.ToDegrees((float)Math.Atan2(from.X - to.X, to.Y - from.Y)) + 180;
            if( ret <= 0 )
                ret = 360 - ret;

            return ret;
        }
        public static Vector2 GetMousePosition()
        {
            MouseState kot = Mouse.GetState();
            return new Vector2(kot.X, kot.Y);
        }
        public static Vector2 CirclePoint(Vector2 O, float range, int total, int index)
        {
            if (0 >= index || index > total || range <= 0)
                return Vector2.Zero;    //błędne dane

            Vector2 result = new Vector2();
            result.X = (float)(O.X + range * Math.Cos((6.2832 * (double)index) / total));
            result.Y = (float)(O.Y + range * Math.Sin((6.2832 * (double)index) / total));
            return result;
        }
        public static Vector2 ToGrid(Vector2 mouse)
        {
            //zwraca środkowy punkt siatki

            if (mouse.X < 0 || mouse.Y < 0)
                return default(Vector2);
            if (mouse.X > 620 || mouse.Y > 480)
                return default(Vector2);

            int marginX = StaticConsts.MarginX;
            int marginY = StaticConsts.MarginY;

            double X, Y;
            float retX, retY;
            retX = retY = 0f;

            //ucinanie marginesów

            if (mouse.X <= marginX)
                retX = marginX + StaticConsts.GridSize / 2;
            if (mouse.Y <= marginY)
                retY = marginY + StaticConsts.GridSize / 2;
            if( mouse.X >= StaticConsts.StageWidth - 2 * marginX)
                retX = StaticConsts.StageWidth - marginX - StaticConsts.GridSize / 2;
            if( mouse.Y >= StaticConsts.StageHeight - 2 * marginY )
                retY = StaticConsts.StageHeight - marginY - StaticConsts.GridSize / 2;

            if (retX == 0)
            {
                mouse.X -= marginX;
                X = Math.Round( ( double )( ( mouse.X + StaticConsts.GridSize / 2 ) / StaticConsts.GridSize ), MidpointRounding.ToEven );
                retX = marginX + ( ( float )X - 1 ) * StaticConsts.GridSize + StaticConsts.GridSize / 2;
            }

            if (retY == 0)
            {
                mouse.Y -= marginY;
                Y = Math.Round( ( double )( ( mouse.Y + StaticConsts.GridSize / 2 ) / StaticConsts.GridSize ), MidpointRounding.ToEven );
                retY = marginY + ( ( float )Y - 1 ) * StaticConsts.GridSize + StaticConsts.GridSize / 2;
            }

            return new Vector2(retX, retY);
        }
        public static Vector2 ToGridFromMouse()
        {
            MouseState kot = Mouse.GetState();
            return ToGrid(new Vector2(kot.X, kot.Y));
        }
        public static Rectangle GetBarSize( Vector2 pos, Vector2 size, float value, float maxvalue )
        {
            float width = value / maxvalue * size.X;
            return new Rectangle( ( int )pos.X, ( int )pos.Y, (int)width, ( int )size.Y );
        }
        public static List<CWave> CopyWaves( List<CWave> waves )
        {
            List<CWave> p = new List<CWave>();
            foreach( CWave elem in waves )
                p.Add( new CWave(elem) );
            return p;
        }
    }

    public class CStage //klasa reprezentująca całą mapę, zawiera wszystko
    {
        // ZMIENNE
        //
        //obiekty w grze
        public List<CEnemy> Enemies;    //lista wszystkich przeciwników
        public List<CTower> Towers; //lista wszystkich wieżyczek
        public List<CBullet> Bullets;   //lista wszystkich pocisków
        public List<CPopUp> Popups;   //lista wszystkich pop-up'ów
        public List<CSprite> Details;   //lista wszystkich efektów (np. wybuchy)

        public List<Rectangle> WayRectangle;    //prostokąty między punktami Way
        private List<Vector2> privWay;   //lista punktów budujących drogę mapy
        public CHelper Helper;  //obsługa samouczka
        public CInStageMenu InGameMenu; //menu w trakcie gry
        public CNavigation Menu;    //obsługa przycisków
        public CWaver Waver;    //obsługa fal przeciwników
        public Random Random;   //niech będzie jeden obiekt Random w całej grze - tutaj
        public int GameState;   //stan gry, 0=trwa gra, -1=przegrana, 1=wygrana

        private bool InGameMenuStart;    //włącz InGameMenu
        public bool blockclick; //blokuj przycisk, by wyróżnić kliknięcie od przytrzymania

        public CTower ClickedTower; //wieżyczka, która jest w tej chwili aktywna
        public List<Vector2> Way { get { return privWay; } }
        public List<string> Log;    //komunikaty

        //właściwości mapy
        public Texture2D Background;    //obrazek tła mapy

        //dane o graczu
        public int Money;   //stan portfela gracza
        public int Basehealth;  //ilość życia bazy graczy

        //inne
        public bool IsStart { get { return Waver.IsStart; } }
        public int CurrentWay { get { return Waver.CurrentWave; } }
        public int TotalWays { get { return Waver.TotalWaves; } }

        //koniec gry
        CButton back_to_menu, quit_the_game;
        private bool quit_now;

        // KONSTRUKTORY
        //
        private CStage()
        {
            this.Enemies = new List<CEnemy>( 50 );
            this.Towers = new List<CTower>( 50 );
            this.Bullets = new List<CBullet>( 200 );
            this.privWay = new List<Vector2>( 20 );
            this.Popups = new List<CPopUp>( 30 );
            this.Details = new List<CSprite>( 30 );

            this.WayRectangle = new List<Rectangle>( 20 );
            this.Log = new List<string>( 20 );
            this.InGameMenu = new CInStageMenu( this );
            this.Menu = new CNavigation( this );
            this.Waver = new CWaver( this );
            this.Random = new Random();
            this.Helper = null; //to chyba zbędne, ale nie mam pewności

            this.InGameMenuStart = false;

            this.Money = 250;
            this.Basehealth = 10;
            this.GameState = 0; //stan gry //0=gra// 1=wygrana//-1=przegrana
            this.quit_now = false;
            this.blockclick = true;

            this.back_to_menu = new CButton( StaticVectors.Panels.back_to_menu, StaticTextures.Buttons.back_to_menu, StaticTextures.Buttons.back_to_menu_f, StaticTextures.Buttons.back_to_menu );
            this.quit_the_game = new CButton( StaticVectors.Panels.quit_the_game, StaticTextures.Buttons.quit_the_game, StaticTextures.Buttons.quit_the_game_f, StaticTextures.Buttons.quit_the_game );
        }
        public CStage(Texture2D background)
            : this()
        {
            this.Background = background;
        }
        public CStage( CStage stage )
            :this( stage.Background)
        {
            this.WayRectangle = new List<Rectangle>(stage.WayRectangle);
            this.privWay = new List<Vector2>(stage.privWay);
            this.Waver.Initialize( stage.Waver.waves );
        }

        // METODY
        //
        //JEDNORAZOWE
        public void AddWay(List<Vector2> way)
        {   //funkcja dodaje drogę dla przeciwników
            //i tworzy prostokąty między punktami listy Way
            //by móc sprawdzać, gdzie można zbudować wieżyczkę
            privWay = way;
            int i = 0;
            do
            {
                const int halfGrid = StaticConsts.GridSize / 2;
                Vector2 cur = privWay[i];
                Vector2 next = privWay[i + 1];

                if (cur.X == next.X) //2 punkty są na tej samej osi X
                {
                    if (cur.Y < next.Y)
                    {
                        WayRectangle.Add(new Rectangle((int)cur.X - halfGrid, (int)cur.Y - halfGrid, StaticConsts.GridSize, (int)(next.Y - cur.Y))); //w dół
                    }
                    else
                    {
                        WayRectangle.Add(new Rectangle((int)next.X - halfGrid, (int)next.Y + halfGrid, StaticConsts.GridSize, (int)(cur.Y - next.Y))); //w górę
                    }
                }
                if (cur.Y == next.Y) //2 punkty są na tej samej osi Y
                {
                    if (cur.X < next.X)
                    {
                        WayRectangle.Add(new Rectangle((int)cur.X - halfGrid, (int)cur.Y - halfGrid, (int)(next.X - cur.X), StaticConsts.GridSize)); //w dół
                    }
                    else
                    {
                        WayRectangle.Add(new Rectangle((int)next.X + halfGrid, (int)next.Y - halfGrid, (int)(cur.X - next.X), StaticConsts.GridSize)); //w górę
                    }
                }


            } while (++i + 1 < privWay.Count());

        }
        public void EndLevel()
        {
            if( this.Basehealth <= 0 )
                GameState = -1;
            else
                GameState = 1;
        }
        public void BackToMenu()
        {
            this.InGameMenuStart = true;
        }
        public void StartTutorial()
        {
            Helper = new CHelper( this );
        }
        //
        //CYKLICZNE
        public int Update(GameTime gameTime)
        {
            if( this.InGameMenuStart )
            {
                this.InGameMenu.Start( gameTime );
                this.InGameMenuStart = false;
            }

            if( this.quit_now )
            {
                this.quit_now = false;
                return 1;
            }

            if( this.InGameMenu.On )    //ktoś włączył pauzę - InGameMenu
            {
                int ret = InGameMenu.Update( gameTime );
                if( !blockclick )
                {
                    switch( ret )//0=nic//1=wróc do gry//2=wróć do menu//-1=wyjdź z gry
                    {
                        case 1:
                            {   //jeśli wracamy do gry, trzeba opóźnić wieżyczki, by nie strzelały bez opóźnienia
                                double offset = InGameMenu.End( gameTime );
                                foreach( CTower elem in this.Towers )
                                    elem.AddTimeOffset( offset );
                                break;
                            }
                        case 2:
                            {
                                InGameMenu.End( gameTime );
                                return 1;
                            }
                        case -1:
                            {
                                InGameMenu.End( gameTime );
                                return -1;
                            }
                    }
                }
                
            }
            else
            {
                if( Helper != null )    //jeśli obiekt Helper istnieje, wywołaj update
                    if( Helper.Update( gameTime ) ) //jeśli update zwórci true (co oznacza koniec tutka)
                        Helper = null;              //to usuń obiekt

                if( this.GameState == 0 )
                {
                    this.Check();
                    for( int i = 0; i < Enemies.Count(); ++i )
                        if( Enemies[i] != null )
                            Enemies[i].Update( gameTime );
                    for( int i = 0; i < Towers.Count(); ++i )
                        if( Towers[i] != null )
                            Towers[i].Update( gameTime );
                    for( int i = 0; i < Bullets.Count(); ++i )
                        if( Bullets[i] != null )
                            Bullets[i].Update( gameTime );
                    for( int i = 0; i < Popups.Count(); ++i )
                        if( Popups[i] != null )
                            Popups[i].Update( gameTime );

                    Waver.Update( gameTime );
                    Menu.Update( gameTime );
                }
                else
                {
                    switch( UpdateGameOver( gameTime ) )
                    {
                        case 1:
                            return 1;   //powrót do menu
                        case -1:
                            return -1;  //wyjście z gry
                    }
                }
            }
            if( this.blockclick && !( Mouse.GetState().LeftButton == ButtonState.Pressed ) )
                this.blockclick = false;
            if( !this.blockclick && Mouse.GetState().LeftButton == ButtonState.Pressed )
                this.blockclick = true;

            return 0;   //nic się nie stało
        }
        public void Check()
        {
            for (int i = 0; i < Enemies.Count(); ++i)
                if (Enemies[i] != null)
                    if (!Enemies[i].Check())
                        Enemies.RemoveAt(i);
            for (int i = 0; i < Towers.Count(); ++i)
                if (Towers[i] != null)
                    if (!Towers[i].Check())
                        Towers.RemoveAt(i);
            for (int i = 0; i < Bullets.Count(); ++i)
                if (Bullets[i] != null)
                    if (!Bullets[i].Check())
                        Bullets.RemoveAt(i);
            for (int i = 0; i < Popups.Count(); ++i)
                if (Popups[i] != null)
                    if (!Popups[i].Check())
                        Popups.RemoveAt(i);
            for (int i = 0; i < Details.Count(); ++i)
                if (Details[i] != null)
                    if (!Details[i].Check())
                        Details.RemoveAt(i);
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            DrawMap(spriteBatch);
            for (int i = 0; i < Towers.Count(); ++i)
                if (Towers[i] != null)
                    Towers[i].Draw(spriteBatch, gameTime);
            for (int i = 0; i < Enemies.Count(); ++i)
                if (Enemies[i] != null)
                    Enemies[i].Draw(spriteBatch, gameTime);
            for (int i = 0; i < Bullets.Count(); ++i)
                if (Bullets[i] != null)
                    Bullets[i].Draw(spriteBatch, gameTime);
            for (int i = 0; i < Details.Count(); ++i)
                if (Details[i] != null)
                    Details[i].Draw(spriteBatch, gameTime);

            Menu.Draw(spriteBatch, gameTime);

            for (int i = 0; i < Popups.Count(); ++i)
                if (Popups[i] != null)
                    Popups[i].Draw(spriteBatch, gameTime);

            if( this.GameState != 0 )   //koniec gry
                DrawGameOver( spriteBatch, gameTime );

            if( Helper != null )
                Helper.Draw( spriteBatch );

            if( this.InGameMenu.On )    //ktoś włączył pauzę - InGameMenu
            {
                this.InGameMenu.Draw( spriteBatch );
            }
        }
        private void DrawMap(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw( Background, Vector2.Zero, Color.White );

        }

        public int UpdateGameOver( GameTime gameTime )
            //0=nic//1=powrót do menu//-1=wyjście// z gry
        {
            if( back_to_menu.Update(gameTime) )
                return 1;

            if( quit_the_game.Update( gameTime ) )
                return -1;

            return 0;
        }
        public void DrawGameOver( SpriteBatch spriteBatch, GameTime gameTime )
        {
            spriteBatch.Draw( StaticTextures.Dot, spriteBatch.GraphicsDevice.Viewport.Bounds, new Color( 0, 0, 0, 200 ) );
            if( GameState == 1 )
                spriteBatch.Draw( StaticTextures.win, StaticVectors.Panels.Win, Color.White );
            else
                spriteBatch.Draw( StaticTextures.defeat, StaticVectors.Panels.Defeat, Color.White );
            back_to_menu.Draw( spriteBatch );
            quit_the_game.Draw( spriteBatch );
        }
        //
        //INNE
        public void StartWay()
        {
            Waver.Start();
        }
        public void BuildTower(CTower tower, Vector2 position)
        {
            Money -= tower.m_cost;
            Towers.Add(tower.Create( position, this));
        }
        public bool ValidTowerPlace(Vector2 GridPosition)
        {
            //nie znajduje się na drodze (ani wewnątrz żadnego dodatkowego prostokątu)
            foreach (Rectangle rec in WayRectangle)
            {
                if (MyFunctions.Intersects(rec, GridPosition))
                    return false;
            }
            //nie ma tu jeszcze wieżyczki
            foreach (CTower tow in Towers)
            {
                if (tow.m_spr_tower.m_position == GridPosition)
                    return false;
            }
            //nie nachodzi na przyciski startu i powrotu do menu
            if( MyFunctions.Intersects( new Rectangle( 507, 5, 110, 77 ), GridPosition ) )
                return false;

            return true;
        }
        public List<CEnemy> GetEnemy(Vector2 where, float range)
        {
            List<CEnemy> result = Enemies.FindAll(
                delegate(CEnemy enemy)
                {
                    if (Vector2.Distance(where, enemy.Position) <= range)
                        return true;
                    else
                        return false;
                });
            if (result != null)
                return result;
            else
                return null;
        }
        public CTower GetTower(Vector2 position)
        {
            foreach (CTower tow in Towers)
            { if (tow.Position == position) return tow; }
            return default(CTower);
        }

        private static bool checkrange(CEnemy enemy, Vector2 where, float range)
        {
            if (Vector2.Distance(where, enemy.Position) <= range)
                return true;
            return false;
        }
    }

    public class CInStageMenu   //klasa obsługująca menu 
    {
        private CStage m_stage; //przyda się do kontaktu z mapką
        private CButton butBackToMenu, butBackToGame, butExit;

        public bool On;    //czy menu jest teraz uruchomione?
        public double PausedStart;  //w której sekundzie włączono menu
        private bool BlockClick;

        private CInStageMenu()
        {
            this.On = false;
            this.BlockClick = true;
            this.PausedStart = 0d;

            this.butBackToGame = new CButton( StaticVectors.Panels.InGameMenu.BackToGame, StaticTextures.Buttons.igm_BackToGame, StaticTextures.Buttons.igm_BackToGame_f, StaticTextures.Buttons.igm_BackToGame );
            this.butBackToMenu = new CButton( StaticVectors.Panels.InGameMenu.BackToMenu, StaticTextures.Buttons.igm_BackToMenu, StaticTextures.Buttons.igm_BackToMenu_f, StaticTextures.Buttons.igm_BackToMenu );
            this.butExit = new CButton( StaticVectors.Panels.InGameMenu.Exit, StaticTextures.Buttons.igm_Exit, StaticTextures.Buttons.igm_Exit_f, StaticTextures.Buttons.igm_Exit );
        }

        public CInStageMenu( CStage stage )
            :this()
        {
            this.m_stage = stage;
        }

        public int Update( GameTime gameTime )
        {   //0=nic//1=wróc do gry//2=wróć do menu//-1=wyjdź z gry
            if( !On )
                return 0;

            if( butBackToGame.Update( gameTime ) && !BlockClick )
                return 1;
            if( butBackToMenu.Update( gameTime ) && !BlockClick )
                return 2;
            if( butExit.Update( gameTime ) && !BlockClick )
                return -1;

            if( BlockClick && !( Mouse.GetState().LeftButton == ButtonState.Pressed ) )
                BlockClick = false;

            return 0;
        }
        public void Draw( SpriteBatch spriteBatch )
        {
            if( !On )
                return;
            spriteBatch.Draw( StaticTextures.Dot, new Rectangle( 0, 0, 800, 480 ), new Color( 0, 0, 0, 0.8f ) );    //zaciemnienie
            spriteBatch.Draw( StaticTextures.Panels.InGameMenu, StaticVectors.Panels.InGameMenu.background, Color.White );  //tło
            butBackToGame.Draw( spriteBatch );
            butBackToMenu.Draw( spriteBatch );
            butExit.Draw( spriteBatch );
        }

        public void Start(GameTime gameTime)
        {
            this.On = true;
            this.PausedStart = gameTime.TotalGameTime.TotalSeconds;
        }
        public double End(GameTime gameTime)
        {   //zwraca czas, ile trwało pauzowanie u zatrzymuje modł
            this.On = false;
            double ret = ( gameTime.TotalGameTime.TotalSeconds - this.PausedStart );
            this.PausedStart = 0d;
            return ret;
        }


    }
    public class CWaver //klasa obsługująca wypuszczanie fal przeciwników
    {
        private CStage stage;
        private List<CWave> Waves;
        private int CurWave;
        private bool start;
        private double LastTime;

        public int TotalWaves;
        public int CurrentWave { get { return CurWave; } }
        public bool IsStart { get { return start; } }
        public List<CWave> waves { get { return Waves; } }

        public CWaver(CStage stage)
        {
            this.stage = stage;
            this.start = false;
            this.LastTime = 0;
            this.TotalWaves = 0;
            this.CurWave = -1;
            this.Waves = new List<CWave>();
        }
        public void Initialize(List<CWave> waves)
        {
            //this.Waves = new List<CWave>( waves );
            this.Waves = MyFunctions.CopyWaves( waves );
            this.TotalWaves = waves.Count();
        }
        public bool Update(GameTime gameTime)
        {
            if (start && gameTime.TotalGameTime.TotalMilliseconds >= LastTime + StaticConsts.Enemies.SpawnRate)
            {
                Spawn();
                LastTime = gameTime.TotalGameTime.TotalMilliseconds;
            }

            return start;
        }
        public void Start()
        {
            ++this.CurWave;
            this.start = true;
        }
        public void End()
        {
            this.start = false;
            //++this.CurWave;
        }
        private void Spawn()
        {
            CEnemy enemy = Waves[CurWave].GetEnemy();
            if (enemy == null)
            {
                End();
                return;
            }
            stage.Enemies.Add( enemy.Create(stage));
            return;
        }

    }
    public class CNavigation //klasa obsługująca przyciski i informacje
    {
        private CStage m_stage;
        private List<string> m_strings;

        private List<MenuTowerItem> MenuTowerItems;
        public CBuilder Builder;
        public CUpgrader Upgrader;
        private CButton ButStart;
        private CButton ButMenu;

        private MenuTowerItem? FocusedItem;

        public void UnClick() { Upgrader.UnClick(); }
        public CTower clicked_tower { get { return Upgrader.selected; } }

        //skróty
        private int Cash { get { return m_stage.Money; } }

        private void Initialize()
        {
            //wieżyczki
            int q = 0;
            MenuTowerItems.Add( new MenuTowerItem( StaticTowers.Gun1.CopyModel(),
                new CButton( StaticVectors.RighMenu.Turret[q], StaticTextures.Buttons.BuyTower, StaticTextures.Buttons.BuyTower_f, StaticTextures.Buttons.BuyTower_l ), q++ ) );
            MenuTowerItems.Add( new MenuTowerItem( StaticTowers.Rocket1.CopyModel(),
                new CButton( StaticVectors.RighMenu.Turret[q], StaticTextures.Buttons.BuyTower, StaticTextures.Buttons.BuyTower_f, StaticTextures.Buttons.BuyTower_l ), q++ ) );
            MenuTowerItems.Add( new MenuTowerItem( StaticTowers.Flamethrower.CopyModel(),
                new CButton( StaticVectors.RighMenu.Turret[q], StaticTextures.Buttons.BuyTower, StaticTextures.Buttons.BuyTower_f, StaticTextures.Buttons.BuyTower_l ), q++ ) );
            MenuTowerItems.Add( new MenuTowerItem( StaticTowers.Thunder.CopyModel(),
                new CButton( StaticVectors.RighMenu.Turret[q], StaticTextures.Buttons.BuyTower, StaticTextures.Buttons.BuyTower_f, StaticTextures.Buttons.BuyTower_l ), q++ ) );
            MenuTowerItems.Add( new MenuTowerItem( StaticTowers.Slower.CopyModel(),
                new CButton( StaticVectors.RighMenu.Turret[q], StaticTextures.Buttons.BuyTower, StaticTextures.Buttons.BuyTower_f, StaticTextures.Buttons.BuyTower_l ), q++ ) );
            MenuTowerItems.Add( new MenuTowerItem( StaticTowers.Lasser.CopyModel(),
                new CButton( StaticVectors.RighMenu.Turret[q], StaticTextures.Buttons.BuyTower, StaticTextures.Buttons.BuyTower_f, StaticTextures.Buttons.BuyTower_l ), q++ ) );
            //for (; q <= StaticVectors.RighMenu.Image.Count() - 1; ++q)
            //    MenuTowerItems.Add(new MenuTowerItem(new CTower(StaticTowers.Rocket1), new CButton(StaticVectors.RighMenu.Turret[q], StaticTextures.Buttons.Button00_Normal, StaticTextures.Buttons.Button00_Focus, StaticTextures.Buttons.Button00_Lock), q));
            ButStart = new CButton(StaticVectors.Start, StaticTextures.Buttons.Start, StaticTextures.Buttons.Start_f, StaticTextures.Buttons.Start_l);
        }

        public CNavigation(CStage stage)
        {
            this.m_stage = stage;
            this.m_strings = new List<string>();

            this.MenuTowerItems = new List<MenuTowerItem>();

            this.Builder = new CBuilder(m_stage);
            this.Upgrader = new CUpgrader(m_stage);
            this.ButMenu = new CButton( StaticVectors.BackToMenu, StaticTextures.Buttons.Menu, StaticTextures.Buttons.Menu_f, StaticTextures.Buttons.Menu );

            this.FocusedItem = null;

            this.Initialize();
        }

        public void Update(GameTime gameTime)
        {
            UpdateTowerMenu(gameTime);
            Builder.Update(gameTime);   //klasa sama sprawdza swój stan w Update()
            Upgrader.Update(gameTime);
            UpdateStart( gameTime );

                //leci ostatnia fala i nie ma przeciwników na mapie i przeciwnicy już się nie pojawiają lub skończyły się życia
            if( (m_stage.CurrentWay == m_stage.TotalWays - 1 && m_stage.Enemies.Count <= 0 && !m_stage.IsStart) || m_stage.Basehealth <= 0 )
            {
                m_stage.EndLevel();
            }

                //naciśnięto przycisk powrotu do menu
            if( ButMenu.Update( gameTime ) && !m_stage.blockclick)
            {
                m_stage.BackToMenu();
            }
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            DrawPanels( spriteBatch, gameTime );
            DrawTowerMenu( spriteBatch, gameTime );
            DrawStart( spriteBatch, gameTime );
            DrawInfo( spriteBatch );
            ButMenu.Draw( spriteBatch );

            if( FocusedItem != null )   //jeśli jest zfocusowana wieżyczka, wyświetl info o niej
            {
                DrawInfobox( spriteBatch, FocusedItem.Value.tower );
            }
            else
            {
                if( Upgrader.selected != null ) //jeśli nie, a inna wieżyczka chce być wyświetlona - zrób to
                    DrawInfobox( spriteBatch, Upgrader.selected );
            }

            Builder.Draw( spriteBatch, gameTime );   //klasa sama sprawdza swój stan w Draw()
            Upgrader.Draw( spriteBatch, gameTime );
        }

        private void DrawPanels(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(StaticTextures.Panels.MainRight, StaticVectors.Panels.Right, Color.White);
        }
        private void DrawStart(SpriteBatch spriteBatch, GameTime gameTime)
        {
            ButStart.Draw(spriteBatch);
        }
        private void DrawTowerMenu(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (int i = 0; i < MenuTowerItems.Count(); ++i)
            {
                string name = MenuTowerItems[i].tower.m_name;
                int cost = MenuTowerItems[i].tower.m_cost;
                string str = name + "\n" + cost + '$';
                Color color = cost <= m_stage.Money ? Color.Yellow : Color.Red;

                MenuTowerItems[i].button.Draw(spriteBatch);   //guzik
                MenuTowerItems[i].tower.m_spr_stage.Draw(spriteBatch, gameTime, StaticVectors.RighMenu.Image[i]); //rysowanie podstawy wieżyczki
                MenuTowerItems[i].tower.m_spr_tower.Draw(spriteBatch, gameTime, StaticVectors.RighMenu.Image[i]); //rysowanie wieżyczki
                spriteBatch.DrawString(StaticFonts.TowerInfo, str, StaticVectors.RighMenu.Text[i], color); //tekst
            }
        }
        private void DrawInfo(SpriteBatch spriteBatch)
        {
            //int level = m_stage.CurrentWay + 1 <= m_stage.TotalWays ? m_stage.CurrentWay + 1 : m_stage.TotalWays;
            int level = m_stage.CurrentWay + 1;

            spriteBatch.DrawString(StaticFonts.Info, m_stage.Basehealth.ToString(), StaticVectors.Texts.Health, Color.Red);
            spriteBatch.DrawString(StaticFonts.Info, Cash.ToString() + '$', StaticVectors.Texts.Cash, Color.LightGreen);
            spriteBatch.DrawString(StaticFonts.Info, level.ToString() + '/' + m_stage.TotalWays, StaticVectors.Texts.Level, Color.LightGreen);
        }
        private void DrawInfobox( SpriteBatch spriteBatch, CTower tower )
        {
            //można ulepszyć
            if( tower.m_upgrade != null )
            {
                //tło
                spriteBatch.Draw( StaticTextures.Panels.InfoBoxDual, StaticVectors.Panels.InfoBox.position, Color.White );
                //obrazki
                spriteBatch.Draw( tower.m_spr_tower.Texture, new Rectangle( ( int )StaticVectors.Panels.InfoBox.img1.X, ( int )StaticVectors.Panels.InfoBox.img1.Y, StaticConsts.GridSize - 2, StaticConsts.GridSize - 2 ), new Rectangle( 0, 0, StaticConsts.GridSize - 2, StaticConsts.GridSize - 2 ), Color.White );
                spriteBatch.Draw( tower.m_upgrade.m_spr_tower.Texture, new Rectangle( ( int )StaticVectors.Panels.InfoBox.img2.X, ( int )StaticVectors.Panels.InfoBox.img2.Y, StaticConsts.GridSize - 2, StaticConsts.GridSize - 2 ), new Rectangle( 0, 0, StaticConsts.GridSize - 2, StaticConsts.GridSize - 2 ), Color.White );

                //staty
                //rysowanie tła pod bary
                int q = 0;
                spriteBatch.Draw( StaticTextures.Dot, new Rectangle( ( int )StaticVectors.Panels.InfoBox.bars1[q].X, ( int )StaticVectors.Panels.InfoBox.bars1[q].Y, StaticConsts.Infobox.bar_width_dual, StaticConsts.Infobox.bar_height ), StaticConsts.Infobox.bar_power2 );
                spriteBatch.Draw( StaticTextures.Dot, new Rectangle( ( int )StaticVectors.Panels.InfoBox.bars2[q].X, ( int )StaticVectors.Panels.InfoBox.bars2[q].Y, StaticConsts.Infobox.bar_width_dual, StaticConsts.Infobox.bar_height ), StaticConsts.Infobox.bar_power2 );
                ++q;
                spriteBatch.Draw( StaticTextures.Dot, new Rectangle( ( int )StaticVectors.Panels.InfoBox.bars1[q].X, ( int )StaticVectors.Panels.InfoBox.bars1[q].Y, StaticConsts.Infobox.bar_width_dual, StaticConsts.Infobox.bar_height ), StaticConsts.Infobox.bar_range2 );
                spriteBatch.Draw( StaticTextures.Dot, new Rectangle( ( int )StaticVectors.Panels.InfoBox.bars2[q].X, ( int )StaticVectors.Panels.InfoBox.bars2[q].Y, StaticConsts.Infobox.bar_width_dual, StaticConsts.Infobox.bar_height ), StaticConsts.Infobox.bar_range2 );
                ++q;
                spriteBatch.Draw( StaticTextures.Dot, new Rectangle( ( int )StaticVectors.Panels.InfoBox.bars1[q].X, ( int )StaticVectors.Panels.InfoBox.bars1[q].Y, StaticConsts.Infobox.bar_width_dual, StaticConsts.Infobox.bar_height ), StaticConsts.Infobox.bar_rate2 );
                spriteBatch.Draw( StaticTextures.Dot, new Rectangle( ( int )StaticVectors.Panels.InfoBox.bars2[q].X, ( int )StaticVectors.Panels.InfoBox.bars2[q].Y, StaticConsts.Infobox.bar_width_dual, StaticConsts.Infobox.bar_height ), StaticConsts.Infobox.bar_rate2 );

                //wartości barów
                Vector2 bar_size = new Vector2( StaticConsts.Infobox.bar_width_dual, StaticConsts.Infobox.bar_height );
                q = 0;
                spriteBatch.Draw( StaticTextures.Dot, MyFunctions.GetBarSize( StaticVectors.Panels.InfoBox.bars1[q], bar_size, tower.Damage, StaticConsts.Infobox.bar_power_max ), StaticConsts.Infobox.bar_power1 );
                spriteBatch.Draw( StaticTextures.Dot, MyFunctions.GetBarSize( StaticVectors.Panels.InfoBox.bars2[q], bar_size, tower.m_upgrade.Damage, StaticConsts.Infobox.bar_power_max ), StaticConsts.Infobox.bar_power1 );
                ++q;
                spriteBatch.Draw( StaticTextures.Dot, MyFunctions.GetBarSize( StaticVectors.Panels.InfoBox.bars1[q], bar_size, tower.Range, StaticConsts.Infobox.bar_range_max ), StaticConsts.Infobox.bar_range1 );
                spriteBatch.Draw( StaticTextures.Dot, MyFunctions.GetBarSize( StaticVectors.Panels.InfoBox.bars2[q], bar_size, tower.m_upgrade.Range, StaticConsts.Infobox.bar_range_max ), StaticConsts.Infobox.bar_range1 );
                ++q;
                Rectangle rec = MyFunctions.GetBarSize( StaticVectors.Panels.InfoBox.bars2[q], bar_size, tower.Rate, StaticConsts.Infobox.bar_rate_max );
                int realwidth = StaticConsts.Infobox.bar_width_dual - rec.Width;
                spriteBatch.Draw( StaticTextures.Dot, new Rectangle( ( int )StaticVectors.Panels.InfoBox.bars1[q].X, ( int )StaticVectors.Panels.InfoBox.bars1[q].Y, realwidth, StaticConsts.Infobox.bar_height ), StaticConsts.Infobox.bar_rate1 );
                rec = MyFunctions.GetBarSize( StaticVectors.Panels.InfoBox.bars2[q], bar_size, tower.m_upgrade.Rate, StaticConsts.Infobox.bar_rate_max );
                realwidth = StaticConsts.Infobox.bar_width_dual - rec.Width;
                spriteBatch.Draw( StaticTextures.Dot, new Rectangle( ( int )StaticVectors.Panels.InfoBox.bars2[q].X, ( int )StaticVectors.Panels.InfoBox.bars2[q].Y, realwidth, StaticConsts.Infobox.bar_height ), StaticConsts.Infobox.bar_rate1 );
            }
            else
            {   //wieżyczka bez dalszych ulepszeń
                //tło
                spriteBatch.Draw( StaticTextures.Panels.InfoBoxMono, StaticVectors.Panels.InfoBox.position, Color.White );
                //obrazki
                spriteBatch.Draw( tower.m_spr_tower.Texture, new Rectangle( ( int )StaticVectors.Panels.InfoBox.img0.X, ( int )StaticVectors.Panels.InfoBox.img0.Y, StaticConsts.GridSize - 2, StaticConsts.GridSize - 2 ), new Rectangle( 0, 0, StaticConsts.GridSize - 2, StaticConsts.GridSize - 2 ), Color.White );

                //staty
                //rysowanie tła pod bary
                int q = 0;
                spriteBatch.Draw( StaticTextures.Dot, new Rectangle( ( int )StaticVectors.Panels.InfoBox.bars1[q].X, ( int )StaticVectors.Panels.InfoBox.bars1[q].Y, StaticConsts.Infobox.bar_width_mono, StaticConsts.Infobox.bar_height ), StaticConsts.Infobox.bar_power2 );
                ++q;
                spriteBatch.Draw( StaticTextures.Dot, new Rectangle( ( int )StaticVectors.Panels.InfoBox.bars1[q].X, ( int )StaticVectors.Panels.InfoBox.bars1[q].Y, StaticConsts.Infobox.bar_width_mono, StaticConsts.Infobox.bar_height ), StaticConsts.Infobox.bar_range2 );
                ++q;
                spriteBatch.Draw( StaticTextures.Dot, new Rectangle( ( int )StaticVectors.Panels.InfoBox.bars1[q].X, ( int )StaticVectors.Panels.InfoBox.bars1[q].Y, StaticConsts.Infobox.bar_width_mono, StaticConsts.Infobox.bar_height ), StaticConsts.Infobox.bar_rate2 );

                //wartości barów
                Vector2 bar_size = new Vector2( StaticConsts.Infobox.bar_width_mono, StaticConsts.Infobox.bar_height );
                q = 0;
                spriteBatch.Draw( StaticTextures.Dot, MyFunctions.GetBarSize( StaticVectors.Panels.InfoBox.bars1[q], bar_size, tower.Damage, StaticConsts.Infobox.bar_power_max ), StaticConsts.Infobox.bar_power1 );
                ++q;
                spriteBatch.Draw( StaticTextures.Dot, MyFunctions.GetBarSize( StaticVectors.Panels.InfoBox.bars1[q], bar_size, tower.Range, StaticConsts.Infobox.bar_range_max ), StaticConsts.Infobox.bar_range1 );
                ++q;
                Rectangle rec = MyFunctions.GetBarSize( StaticVectors.Panels.InfoBox.bars1[q], bar_size, tower.Rate, StaticConsts.Infobox.bar_rate_max );
                int realwidth = StaticConsts.Infobox.bar_width_dual - rec.Width;
                spriteBatch.Draw( StaticTextures.Dot, new Rectangle( ( int )StaticVectors.Panels.InfoBox.bars1[q].X, ( int )StaticVectors.Panels.InfoBox.bars1[q].Y, realwidth, StaticConsts.Infobox.bar_height ), StaticConsts.Infobox.bar_rate1 );

            }

            //wyświetlanie opisu jest niezależne od układu infoboxa (mono/dual)
            //spriteBatch.DrawString( StaticFonts.Description, tower.Description, StaticVectors.Panels.InfoBox.descriptoin, Color.White );
            spriteBatch.DrawString( StaticFonts.Description, tower.Description, StaticVectors.Panels.InfoBox.descriptoin, Color.White );
        }
        private void UpdateStart(GameTime gameTime)  //0=jesli wszystko jest ok//1=koniec leveli
        {
            if( m_stage.CurrentWay == m_stage.TotalWays - 1 && ButStart.m_state != MyButtonState.Lock )
            {
                ButStart.m_state = MyButtonState.Lock;
            }

            if (m_stage.IsStart && ButStart.m_state != MyButtonState.Lock)
                ButStart.m_state = MyButtonState.Lock;
            if (!m_stage.IsStart && ButStart.m_state == MyButtonState.Lock && m_stage.CurrentWay != m_stage.TotalWays - 1)
                ButStart.m_state = MyButtonState.Normal;

            if (ButStart.Update(gameTime) && !m_stage.blockclick)
                m_stage.StartWay();
        }
        private void UpdateTowerMenu( GameTime gameTime )
        {
            MenuTowerItem? item = null;
            FocusedItem = null;
            for( int i = 0; i < MenuTowerItems.Count(); ++i )
            {
                //aktualizacja stanu butona (lock/normal)
                if( m_stage.Money >= MenuTowerItems[i].tower.m_cost )
                {
                    if( MenuTowerItems[i].button.m_state == MyButtonState.Lock )
                        MenuTowerItems[i].button.m_state = MyButtonState.Normal;
                }
                else
                {
                    if( MenuTowerItems[i].button.m_state != MyButtonState.Lock )
                        MenuTowerItems[i].button.m_state = MyButtonState.Lock;
                }

                //update'owanie przycisków
                if( MenuTowerItems[i].button.Update( gameTime ) )
                    item = MenuTowerItems[i];
                //sprawdzenie focusa
                if( MenuTowerItems[i].button.Focus )
                    FocusedItem = MenuTowerItems[i];
            }
            if( !item.Equals( null ) && Mouse.GetState().LeftButton == ButtonState.Pressed && !m_stage.blockclick )
            {
                UseTowerButton( item );
            }

        }
        private void UseTowerButton(MenuTowerItem? item)
        {
            Builder.Start( item.Value.tower.CopyModel() );
        }
    }
    public class CBuilder //klasa obłusugjąca budowanie nowej wieżyczki
    {
        private CStage m_stage;

        private CTower Tower;
        private bool Status;
        private Vector2 GridPosition;

        public bool GetStatus { get { return this.Status; } }

        public CBuilder(CStage stage)
        {
            this.Status = false;
            this.m_stage = stage;
        }

        public void Start(CTower Tower)
        {
            this.Tower = Tower.CopyModel();
            this.Tower.m_clicked = true;
            this.Status = true;
            m_stage.Menu.UnClick();
        }
        private void Stop(GameTime gameTime)
        {
            Tower = null;
            GridPosition = default(Vector2);
            Status = false;
        }

        public void Update(GameTime gameTime)
        {
            if (!Status)
                return;

            if (Mouse.GetState().RightButton == ButtonState.Pressed)
                Stop(gameTime);

            GridPosition = MyFunctions.ToGridFromMouse();
            if (GridPosition != default(Vector2) && Mouse.GetState().LeftButton == ButtonState.Pressed && !m_stage.blockclick)
                Build(gameTime);

        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (!Status)
                return;

            if (GridPosition == default(Vector2))
                return;
            Color color = m_stage.ValidTowerPlace(GridPosition) == true ? Color.White : Color.Red;


            DrawMyGrid(spriteBatch, gameTime);
            Tower.Color = color;
            Tower.Position = GridPosition;
            Tower.Draw(spriteBatch, gameTime);
        }
        protected void DrawMyGrid(SpriteBatch spriteBatch, GameTime gameTime)
        {
            const int ilosc = 8;
            Vector2[] myGridV = new Vector2[ilosc];
            Color[] myGridC = new Color[ilosc];

            //pozycje
            const int size = StaticConsts.GridSize;
            int q = 0;
            myGridV[q] = new Vector2(GridPosition.X, GridPosition.Y - size);
            myGridV[++q] = new Vector2(GridPosition.X, GridPosition.Y + size);
            myGridV[++q] = new Vector2(GridPosition.X + size, GridPosition.Y);
            myGridV[++q] = new Vector2(GridPosition.X - size, GridPosition.Y);
            myGridV[++q] = new Vector2(GridPosition.X + size, GridPosition.Y + size);
            myGridV[++q] = new Vector2(GridPosition.X - size, GridPosition.Y - size);
            myGridV[++q] = new Vector2(GridPosition.X + size, GridPosition.Y - size);
            myGridV[++q] = new Vector2(GridPosition.X - size, GridPosition.Y + size);

            Color ColorYes = new Color(100, 100, 100, 10);
            Color ColorNo = new Color(255, 0, 0, 80);

            for (int i = 0; i < ilosc; ++i)
            {
                if (m_stage.ValidTowerPlace(myGridV[i]))
                    myGridC[i] = ColorYes;
                else
                    myGridC[i] = ColorNo;

                MyFunctions.DrawVector(spriteBatch, myGridV[i], 10, myGridC[i]);
            }

        }
        private void Build(GameTime gameTime)
        {
            if (!m_stage.ValidTowerPlace(GridPosition))
                return;

            m_stage.BuildTower(Tower, GridPosition);
            m_stage.Popups.Add(new CStringOffset(StaticFonts.Popup, Tower.m_cost.ToString() + '$', Color.Red, MyFunctions.GetMousePosition(), StaticConsts.Popup.CashTime, StaticConsts.Popup.CashDistance));
            Stop(gameTime);
        }
    }
    public class CUpgrader //klasa obsługująca zaznaczanie i ulepszanie wieżyczek
    {
        private const double blocktime = 0.1;
        public CTower selected;
        public Vector2 position;

        private CStage m_stage;
        private MouseState mysz;

        private CButton but_upgrade;
        private CButton but_sell;

        public bool Clicked { get { if (selected != null) return true; else return false; } }

        public CUpgrader(CStage stage)
        {
            this.position = new Vector2();
            this.mysz = new MouseState();
            this.m_stage = stage;
            this.selected = null;

            this.but_upgrade = new CButton(StaticVectors.Upgrader.Upgrade, StaticTextures.Buttons.Upgrade, StaticTextures.Buttons.Upgrade_f, StaticTextures.Buttons.Upgrade_l);
            this.but_sell = new CButton( StaticVectors.Upgrader.Sell, StaticTextures.Buttons.Sell, StaticTextures.Buttons.Sell_f, StaticTextures.Buttons.Sell_l );
            this.but_upgrade.m_texture_special = StaticTextures.Buttons.Upgrade_s;
            this.but_upgrade.m_state = MyButtonState.Special;
            this.but_sell.m_state = MyButtonState.Special;
        }

        public void Update(GameTime gameTime)
        {

            if( but_upgrade.Update( gameTime ) && selected != null && selected.m_upgrade.m_cost <= m_stage.Money && !m_stage.blockclick )
                selected.Upgrade();
            if( but_sell.Update( gameTime ) && selected != null && !m_stage.blockclick )
                selected.Sell();

            if (Mouse.GetState().LeftButton == ButtonState.Pressed && !m_stage.blockclick)
            {
                CTower tow = m_stage.GetTower(MyFunctions.ToGridFromMouse());
                if (tow != null)
                    Click(tow, gameTime);
                else
                    if (selected != null)
                    {
                        UnClick();
                    }
            }
            if (selected != null)
            {
                if (selected.m_upgrade != null)
                {
                    if (but_upgrade.m_state != MyButtonState.Lock && m_stage.Money < selected.m_upgrade.m_cost)
                        but_upgrade.m_state = MyButtonState.Lock;
                    else
                        if ((but_upgrade.m_state == MyButtonState.Lock || but_upgrade.m_state == MyButtonState.Special) && m_stage.Money >= selected.m_upgrade.m_cost)
                            but_upgrade.m_state = MyButtonState.Normal;
                }
                else
                    but_upgrade.m_state = MyButtonState.Special;

                if (but_sell.m_state == MyButtonState.Special || but_sell.m_state == MyButtonState.Lock)
                    but_sell.m_state = MyButtonState.Normal;
            }
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (selected == null)
                return;
            but_upgrade.Draw(spriteBatch);  //same wiedzą, czy w ogóle mają się pojawić
            but_sell.Draw(spriteBatch);     // -/-

            if (but_upgrade.m_state != MyButtonState.Special)
            {   //wyświetlanie informacji o upgrade
                //Color color = but_upgrade.m_state == MyButtonState.Lock ? Color.Yellow : Color.Green;
                Color color = Color.Yellow;
                //selected.m_upgrade.m_spr_stage.Draw(spriteBatch, gameTime, StaticVectors.Upgrader.UpgradeImage);    //wieżyczka
                //selected.m_upgrade.m_spr_tower.Draw(spriteBatch, gameTime, StaticVectors.Upgrader.UpgradeImage);    ////
                spriteBatch.DrawString(StaticFonts.TowerInfo, selected.m_upgrade.m_cost.ToString() + '$', StaticVectors.Upgrader.UpgradeCost, color); //koszt
                //spriteBatch.DrawString(StaticFonts.TowerInfo, selected.m_upgrade.m_name, StaticVectors.Upgrader.UpgradeText, color);  //nazwa
            }
            if (but_sell.m_state != MyButtonState.Special)
            {
                spriteBatch.DrawString(StaticFonts.TowerInfo, selected.Value.ToString() + '$', StaticVectors.Upgrader.SellValue, Color.Red);  //koszt
            }
        }

        private void Click(CTower tower, GameTime gameTime)
        {
            if (selected != null)
                selected.m_clicked = false;
            selected = tower;
            selected.m_clicked = true;
            position = selected.Position;
        }
        public void UnClick()
        {
            if (!Clicked)
                return;
            selected.m_clicked = false;
            selected = null;
        }

    }
    public class CHelper    //klasa obsługujące wprowadzenie do gry
    {
        private CStage m_stage;//referencja na mapkę
        private bool m_end; //samouczek się skończył (nieodwracalnie)
        private int m_step; //który krok nauki teraz działa?
        private CTablet[] m_tablets;
        private double m_time;  //czas ostatniej zmiany kroku używany przy tabliczkach czasowych

        private CHelper()
        {
            this.m_step = 0;
            this.m_end = false;
            this.m_tablets = new CTablet[9];

            int q = 0;
            this.m_tablets[q++] = new CTablet( StaticTextures.Helper.Step1, new Vector2( 500, 170 ) );
            this.m_tablets[q++] = new CTablet( StaticTextures.Helper.Step2, new Vector2( 0, 0 ) );  //ta tabliczka krąży za kursorem
            this.m_tablets[q++] = new CTablet( StaticTextures.Helper.Step3, new Vector2( 0, 0 ) );  //ta tabliczka krąży za kursorem
            this.m_tablets[q++] = new CTablet( StaticTextures.Helper.Step4, new Vector2( 0, 0 ) );  //ta tabliczka będzie przykuta do pierwszej wieżyczki
            this.m_tablets[q++] = new CTablet( StaticTextures.Helper.Step5, new Vector2( 378, 82 ) );  
            this.m_tablets[q++] = new CTablet( StaticTextures.Helper.Step6, new Vector2( 478, 3 ) );  
            this.m_tablets[q++] = new CTablet( StaticTextures.Helper.Step7, new Vector2( 387, 43 ) );  
            this.m_tablets[q++] = new CTablet( StaticTextures.Helper.Step8, new Vector2( 387, 4 ) );
            this.m_tablets[q++] = new CTablet( StaticTextures.Helper.Step9, new Vector2( 2, 444 ) );
        }
        public CHelper( CStage stage )
            :this()
        {
            this.m_stage = stage;
        }

        private void Check( GameTime gameTime ) //sprawdzanie, czy nie pora zmienić krok samouczka
        {
            switch( m_step )
            {
                case 0: //nic się jeszcze nie stało
                    {
                        //Zaczęto budować wieżyczkę
                        if( m_stage.Menu.Builder.GetStatus )
                            ++m_step;
                        break;
                    }
                case 1: //zaczęto budować wieżyczkę
                    {
                        //tabliczka podąza za kursorem
                        m_tablets[m_step].Position = MyFunctions.GetMousePosition() + new Vector2( 0, 20 );

                        //już nie buduje się wieżyczki
                        if( !m_stage.Menu.Builder.GetStatus )
                        {
                            if( m_stage.Towers.Count > 0)
                            {
                                ++m_step;
                            }
                            else{
                                --m_step;
                            }
                        }
                        break;
                    }
                case 2: //pierwsza wieżyczka już jest zbudowana
                    {
                        //nie ma wieżyczek (zostały sprzedane), trzeba się cofnąć
                        if( m_stage.Towers.Count == 0 )
                        {
                            m_step = 0;
                        }

                        m_tablets[m_step].Position = MyFunctions.GetMousePosition() + new Vector2( -50, -20 );

                        //odznaczono wieżyczkę
                        if( !m_stage.Menu.Upgrader.Clicked )
                        {
                            ++m_step;
                            this.m_time = gameTime.TotalGameTime.TotalSeconds;
                            m_tablets[m_step].Position = m_stage.Towers.First().Position + new Vector2( 20, -20 );
                        }
                        break;
                    }
                case 3: //odznaczono pierwszą wieżyczkę
                    {
                        //nie ma wieżyczek (zostały sprzedane), trzeba się cofnąć
                        if( m_stage.Towers.Count == 0 )
                        {
                            m_step = 0;
                        }

                        //zaznaczono wieżyczkę
                        if( m_stage.Menu.Upgrader.Clicked && this.m_time + 2 < gameTime.TotalGameTime.TotalSeconds )
                        {
                            ++m_step;
                            this.m_time = gameTime.TotalGameTime.TotalSeconds;
                        }
                        break;
                    }
                case 4: //zaznaczono pierwsza wieżyczkę
                    {
                        //nie ma wieżyczek (zostały sprzedane), trzeba się cofnąć
                        if( m_stage.Towers.Count == 0 )
                        {
                            m_step = 0;
                        }

                        //minął odpowiedni czas
                        if( gameTime.TotalGameTime.TotalSeconds >= this.m_time + StaticConsts.Helper.info_time )
                        {
                            ++m_step;
                            this.m_time = gameTime.TotalGameTime.TotalSeconds;
                        }
                        break;
                    }
                case 5: //minął odpowiedni czas
                    {
                        //nie ma wieżyczek (zostały sprzedane), trzeba się cofnąć
                        if( m_stage.Towers.Count == 0 )
                        {
                            m_step = 0;
                        }

                        //minął odpowiedni czas
                        if( gameTime.TotalGameTime.TotalSeconds >= this.m_time + StaticConsts.Helper.info_time )
                        {
                            ++m_step;
                            this.m_time = gameTime.TotalGameTime.TotalSeconds;
                        }
                        break;
                    }
                case 6: //minął odpowiedni czas
                    {
                        //nie ma wieżyczek (zostały sprzedane), trzeba się cofnąć
                        if( m_stage.Towers.Count == 0 )
                        {
                            m_step = 0;
                        }

                        //wystartowano z rundą
                        if( m_stage.IsStart )
                        {
                            ++m_step;
                            this.m_time = gameTime.TotalGameTime.TotalSeconds;
                        }
                        break;
                    }
                case 7: //pierwsza runda już jest odpalona
                    {
                        //minął odpowiedni czas
                        if( gameTime.TotalGameTime.TotalSeconds >= this.m_time + StaticConsts.Helper.info_time )
                        {
                            ++m_step;
                            this.m_time = gameTime.TotalGameTime.TotalSeconds;
                        }
                        break;
                    }
                case 8: //minął odpowiedni czas
                    {
                        //minął odpowiedni czas
                        if( gameTime.TotalGameTime.TotalSeconds >= this.m_time + StaticConsts.Helper.info_time )
                        {
                            this.m_end = true;  //koniec tutka
                        }
                        break;
                    }
            }
        }

        public bool Update( GameTime gameTime )
        {
            Check( gameTime );
            m_tablets[m_step].Update( gameTime );
            return m_end;
        }
        public void Draw( SpriteBatch spriteBatch )
        {
            m_tablets[m_step].Draw( spriteBatch );
            //spriteBatch.DrawString( StaticFonts.Records, m_stage.Menu.Upgrader.Clicked.ToString(), new Vector2( 20 ), Color.Yellow );
        }
    }

    public class CTablet    //tabliczka używana w CHelper
    {
        private Texture2D m_tex;    //tekstura tabliczki
        private Color m_col;    //kolor tabliczki (żeby mogła zanikać)
        private bool m_focused; //czy myszka znajduje się nad tabliczką?
        private Rectangle m_rec;    //prostokąt, w którym mieści się tabliczka
        private Vector2 m_position;    //położenie tabliczki

        public Vector2 Position { set { m_position = value; this.m_rec.X = ( int )value.X; this.m_rec.Y = ( int )value.Y; } }   //zmienia pozycje i poprawia m_rec 

        public CTablet( Texture2D tex, Vector2 pos )
        {
            this.m_tex = tex;
            this.m_position = pos;

            this.m_focused = false;
            this.m_rec = new Rectangle( ( int )pos.X, ( int )pos.Y, tex.Width, tex.Height );
            this.m_col = Color.White;
        }

        public void Update(GameTime gameTime)
        {
            if( MyFunctions.Intersects( m_rec, MyFunctions.GetMousePosition() ) )
                m_focused = true;
            else
                m_focused = false;

            if( m_focused && m_col.A < 255 )
            {
                m_col.A += StaticConsts.Helper.fade_speed;
                m_col.R += StaticConsts.Helper.fade_speed;
                m_col.G += StaticConsts.Helper.fade_speed;
                m_col.B += StaticConsts.Helper.fade_speed;
            }
            if( !m_focused && m_col.A > StaticConsts.Helper.fade_power )
            {
                m_col.A -= StaticConsts.Helper.fade_speed;
                m_col.R -= StaticConsts.Helper.fade_speed;
                m_col.G -= StaticConsts.Helper.fade_speed;
                m_col.B -= StaticConsts.Helper.fade_speed;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw( m_tex, m_position, m_col );
        }

    }

    public class CButton //klasa reprezentująca guzik
    {
        private Texture2D m_texture_normal;
        private Texture2D m_texture_focus;
        private Texture2D m_texture_lock;
        public Texture2D m_texture_special;
        private Vector2 m_position;
        private bool m_block_click; //przytrzymanie przycisku już nie jest problemem :D
        private bool m_focused;

        public bool Focus { get{return this.m_focused;} }
        public MyButtonState m_state;

        private CButton()
        {
            this.m_state = MyButtonState.Normal;
            this.m_focused = false;
        }

        public CButton(Vector2 position, Texture2D normal, Texture2D focus, Texture2D locked)
        {
            this.m_position = position;
            this.m_texture_normal = normal;
            this.m_texture_focus = focus;
            this.m_texture_lock = locked;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            switch (m_state)
            {
                case MyButtonState.Normal: spriteBatch.Draw(m_texture_normal, m_position, Color.White); break;
                case MyButtonState.Lock: spriteBatch.Draw(m_texture_lock, m_position, Color.White); break;
                case MyButtonState.Focus: spriteBatch.Draw(m_texture_focus, m_position, Color.White); break;
                case MyButtonState.Special: if (m_texture_special != null) spriteBatch.Draw(m_texture_special, m_position, Color.White); break;
            }

            //spriteBatch.DrawString( StaticFonts.Info, (this.Focus ? 'Y' : 'N').ToString(), m_position + new Vector2( 90, 5 ), Color.Magenta );
        }
        public bool Update(GameTime gameTime) //zwraca true tylko, jesli przycisk został naciśnięty
        {
            if (m_state == MyButtonState.Special || m_state == MyButtonState.Lock)
                return false;

            //zakładam, że wszystkie 3 tekstury przycisku mają równe wymiary
            int minX = (int)m_position.X;
            int minY = (int)m_position.Y;
            int maxX = minX + m_texture_normal.Width;
            int maxY = minY + m_texture_normal.Height;

            //pozycja myszki
            MouseState mysz = Mouse.GetState();
            int X = mysz.X;
            int Y = mysz.Y;

            if( minX < X && X < maxX )
            {
                if( minY < Y && Y < maxY )
                {
                    this.m_focused = true;
                }
                else
                {
                    this.m_focused = false;
                }
            }
            else
            {
                this.m_focused = false;
            }

            if( this.m_focused )
                m_state = MyButtonState.Focus;
            else
                m_state = MyButtonState.Normal;

            if( mysz.LeftButton == ButtonState.Pressed )
            {
                if( this.m_focused && !m_block_click )
                {
                    m_block_click = true;
                    return true;
                }
            }
            else
            {
                if( m_block_click )
                    m_block_click = false;
            }
            return false;
        }

    }

    public class CSprite
    {   /*  Klasa reprezentująca każdy wyświetlany obiekt na ekranie.
         *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  */
        protected Texture2D m_texture; //tekstura
        protected int m_cols;   //liczba kolumn tekstury (klatek)
        protected int m_currentframe;  //indeks obecnej klatki
        protected Vector2 m_framesize;    //wielkość jednej klatki

        public Vector2 m_position; //położenie obrazu
        public Color m_color;   //kolor obrazu
        public bool m_draw; //czy ten obrazek ma być rysowany?
        public float m_rotate;    //obrót obrazu w stopniach
        public float m_scale;   //skala wyświetlanego obrazu

        public bool m_is;

        public int Width { get { return m_texture.Width; } }
        public int Height { get { return m_texture.Height; } }
        public Texture2D Texture { get { return m_texture; } }
        public Vector2 FrameSize { get { return m_framesize; } }

        public CSprite(CSprite sprite)  //konstruktor kopiujący
            : this(sprite.m_texture, sprite.m_position, sprite.m_cols) { }
        protected CSprite()   //konstruktor podstawowy
        {
            this.m_texture = null;
            this.m_position = Vector2.Zero;
            this.m_cols = 1;
            this.m_color = Color.White;
            this.m_currentframe = 1;
            this.m_draw = true;
            this.m_rotate = 0;
            this.m_scale = 1f;
            this.m_is = true;
        }
        public CSprite(Texture2D texture, int cols) //konstruktor model
            : this()
        {
            this.m_texture = texture;
            this.m_cols = cols;
            this.m_framesize = new Vector2(m_texture.Width / cols, m_texture.Height);
        }
        public CSprite(Texture2D texture, Vector2 position, int cols)   //pełny konstruktor
            : this(texture, cols)
        {
            this.m_position = position;
        }
        public CSprite(CSprite model, Vector2 position) //konstruktor do tworzenia z modelu
            : this(model.m_texture, position, model.m_cols) { }

        public virtual CSprite DeepCopy()
        {
            return new CSprite(this);
        }

        public CSprite Copy()
        {
            return new CSprite(this);
        }

        public bool Check()
        {
            return m_is;
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (!m_draw)
                return;

            int szerokosc = (int)(m_texture.Width);
            int wysokosc = (int)(m_texture.Height);

            if (m_cols == 1) //obraz, to pojedyncza klatka
            {
                spriteBatch.Draw(m_texture, m_position, new Rectangle(0, 0, szerokosc, wysokosc), m_color, MathHelper.ToRadians(m_rotate), new Vector2(szerokosc / 2, wysokosc / 2), m_scale, SpriteEffects.None, 0f);
            }
            else    //obraz składa się z kilku klatek
            {
                Rectangle frame = new Rectangle((m_currentframe - 1) * (int)(m_framesize.X), 0, (int)(m_framesize.X), (int)(m_framesize.Y));
                spriteBatch.Draw(m_texture, m_position, frame, m_color, MathHelper.ToRadians(m_rotate), new Vector2(szerokosc / 2, wysokosc / 2), 1f, SpriteEffects.None, 0f);
            }
        }
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime, Vector2 position) //rysuje obrazek w podanym miejscu
        {
            //zmienia współrzędne, rysuje i wraca do pierwszych współrzędnych
            Vector2 buffer = m_position;
            m_position = position;
            Draw(spriteBatch, gameTime);
            m_position = buffer;
        }

        public virtual void SetState(int frame)
        {
            m_currentframe = frame;
        }
    }
    public class CAnimation : CSprite
    {
        protected double m_lastframe;  //czas, kiedy byla wyswietlana ostatnia klatka
        protected int m_rows;   //ilość rzędów (sekwencji obrazków)
        protected int m_currentrow; //z którego rzędu pobierać klatki (z której sekwencji)

        public bool m_loop; //czy animacja trwa wiecznie
        public double m_framerate;  //ile klatek w trakcie sekundy ma się wyświetlić

        public CAnimation() //konstruktor podstawowy
            : base()
        {
            this.m_framerate = 1d / 24;
            this.m_lastframe = 0;
            this.m_currentrow = 1;
            this.m_loop = true;
        }
        public CAnimation(Texture2D texture, int cols, int rows)    //konstruktor do tworzenia modelu
            : this()
        {
            this.m_texture = texture;
            this.m_cols = cols;
            this.m_rows = rows;
            this.m_framesize.Y = texture.Height / rows;
            this.m_framesize.X = texture.Width / cols;
        }
        public CAnimation(CAnimation model, Vector2 position)   //konstruktor do tworzenia z modelu
            : this(model.m_texture, position, model.m_cols, model.m_rows) { this.m_loop = model.m_loop; }
        public CAnimation(Texture2D texture, Vector2 position, int cols, int rows)
            : this() //konstruktor pełny
        {
            this.m_position = position;
            this.m_texture = texture;
            this.m_cols = cols;
            this.m_rows = rows;
            this.m_framesize.X = texture.Width / cols;
            this.m_framesize.Y = texture.Height / rows;
        }
        public CAnimation(CAnimation obj)
            : this(obj.Texture, obj.m_position, obj.m_cols, obj.m_rows)
        {
            this.m_loop = obj.m_loop;
            this.m_framerate = obj.m_framerate;
        }

        public override CSprite DeepCopy()
        {
            return new CAnimation(this);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {   //zakładam, że każda animacja składa się z więcej, niż 1 klatki.

            // * wyświetlanie klatki
            int szerokosc = (int)(m_framesize.X);
            int wysokosc = (int)(m_framesize.Y);

            Rectangle frame = new Rectangle((m_currentframe - 1) * szerokosc, (m_currentrow - 1) * wysokosc, szerokosc, wysokosc);
            spriteBatch.Draw(m_texture, m_position, frame, m_color, MathHelper.ToRadians(m_rotate), new Vector2(szerokosc / 2, wysokosc / 2), m_scale, SpriteEffects.None, 0f);
            //spriteBatch.Draw(m_texture, m_position, Color.White);

            // * zmiana klatki
            double now = gameTime.TotalGameTime.TotalSeconds;
            if (now >= m_lastframe + m_framerate)
            {   //minął wystarczający czas - pora zmienić klatkę
                if (++m_currentframe > m_cols)
                    if (m_loop)
                        m_currentframe = 1; //jeśli klatka wychodzi za granice, wracamy do 1
                    else
                        m_is = false;

                m_lastframe = now;
            }
        }
        public override void SetState(int row)
        {
            m_currentrow = row;
        }

    }

    public abstract class CPopUp
    {
        protected bool m_is;

        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
        public virtual bool Check()
        {
            return m_is;
        }
    }
    public class CStringOffset : CPopUp
    {
        public SpriteFont m_font;
        public string m_text;
        public Color m_color;
        public Vector2 m_position;
        public float m_direction;
        public bool m_fade;

        protected float m_speed;    //pixele na sekundę
        protected int m_distance;
        protected double m_time;
        protected Vector2 m_start_position;

        public CStringOffset(SpriteFont font, string text, Color color, Vector2 position, double time, int distance)
        {
            this.m_font = font;
            this.m_text = text;
            this.m_color = color;
            this.m_position = this.m_start_position = position;
            //this.m_position = position;
            this.m_time = time;
            this.m_distance = distance;
            this.m_direction = 90;  //dół
            this.m_speed = (float)(distance / time);
            this.m_fade = true;

            this.m_is = true;
        }

        public override void Update(GameTime gameTime)
        {
            float distance = Vector2.Distance(m_start_position, m_position);
            if (distance > m_distance)
                this.m_is = false;

            //przesunięcie w danym kierunku
            float droga = (float)(m_speed * gameTime.ElapsedGameTime.TotalSeconds);
            m_position = MyFunctions.CirclePoint(m_position, droga, 360, (int)m_direction);

            //zanikanie
            if (m_fade)
            {
                float progress = distance > 0 ? distance / m_distance : 0;
                m_color.A = (byte)(progress * 255);
            }
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.DrawString(m_font, m_text, m_position, m_color);
        }
    }

    public abstract class CGameObject
    {
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(SpriteBatch spriteBatch, GameTime gameTime);
        public abstract bool Check();
    }
    public class CEnemy : CGameObject
    {
        //ustawienia ruchu
        protected double m_lastmove;  //czas, kiedy ostatnio wywołano move()
        protected List<CEffect> m_effects;  //lista obiektów z efektami
        protected EnemyType m_type;    //typ przeciwnika
        public Vector2 m_target;   //miejsce, w kierunku którego się porusza
        public float m_speed;  //ile punktów pokonuje w 1 sekunde
        public int m_target_index; //w do którego punku mapy z kolei się teraz udaje
        //reszta
        protected CSprite m_sprite;    //texturka potworka
        public CStage m_stage;   //referencja do obiektu całej planszy
        public int m_maxhealth;  //maksymalny poziom życia
        public int m_health;   //ilość punktów życia potworka
        public bool m_is;   //czy ten obiekt w ogóle jest?

        public int m_reward;    //ilość kasy, którą dostaje się za rozwalenie przeciwnia
        public int m_damage;   //ile hp zadaje graczowi, gdy dotrze do końca drogi

        public EnemyType Type { get { return m_type; } }
        public Vector2 Position
        { //pozycja przeciwnika (zsynchronizowane z m_sprite.m_position)
            get { return m_sprite.m_position; }
            set { m_sprite.m_position = value; }
        }
        public Vector2 TextureSize { get { return (m_sprite.FrameSize); } }
        public Color Color { get { return m_sprite.m_color; } set { m_sprite.m_color = value; } }

        public List<string> m_logs;
        public Vector2 m_lastposition;
        public float m_angle;

        //konkstruktory
        public CEnemy() //konstruktor podstawowy
        {
            this.m_health = m_maxhealth = 100;
            this.m_target_index = 1;

            this.m_logs = new List<string>();
            this.m_lastmove = 0;
            this.m_angle = 0;

            this.m_is = true;
        }
        public CEnemy(CSprite sprite, int health, float speed, int reward, int damage, EnemyType type) //konstrutkor do tworzenia modelu
            : this()
        {
            this.m_sprite = sprite.DeepCopy();
            this.m_health = m_maxhealth = health;
            this.m_speed = speed;
            this.m_reward = reward;
            this.m_damage = damage;
            this.m_type = type;
        }
        public CEnemy( CSprite sprite, int health, float speed, int reward, int damage, EnemyType type, CStage stage ) //pełny konstrutor
            : this(sprite, health, speed, reward, damage, type)
        {
            this.m_stage = stage;
            this.m_sprite.m_position = stage.Way[0];
            if( type != EnemyType.Fly )
            {
                this.m_target = stage.Way[1];
            }
            else
            {
                this.m_target = stage.Way.Last();
                this.m_target_index = stage.Way.Count() - 1;
            }

            //niech pojawianie się mobków będzie odrobinkę losowe
            this.m_sprite.m_position.X += MyFunctions.NextFloat(m_stage.Random, StaticConsts.Enemies.MoveError);
            this.m_sprite.m_position.Y += MyFunctions.NextFloat(m_stage.Random, StaticConsts.Enemies.MoveError);
            //to samo z m_target
            this.m_target.X += MyFunctions.NextFloat(m_stage.Random, StaticConsts.Enemies.MoveError);
            this.m_target.Y += MyFunctions.NextFloat(m_stage.Random, StaticConsts.Enemies.MoveError);
        }
        public CEnemy(CEnemy model, CStage stage)   //konstruktor do tworzenia obiektu z modelu
            : this(model.m_sprite, model.m_health, model.m_speed, model.m_reward, model.m_damage, model.m_type, stage) { }
        public CEnemy(CEnemy obj) //konstruktor kopiujący
            : this(obj.m_sprite, obj.m_health, obj.m_speed, obj.m_reward, obj.m_damage, obj.m_type, obj.m_stage) { }

        public virtual CEnemy DeepCopy()
        {
            CEnemy ret = new CEnemy( this );
            return ret;
        }
        public virtual CEnemy Create(CStage stage)
        {
            return new CEnemy( this, stage );
        }

        public override void Update(GameTime gameTime)
        {
            //nie powinno być potrzeby napisania kodu poniżej
            //a jednak wywala błędy..
            if( !m_is )
                return;

            Rotate();
            Move(gameTime);
            EffUpdate(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //pasek hp
            if (m_health < m_maxhealth)
            {
                int width = (int)m_sprite.FrameSize.X;
                int height = (int)m_sprite.FrameSize.Y;

                int x = (int)(m_sprite.m_position.X) - width / 2;
                int y = (int)(m_sprite.m_position.Y) - height / 2;
                int hpb_life;

                if (m_health > 0)
                    hpb_life = (int)((float)(m_health) / (float)(m_maxhealth) * (float)(width)); //szerokość paska życia
                else
                    hpb_life = 0;
                Rectangle HPBar = new Rectangle(x, (y - StaticConsts.Enemies.hpb_offset - StaticConsts.Enemies.hpb_height), hpb_life, StaticConsts.Enemies.hpb_height);
                Rectangle HPBarNeed = new Rectangle(HPBar.Left + hpb_life, HPBar.Top, width - hpb_life, StaticConsts.Enemies.hpb_height);

                spriteBatch.Draw(StaticTextures.Dot, HPBar, StaticConsts.Enemies.hpb_color_health);
                spriteBatch.Draw(StaticTextures.Dot, HPBarNeed, StaticConsts.Enemies.hpb_color_need);
            }
            m_sprite.Draw(spriteBatch, gameTime);


            if (m_effects != null)
            {
                int trueI = 0;
                for( int i = 0; i < m_effects.Count; ++i )
                {
                    if( m_effects[i] != null )
                    {
                        m_effects[i].Draw( spriteBatch, gameTime, trueI );
                        ++trueI;
                    }
                }
            }

        }

        public override bool Check()
        {
            return m_is;
        }
        public void AddEffect(GameTime gameTime, CEffect effect)
        {
            //jeśli nie ma jeszcze listy, zostaje stworzona
            if (m_effects == null)
                m_effects = new List<CEffect>(5);

            string name = effect.Name;
            CEffect eff = null;

            foreach (CEffect eff_i in m_effects)
            {
                if (eff_i != null && name.Equals(eff_i.Name))
                    eff = eff_i;
            }

            if( eff != null )
            {
                eff.Refresh( gameTime );
            }
            else
            {
                m_effects.Add( effect );
            }
        }
        public void Attacked(int damage)
        {
            m_health -= damage;

            if( m_effects != null )
            {
                foreach( CEffect eff in m_effects )
                {
                    if( eff != null)
                        eff.HandleAttacked( damage );
                }
            }

            if (m_health <= 0)
                Killed();
        }
        public virtual void Killed()
        {
            if( m_effects != null )
            {
                foreach( CEffect eff in m_effects )
                {
                    if( eff != null )
                        eff.HandleKilled();
                }
            }

            if( m_reward > 0 )
            {
                m_stage.Money += m_reward;
                m_stage.Popups.Add( new CStringOffset( StaticFonts.Popup, m_reward + "$", Color.Green, this.Position, StaticConsts.Popup.CashTime, StaticConsts.Popup.CashDistance ) );
            }
            Remove();
        }

        protected void EffUpdate( GameTime gameTime )
        {
            //brak efektów
            if( m_effects != null )
            {
                int count = m_effects.Count();
                for( int i = 0; i < count; ++i )
                {
                    //update'owanie efektu i sprawdzanie, czy się przypadkiem nie skończył
                    if( m_effects != null && m_effects[i] != null ) //sprawdzanie, czy obiekt jeszcze istnieje
                        if( !m_effects[i].Update( gameTime ) )  //update elementu
                            if( m_effects != null && m_effects[i] != null )
                                m_effects[i] = null;    //ewentualne czyszczenie elementu
                }
            }
        }
        protected void Move( GameTime gameTime )
        {
            //przenoszenie się w kierunku m_target
            double time = gameTime.ElapsedGameTime.TotalSeconds;
            double droga = Vector2.Distance(m_sprite.m_position, m_target);

            m_logs.Clear();
            int fakeRotate = 0; ;
            fakeRotate = (int)m_sprite.m_rotate - 90;
            if (fakeRotate <= 0) fakeRotate = 360 + fakeRotate;

            if (time * m_speed >= droga)
            {
                m_sprite.m_position = m_target;
            }
            else
            {
                m_sprite.m_position = MyFunctions.CirclePoint(m_sprite.m_position, (float)(time * m_speed), 360, fakeRotate);
            }

            //jeśli dotarł do ostatniego, ma zginąć
            if (m_sprite.m_position == m_target && m_target_index + 1 == m_stage.Way.Count())
            {
                m_stage.Basehealth -= this.m_damage;
                m_stage.Popups.Add(new CStringOffset(StaticFonts.Popup, "-" + m_damage, Color.Red, Position, StaticConsts.Popup.HealthTime, StaticConsts.Popup.HealtDistance));
                Remove();
            }
            //jeśli potworek osiągnął cel, namierz następny
            if (m_sprite.m_position == m_target && m_target_index + 1 < m_stage.Way.Count())
            {
                m_target = m_stage.Way[++m_target_index];
                //jeszcze dodanie errora do targetu
                m_target.X += MyFunctions.NextFloat(m_stage.Random, StaticConsts.Enemies.MoveError);
                m_target.Y += MyFunctions.NextFloat(m_stage.Random, StaticConsts.Enemies.MoveError);
            }

            m_lastmove = gameTime.TotalGameTime.TotalSeconds;
        }
        protected void Rotate()
        {
            m_angle = m_sprite.m_rotate = MyFunctions.Angle( m_sprite.m_position, m_target );
        }
        protected void Remove()
        {
            m_is = false;
            m_effects = null;
        }
    }
    public class CSpawner : CEnemy
    {
        protected CEnemy spawn_unit;
        protected int spawn_ammount;

        public CSpawner()
            : base()
        {
            this.spawn_unit = null;
            this.spawn_ammount = 1;
        }
        public CSpawner(CSprite sprite, int health, float speed, int reward, int damage, CEnemy spawn_unit, int spawn_ammount, EnemyType type) //konstrutkor do tworzenia modelu
            : this()
        {
            this.m_sprite = sprite.DeepCopy();
            this.m_health = m_maxhealth = health;
            this.m_speed = speed;
            this.m_reward = reward;
            this.m_damage = damage;
            this.m_type = type;
            this.spawn_unit = spawn_unit;
            this.spawn_ammount = spawn_ammount;
        }
        public CSpawner( CSprite sprite, int health, float speed, int reward, int damage, CEnemy spawn_unit, int spawn_ammount,  EnemyType type, CStage stage ) //pełny konstrutor
            : this(sprite, health, speed, reward, damage, spawn_unit, spawn_ammount, type)
        {
            this.m_stage = stage;
            this.m_sprite.m_position = stage.Way[0];
            if( type != EnemyType.Fly )
            {
                this.m_target = stage.Way[1];
            }
            else
            {
                this.m_target = stage.Way.Last();
                this.m_target_index = stage.Way.Count() - 1;
            }

            //niech pojawianie się mobków będzie odrobinkę losowe
            this.m_sprite.m_position.X += MyFunctions.NextFloat(m_stage.Random, StaticConsts.Enemies.MoveError);
            this.m_sprite.m_position.Y += MyFunctions.NextFloat(m_stage.Random, StaticConsts.Enemies.MoveError);
            //to samo z m_target
            this.m_target.X += MyFunctions.NextFloat(m_stage.Random, StaticConsts.Enemies.MoveError);
            this.m_target.Y += MyFunctions.NextFloat(m_stage.Random, StaticConsts.Enemies.MoveError);
        }
        public CSpawner(CSpawner model, CStage stage)   //konstruktor do tworzenia obiektu z modelu
            : this(model.m_sprite, model.m_health, model.m_speed, model.m_reward, model.m_damage, model.spawn_unit, model.spawn_ammount, model.m_type, stage) { }
        public CSpawner( CSpawner obj ) //konstruktor kopiujący
            : this(obj.m_sprite, obj.m_health, obj.m_speed, obj.m_reward, obj.m_damage, obj.spawn_unit, obj.spawn_ammount, obj.m_type, obj.m_stage) { }

        public override CEnemy DeepCopy()
        {
            CSpawner ret = new CSpawner( this );
            return ret;
        }
        public override CEnemy Create( CStage stage )
        {
            return new CSpawner( this, stage );
        }

        public override void Killed()
        {
            for( int i = 0; i < spawn_ammount; ++i )
            {
                //tworzenie obiektu spawna
                CEnemy spawn = spawn_unit.Create( m_stage );
                //ustawianie miejsca startu
                Vector2 pos = Position;
                pos.X += MyFunctions.NextFloat( m_stage.Random, StaticConsts.Enemies.Spawner_error );
                pos.Y += MyFunctions.NextFloat( m_stage.Random, StaticConsts.Enemies.Spawner_error );
                spawn.Position = pos; //przypisanie miejsca
                spawn.m_target_index = this.m_target_index; //przypisanie indeksu celu
                spawn.m_target = this.m_target;

                m_stage.Enemies.Add( spawn );
            }

            base.Killed();
        }
    }
    public class CTeleporter : CEnemy
    {
        protected double lastTP;    //czas, ostatniego teleportu
        protected double cooldownTP;    //co jaki czas jednostka się teleportuje
        protected float distance;
        protected CAnimation anim_effect;    //pojawiający się sprites podczas teleportu

        public CTeleporter()
            : base()
        {
            this.lastTP = 0;
            this.cooldownTP = 1;
            this.distance = 1;
            this.anim_effect = null;
        }
        public CTeleporter( CSprite sprite, int health, float speed, int reward, int damage, CAnimation effect, double cooldown, float distance, EnemyType type ) //konstrutkor do tworzenia modelu
            : this()
        {
            this.m_sprite = sprite.DeepCopy();
            this.m_health = m_maxhealth = health;
            this.m_speed = speed;
            this.m_reward = reward;
            this.m_damage = damage;
            this.m_type = type;
            this.anim_effect = effect;
            this.cooldownTP = cooldown;
            this.distance = distance;
        }
        public CTeleporter( CSprite sprite, int health, float speed, int reward, int damage, CAnimation effect, double cooldown, float distance, EnemyType type, CStage stage ) //pełny konstrutor
            : this( sprite, health, speed, reward, damage, effect, cooldown, distance, type )
        {
            this.m_stage = stage;
            this.m_sprite.m_position = stage.Way[0];
            if( type != EnemyType.Fly )
            {
                this.m_target = stage.Way[1];
            }
            else
            {
                this.m_target = stage.Way.Last();
                this.m_target_index = stage.Way.Count() - 1;
            }

            //niech pojawianie się mobków będzie odrobinkę losowe
            this.m_sprite.m_position.X += MyFunctions.NextFloat( m_stage.Random, StaticConsts.Enemies.MoveError );
            this.m_sprite.m_position.Y += MyFunctions.NextFloat( m_stage.Random, StaticConsts.Enemies.MoveError );
            //to samo z m_target
            this.m_target.X += MyFunctions.NextFloat( m_stage.Random, StaticConsts.Enemies.MoveError );
            this.m_target.Y += MyFunctions.NextFloat( m_stage.Random, StaticConsts.Enemies.MoveError );
        }
        public CTeleporter( CTeleporter model, CStage stage )   //konstruktor do tworzenia obiektu z modelu
            : this( model.m_sprite, model.m_health, model.m_speed, model.m_reward, model.m_damage, model.anim_effect, model.cooldownTP, model.distance, model.m_type, stage ) { }
        public CTeleporter( CTeleporter obj ) //konstruktor kopiujący
            : this( obj.m_sprite, obj.m_health, obj.m_speed, obj.m_reward, obj.m_damage, obj.anim_effect, obj.cooldownTP, obj.distance, obj.m_type, obj.m_stage ) { }

        public override CEnemy DeepCopy()
        {
            CTeleporter ret = new CTeleporter( this );
            return ret;
        }
        public override CEnemy Create( CStage stage )
        {
            return new CTeleporter( this, stage );
        }

        public override void Update( GameTime gameTime )
        {
            Teleport( gameTime );
            base.Update( gameTime );
        }
        protected void Teleport( GameTime gameTime )
        {
            double now = gameTime.TotalGameTime.TotalSeconds;
            //aby nie teleportować się na starcie
            if( lastTP == 0 )
                lastTP = now + cooldownTP + MyFunctions.NextFloat( m_stage.Random, StaticConsts.Enemies.Teleporter_time_error );

            //jeśli minął cooldown, lecimy do przodu
            if( lastTP < now )
            {
                CreateEffect(); //efekt wizualny
                //ustawienie cooldownu
                lastTP = now + cooldownTP;
                float way = Vector2.Distance( Position, m_target );
                //sprawdzanie odległości
                if( way >= distance )
                //można się bezstresowo teleportować
                {
                    //liczenie, jakim procentem drogi do punktu jest dystans teleportu
                    float percent = distance / way;
                    Vector2 cel = Vector2.Lerp( Position, m_target, percent );
                    //dodanie errorka
                    cel.X += MyFunctions.NextFloat( m_stage.Random, StaticConsts.Enemies.TeleportError );
                    cel.Y += MyFunctions.NextFloat( m_stage.Random, StaticConsts.Enemies.TeleportError );
                    Position = cel;
                }
                else
                //tutaj zaczynają się schody, ponieważ trzeba zrobić 'zakręt'
                {
                    //sprawdźmy, ile zostanie nam drogi do przebycia po wykonaniu zakrętu
                    float restDistance = distance - way;

                    //może się zdarzyć, że jednym teleportem pokonamy więcej, niż jeden zakręt
                    while(restDistance > way)   //dopuki pozostała droga teleportu jest większa od drogi do celu
                    {
                        //przenieśmy jednostkę na róg, oraz zmieńmy cel na nowy
                        Position = m_target;
                        //zmiana celu
                        if( m_target_index + 1 < m_stage.Way.Count() )
                        {
                            m_target = m_stage.Way[++m_target_index];
                            //dodanie errora do targetu
                            m_target.X += MyFunctions.NextFloat( m_stage.Random, StaticConsts.Enemies.MoveError );
                            m_target.Y += MyFunctions.NextFloat( m_stage.Random, StaticConsts.Enemies.MoveError );
                        }
                        //w tej chwili stoimy na rogu i mamy zaznaczony kolejny punkt (lub ten sam, jeśil był ostatni)
                        //tak więc, jeśli punkt się nie zmienił, to nadal w nim stoimy - to oznacza, że możemy zakończyć teleportację
                        if( Position == m_target )
                            return;
                        restDistance = restDistance - way;
                        way = Vector2.Distance( Position, m_target );
                    }
                    
                    //w tej chwili stoimi na ostatni rogu z kolei, mamy nowy cel i możemy teleportować się do celu
                    float percent = restDistance / way;
                    Vector2 cel = Vector2.Lerp( Position, m_target, percent );
                    //dodanie errorka
                    cel.X += MyFunctions.NextFloat( m_stage.Random, StaticConsts.Enemies.TeleportError );
                    cel.Y += MyFunctions.NextFloat( m_stage.Random, StaticConsts.Enemies.TeleportError );
                    Position = cel;
                }
                CreateEffect(); //efekt wizualny
            }
        }
        protected void CreateEffect()
        {
            m_stage.Details.Add( new CAnimation( anim_effect, Position ) );
        }

    }

    public class CTower : CGameObject
    {
        protected double m_lastshoot;   //czas ostatniego strzału
        public int m_damage;   //obrażenia
        public float m_reload; //co ile sekund może strzelić
        public float m_range;  //zasięg strzału
        public CBullet m_bullet; //pocisk, którym strzela wieżyczka
        protected CStage m_stage;   //referencja na planszę
        protected bool m_aim;   //czy wieżyczka jest skierowana na przeciwnika
        protected int m_value; //kasa, którą się dostaje za sprzedarz wieżyczki
        protected string m_description; //opis wieżyczki (do wyświetlania w infoboxie)

        public CSprite m_spr_tower; //obrazek wieżyczki (obrotowa część)
        public CSprite m_spr_stage; //obrazek podstawy wieżyczki (stała część)
        public CSprite m_spr_range; //obrazek pola zasięgu strzału

        public CTower m_upgrade;    //wieżyczka, w którą się ulepsza
        public string m_name;   //nazwa wieżyczki
        public int m_cost;  //cena wieżyczki

        public CEnemy m_target; //przeciwnik, do którego celuję
        public float m_rotate_speed;    //prędkość obrotu wieżyczki
        public bool m_clicked;  //czy wieżyczka jest teraz zaznaczona

        public bool m_is;   //czy ten obiekt w ogóle jest
        public bool freeze_rotate;  //czy obiekt ma zablokowany obrót
        public bool ignore_aim; //czy obiekt może strzelać bokiem, tyłem itd. (nie musi celować we wroga)

        public int Value { get { return m_value; } }
        public Color Color { get { return m_spr_tower.m_color; } set { m_spr_tower.m_color = m_spr_stage.m_color = value; } }
        public Vector2 Position { get { return m_spr_tower.m_position; } set { m_spr_tower.m_position = m_spr_stage.m_position = m_spr_range.m_position = value; } }
        public Vector2 Size { get { return new Vector2(m_spr_tower.Texture.Width, m_spr_tower.Texture.Height); } }

        public int Damage { get { return m_damage; } }
        public float Range { get { return m_range; } }
        public float Rate { get { return m_reload; } }
        public string Description { get { return m_description; } }

        public List<string> m_logs;

        protected CTower() //konstruktor podstawowy
        {
            this.m_damage = 1;
            this.m_reload = 1;
            this.m_range = 80f;
            this.m_lastshoot = 0;
            this.m_target = null;
            this.m_rotate_speed = 120;
            this.m_clicked = false;
            this.m_aim = false;
            this.m_is = true;
            this.m_name = "wiezyczka bez nazwy";
            this.m_description = "pusty opis";
            this.m_spr_range = StaticSprites.Range.DeepCopy();
            this.freeze_rotate = false;
            this.ignore_aim = false;

            this.m_logs = new List<string>();

        }
        public CTower(int damage, float reload, float range, CSprite spr_tower, CSprite spr_stage, float rotate_speed, CBullet bullet, CTower upgrade, string name, string desc, int cost) //konstruktor do tworzenia modelu
            : this()
        {
            this.m_spr_tower = spr_tower.DeepCopy();
            this.m_spr_stage = spr_stage.DeepCopy();
            this.m_damage = damage;
            this.m_reload = reload;
            this.m_range = range;
            this.m_rotate_speed = rotate_speed;
            if (bullet != null)
                this.m_bullet = bullet.DeepCopy();
            else
                this.m_bullet = null;
            this.m_name = name;
            this.m_description = desc;
            this.m_cost = cost;
            this.m_value = (int)(cost * StaticConsts.Towers.SellPercent);
            if (upgrade != null)
                this.m_upgrade = upgrade.CopyModel();
            else
                this.m_upgrade = null;
        }
        public CTower(int damage, float reload, float range, CSprite spr_tower, CSprite spr_stage, float rotate_speed, CBullet bullet, CTower upgrade, string name, string desc, int cost, CStage stage) //pełny konstruktor
            : this(damage, reload, range, new CSprite(spr_tower), spr_stage, rotate_speed, bullet, upgrade, name, desc, cost)
        {
            this.m_stage = stage;
        }
        public CTower(CTower model, Vector2 position, CStage stage)   //tworzenie obiektu z modelu
            : this(model.m_damage, model.m_reload, model.m_range, model.m_spr_tower, model.m_spr_stage, model.m_rotate_speed, model.m_bullet, model.m_upgrade, model.m_name, model.m_description, model.m_cost, stage)
        { 
            this.m_spr_stage.m_position = this.m_spr_tower.m_position = position; 
            this.freeze_rotate = model.freeze_rotate; 
        }
        public CTower(CTower obj) //konstruktor kopiujący
            : this( obj.m_damage, obj.m_reload, obj.m_range, obj.m_spr_tower, obj.m_spr_stage , obj.m_rotate_speed, obj.m_bullet, obj.m_upgrade, obj.m_name, obj.m_description, obj.m_cost, obj.m_stage )            
        {
            this.freeze_rotate = obj.freeze_rotate;
        }

        public override void Update(GameTime gameTime)
        {
            m_logs.Clear();

            CheckTarget();
            Rotate(gameTime);
            Shoot(gameTime);

            m_logs.Add("pusto");
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (m_clicked)
            {
                Rectangle rec = new Rectangle((int)(m_spr_tower.m_position.X - m_range), (int)(m_spr_tower.m_position.Y - m_range), (int)m_range * 2, (int)m_range * 2);
                spriteBatch.Draw(StaticTextures.Range, rec, Color.Blue);
            }

            if (m_clicked)
                DrawRange(spriteBatch, gameTime);
            //MyFunctions.DrawCircle(spriteBatch, m_spr_tower.m_position, m_range, 32, 6, Color.Red);

            m_spr_stage.Draw(spriteBatch, gameTime);
            m_spr_tower.Draw(spriteBatch, gameTime);
        }
        public virtual void DrawRange(SpriteBatch spriteBatch, GameTime gameTime)
        {
            float scale = m_range / m_spr_range.Width * 2;
            m_spr_range.m_scale = scale;
            m_spr_range.Draw(spriteBatch, gameTime, m_spr_tower.m_position);
        }
        public override bool Check()
        {
            return m_is;
        }
        public virtual CTower CopyModel() //służy do kopiowania modelu (różni się od konstruktora kopiującego przede wszystkim brakiem referencji na CStage)
        {
            CTower ret = new CTower(this.m_damage, this.m_reload, this.m_range, this.m_spr_tower, this.m_spr_stage, this.m_rotate_speed, this.m_bullet, this.m_upgrade, this.m_name, this.m_description, this.m_cost);
            ret.freeze_rotate = this.freeze_rotate;
            return ret;
        }
        public virtual CTower Create(Vector2 position, CStage stage)
        {
            return new CTower( this, position, stage );
        }
        public virtual void Upgrade()
        {
            Vector2 pos = this.Position;
            m_stage.Money -= m_upgrade.m_cost;
            m_stage.Popups.Add(new CStringOffset(StaticFonts.Popup, m_upgrade.m_cost.ToString() + '$', Color.Red, Position, StaticConsts.Popup.CashTime, StaticConsts.Popup.CashDistance));

            this.m_damage = m_upgrade.m_damage;
            this.m_reload = m_upgrade.m_reload;
            this.m_range = m_upgrade.m_range;
            this.m_spr_tower = m_upgrade.m_spr_tower.DeepCopy();
            this.m_spr_stage = m_upgrade.m_spr_stage.DeepCopy();
            this.m_rotate_speed = m_upgrade.m_rotate_speed;
            this.m_bullet = m_upgrade.m_bullet.CopyModel();
            this.m_name = m_upgrade.m_name;
            this.m_cost = m_upgrade.m_cost;
            this.m_value += (int)(m_upgrade.m_cost * StaticConsts.Towers.SellPercent);

            if (m_upgrade.m_upgrade != null)
                this.m_upgrade = m_upgrade.m_upgrade.CopyModel();
            else
                this.m_upgrade = null;
            this.Position = pos;
        }
        public virtual void Sell()
        {
            m_stage.Money += m_value;
            m_stage.Popups.Add(new CStringOffset(StaticFonts.Popup, m_value.ToString() + '$', Color.Green, Position, StaticConsts.Popup.CashTime, StaticConsts.Popup.CashDistance));
            m_is = false;
        }

        protected virtual void Rotate( GameTime gameTime )
        {
            if (m_target == null || freeze_rotate)
                return;

            float kat = MyFunctions.Angle(this.Position, m_target.Position);
            float roznica = kat - m_spr_tower.m_rotate;
            if (roznica <= -180)
                roznica += 360;
            if (roznica >= 180)
                roznica -= 360;


            float ruch = (float)(m_rotate_speed * gameTime.ElapsedGameTime.TotalSeconds);

            if (roznica > 0)
                m_spr_tower.m_rotate += roznica > ruch ? ruch : roznica;
            if (roznica < 0)
                m_spr_tower.m_rotate -= roznica / -1 > ruch ? ruch : roznica / -1;


            if (m_spr_tower.m_rotate >= 360)
                m_spr_tower.m_rotate -= 360;
            if (m_spr_tower.m_rotate < 0)
                m_spr_tower.m_rotate += 360;

            //roznica jest w przedziale -m_aim_error, a m_aim_error
            if (StaticConsts.Towers.MaxAimError / -1 <= roznica && roznica <= StaticConsts.Towers.MaxAimError)
                m_aim = true;
            else
                m_aim = false;
        }
        protected virtual void CheckTarget()
        {
            List<CEnemy> enemies = m_stage.GetEnemy(this.Position, m_range);
            if (enemies.Count() <= 0)
            {    //nie ma żadnego przeciwnika w zasięgu
                m_target = null;
            }
            else
            {
                m_target = enemies.First();
            }
        }
        public virtual void Shoot(GameTime gameTime)
        {
            if (m_target == null)
                return; //brak przeciwnika
            double now = gameTime.TotalGameTime.TotalSeconds;
            if (now < m_lastshoot)
                return; //jeszcze nie przeładował
            if (!freeze_rotate && !m_aim)
                return; //wieżyczka nie jest skierowana na przeciwnika

            //No! można strzelać! :)
            m_stage.Bullets.Add(m_bullet.Create(this.Position, m_target, m_stage));

            //przeładowanie
            m_lastshoot = now +  m_reload ;    //określa czas następnego strzału
        }
        public void AddTimeOffset( double offset )
        {   //dodaje wieżyczką opóźnienia czasu następnego strzału (jeśli zatrzymaliśmy grę, np. przez menu)
            this.m_lastshoot += offset; //ostatni strzał
        }

    }
    public class CLasserTower : CTower
    {
        protected bool shooted;
        protected CLasser lasserBullet;
        protected CLasser m_bullet;
        protected double lostTarget;

        protected CLasserTower() //konstruktor podstawowy
            : base()
        {
            this.shooted = false;
            this.lasserBullet = null;
            this.lostTarget = 0;
        }
        public CLasserTower( int damage, float range, float check, CSprite spr_tower, CSprite spr_stage, float rotate_speed, CLasser Bullet, CTower upgrade, string name, string desc, int cost ) //konstruktor do tworzenia modelu
            : base( damage, 0, range, spr_tower, spr_stage, rotate_speed, Bullet, upgrade, name, desc, cost )
        {
            this.m_reload = check;
            this.m_bullet = Bullet;
        }
        public CLasserTower( int damage, float range, float check, CSprite spr_tower, CSprite spr_stage, float rotate_speed, CLasser Bullet, CTower upgrade, string name, string desc, int cost, CStage stage ) //pełny konstruktor
            : this( damage, range, check, spr_tower, spr_stage, rotate_speed, Bullet, upgrade, name, desc, cost )
        {
            this.m_stage = stage;
        }
        public CLasserTower( CLasserTower model, Vector2 position, CStage stage )   //tworzenie obiektu z modelu
            : this( model.m_damage, model.m_range, model.m_reload, model.m_spr_tower, model.m_spr_stage, model.m_rotate_speed, model.m_bullet, model.m_upgrade, model.m_name, model.m_description, model.m_cost, stage )
        {
            this.m_spr_stage.m_position = this.m_spr_tower.m_position = position;
            this.freeze_rotate = model.freeze_rotate;
        }
        public CLasserTower( CLasserTower obj ) //konstruktor kopiujący
            : this( obj.m_damage, obj.m_range, obj.m_reload, obj.m_spr_tower, obj.m_spr_stage, obj.m_rotate_speed, obj.m_bullet, obj.m_upgrade, obj.m_name, obj.m_description, obj.m_cost, obj.m_stage )
        { this.freeze_rotate = obj.freeze_rotate; }
        public override CTower CopyModel() //służy do kopiowania modelu (różni się od konstruktora kopiującego przede wszystkim brakiem referencji na CStage)
        {
            CLasserTower ret = new CLasserTower( this.m_damage, this.m_range, this.m_reload, this.m_spr_tower, this.m_spr_stage, this.m_rotate_speed, this.m_bullet, this.m_upgrade, this.m_name, this.m_description, this.m_cost );
            ret.freeze_rotate = this.freeze_rotate;
            return ret;
        }
        public override CTower Create( Vector2 position, CStage stage )
        {
            return new CLasserTower( this, position, stage );
        }

        public override void Update( GameTime gameTime )
        {
            if( lasserBullet != null )
                lasserBullet.Update( gameTime );
            LasserCheckTarget( gameTime );
            base.Update( gameTime );
        }
        public override void Draw( SpriteBatch spriteBatch, GameTime gameTime )
        {
            if( m_target != null )
                m_spr_tower.SetState( 2 );
            else
                m_spr_tower.SetState( 1 );
            //nie można skorzystać z funkcji bazowej, gdyż chcę, by laser był rysowany pomiędzy spritesem podstawy, a spritesem samej wieżyczki
            if( m_clicked )
            {
                Rectangle rec = new Rectangle( ( int )( m_spr_tower.m_position.X - m_range ), ( int )( m_spr_tower.m_position.Y - m_range ), ( int )m_range * 2, ( int )m_range * 2 );
                spriteBatch.Draw( StaticTextures.Range, rec, Color.Blue );
            }

            if( m_clicked )
                DrawRange( spriteBatch, gameTime );
            //MyFunctions.DrawCircle(spriteBatch, m_spr_tower.m_position, m_range, 32, 6, Color.Red);

            m_spr_stage.Draw( spriteBatch, gameTime );
            if( lasserBullet != null )
            {
                lasserBullet.Draw( spriteBatch, gameTime );
                //spriteBatch.DrawString( StaticFonts.Code, lasserBullet.powerpercent.ToString(), new Vector2( Position.X, Position.Y + 5 ), Color.White );
            }
            m_spr_tower.Draw( spriteBatch, gameTime );
        }
        protected override void CheckTarget()
        {   //dla tego typu wieżyczek trzeba się pozbyć tej metody, w zamian używa się LasserCheckTarget(GameTime gameTime;)
            return;
        }
        protected void LasserCheckTarget(GameTime gameTime)
        {
            double now = gameTime.TotalGameTime.TotalSeconds;
            if( m_target != null && (Vector2.Distance( m_target.Position, Position ) > m_range || !m_target.Check()) )
            {
                this.m_target = null;
                this.lostTarget = now;
            }

            if( this.m_target == null )
            {
                if( now < lostTarget +  m_reload )
                    return;

                List<CEnemy> enemies = m_stage.GetEnemy( this.Position, m_range );
                if( enemies.Count() > 0 )
                {
                    m_target = enemies.Last();
                }

                if( lasserBullet != null )
                {
                    lasserBullet.m_target = m_target;
                }
            }

            if( lasserBullet != null && !m_aim )
                lasserBullet.m_target = null;

        }
        public override void Shoot( GameTime gameTime )
        {
            if( !freeze_rotate && !m_aim )
                return; //wieżyczka nie jest skierowana na przeciwnika

            if( lasserBullet == null && m_target != null )  //jeśli strzela poraz pierwszy, tworzy się obiekt lasera
            {
                lasserBullet = m_bullet.Create(Position, null, m_stage);
            }

            if( m_target == null && lasserBullet != null )
            {   //brak przeciwnika, trzeba to powiedzieć pociskowi
                lasserBullet.m_target = null;
                return; //brak przeciwnika
            }

            if( m_target != null && lasserBullet != null )
            {
                lasserBullet.m_target = m_target;
            }
        }
        public override void Upgrade()
        {
            Vector2 pos = this.Position;
            m_stage.Money -= m_upgrade.m_cost;
            m_stage.Popups.Add( new CStringOffset( StaticFonts.Popup, m_upgrade.m_cost.ToString() + '$', Color.Red, Position, StaticConsts.Popup.CashTime, StaticConsts.Popup.CashDistance ) );

            this.m_damage = m_upgrade.m_damage;
            this.m_reload = m_upgrade.m_reload;
            this.m_range = m_upgrade.m_range;
            this.m_spr_tower = m_upgrade.m_spr_tower.DeepCopy();
            this.m_spr_stage = m_upgrade.m_spr_stage.DeepCopy();
            this.m_rotate_speed = m_upgrade.m_rotate_speed;
            this.m_name = m_upgrade.m_name;
            this.m_cost = m_upgrade.m_cost;
            this.m_value += ( int )( m_upgrade.m_cost * StaticConsts.Towers.SellPercent );
            this.m_bullet = (CLasser)m_upgrade.m_bullet.DeepCopy();
            this.lasserBullet = null;
            

            if( m_upgrade.m_upgrade != null )
                this.m_upgrade = m_upgrade.m_upgrade.CopyModel();
            else
                this.m_upgrade = null;
            this.Position = pos;
        }
    }

    public class CBullet : CGameObject
    {
        protected CSprite m_sprite;    //tekstura pocisku
        protected CEnemy m_target;   //przeciwnik
        protected Vector2 m_Vtarget;   //współrzędne, w kierunku których leci pocisk
        protected Vector2 m_start;    //współrzędne punktu, z którego został wystrzelony
        protected Color m_color;  //kolor pocisku

        protected float m_rotate { get { return m_sprite.m_rotate; } set { m_sprite.m_rotate = value; } } //obrót pocisku
        protected float Scale { get { return m_sprite.m_scale; } set { m_sprite.m_scale = value; } }
        protected float m_speed;  //prędkość pocisku
        protected int m_damage;  //obrażenia pocisku
        protected CStage m_stage;   //referencja na plansze
        public CEffect effect;  //efekt, jaki dostanie przeciwnik po oberwaniu

        public Vector2 m_position   //pozycja połączona z m_sprite.m_position
        {
            get { return m_sprite.m_position; }
            set { m_sprite.m_position = value; }
        }
        public bool m_is;   //czy ten pocisk jeszcze jest
        public List<string> m_logs;

        protected CBullet() //podstawowy konstruktor
        {
            this.m_color = Color.White;
            this.m_is = true;
            this.m_logs = new List<string>();
            this.effect = null;
        }
        public CBullet(CSprite sprite, float speed, int damage) //konstruktor do tworzenia modelu pocisku
            : this()
        {
            this.m_damage = damage;
            this.m_speed = speed;
            this.m_sprite = sprite.DeepCopy();
        }
        public CBullet(Vector2 position, CEnemy target, CSprite sprite, float speed, int damage, CStage stage) //konstruktor do tworzenia całego obiektu
            : this(sprite, speed, damage)
        {
            this.m_sprite.m_position = m_start = position;
            this.m_stage = stage;

            if (target != null)
            {
                this.m_target = target;
                this.m_Vtarget = m_target.Position;
            }
            else
            {
                this.m_target = null;
                this.m_Vtarget = Vector2.Zero;
            }
        }
        public CBullet(CBullet model, Vector2 position, CEnemy target, CStage stage) //konstruktor do tworzenia obiektu z modelu
            : this(position, target, model.m_sprite, model.m_speed, model.m_damage, stage) { }
        public CBullet(CBullet obiekt)  //konstruktor kopiujący
            : this(obiekt.m_position, obiekt.m_target, obiekt.m_sprite, obiekt.m_speed, obiekt.m_damage, obiekt.m_stage) { }

        public virtual CBullet DeepCopy()
        {
            return new CBullet(this);
        }
        public virtual CBullet CopyModel()
        {
            return new CBullet(m_sprite.DeepCopy(), m_speed, m_damage);
        }
        public virtual CBullet Create(Vector2 position, CEnemy target, CStage stage)
        {
            return new CBullet(this, position, target, stage);
        }

        public override void Update(GameTime gameTime)
        {
            m_logs.Clear();

            m_Vtarget = m_target.Position;
            Rotate();
            Move(gameTime);
            CheckCollision(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            m_sprite.Draw(spriteBatch, gameTime);
        }
        public override bool Check()
        {
            return m_is;
        }

        protected virtual void Rotate()
        {
            m_rotate = MyFunctions.Angle(m_position, m_Vtarget);
        }
        protected virtual void Move( GameTime gameTime )
        {
            //przenoszenie się w kierunku m_target
            double time = gameTime.ElapsedGameTime.TotalSeconds;
            double droga = Vector2.Distance(m_sprite.m_position, m_Vtarget);

            double percent = m_speed * time / droga;
            if (percent > 1)
                percent = 1;
            m_sprite.m_position = Vector2.Lerp(m_sprite.m_position, m_Vtarget, (float)(percent));

            //jeśli pocisk znajduje się w mienszej odległości od przeciwnika, niż jego promień
            if (Vector2.Distance(m_sprite.m_position, m_Vtarget) == 0f)
            { Destroy(); }
        }

        protected virtual void CheckCollision(GameTime gameTime)
        {
            List<CEnemy> result = m_stage.GetEnemy(m_position, StaticConsts.Towers.BulletSize);
            if (result.Count() > 0)
                Hit(result.First(), gameTime);
        }
        protected virtual void Destroy()
        {
            m_is = false;
            return;
        }
        protected virtual void Hit(CEnemy enemy, GameTime gameTime)
        {
            enemy.Attacked(m_damage);
            if( effect != null )
                enemy.AddEffect( gameTime, effect.Create( enemy ) );
            Destroy();
        }
    }
    public class CRocket : CBullet
    {
        protected float m_boom_range;
        protected int m_boom_damage;

        protected CRocket()
            : base()
        {
            this.m_boom_range = 1f;
            this.m_boom_damage = 1;
        }

        public CRocket(CSprite sprite, float speed, int damage, float boom_range, int boom_damage) //konstruktor do tworzenia modelu pocisku
            : this()
        {
            this.m_damage = damage;
            this.m_speed = speed;
            this.m_sprite = sprite.DeepCopy();
            this.m_boom_range = boom_range;
            this.m_boom_damage = boom_damage;
        }

        public CRocket(Vector2 position, CEnemy target, CSprite sprite, float speed, int damage, float boom_range, int boom_damage, CStage stage) //konstruktor do tworzenia całego obiektu
            : this(sprite, speed, damage, boom_range, boom_damage)
        {
            this.m_sprite.m_position = m_start = position;
            this.m_stage = stage;
            if (target != null)
            {
                this.m_target = target;
                this.m_Vtarget = m_target.Position;
            }
            else
            {
                this.m_target = null;
                this.m_Vtarget = Vector2.Zero;
            }
        }
        public CRocket(CRocket model, Vector2 position, CEnemy target, CStage stage) //konstruktor do tworzenia obiektu z modelu
            : this(position, target, model.m_sprite, model.m_speed, model.m_damage, model.m_boom_range, model.m_boom_damage, stage) { }
        public CRocket(CRocket obiekt)  //konstruktor kopiujący
            : this(obiekt.m_position, obiekt.m_target, obiekt.m_sprite, obiekt.m_speed, obiekt.m_damage, obiekt.m_boom_range, obiekt.m_boom_damage, obiekt.m_stage) { this.effect = obiekt.effect; }

        public override CBullet DeepCopy()
        {
            return new CRocket(this);
        }
        public override CBullet CopyModel()
        {
            CRocket ret = new CRocket(m_sprite, m_speed, m_damage, m_boom_range, m_boom_damage);
            ret.effect = effect;
            return ret;
        }
        public override CBullet Create(Vector2 position, CEnemy target, CStage stage)
        {
            CRocket ret = new CRocket(this, position, target, stage);
            ret.effect = effect;
            return ret;
        }

        protected override void Hit(CEnemy enemy, GameTime gameTime)
        {
            m_stage.Details.Add(new CAnimation(StaticSprites.Explode, m_position));
            List<CEnemy> Aoe = m_stage.GetEnemy(m_position, m_boom_range);

            enemy.Attacked(m_damage);
            foreach (CEnemy enem in Aoe)
            {
                enem.Attacked(m_boom_damage);
            }
            if( effect != null)
                for( int i = 0; i < Aoe.Count; ++i )
                {
                    if( Aoe[i] != null )
                        Aoe[i].AddEffect( gameTime, effect.Create( Aoe[i] ) );
                }
            Destroy();
        }
    }
    public class CFlame : CBullet
    {
        protected float fire_size; //rozmiar płomienia
        protected float fire_distance;  //jak daleko leci płomień
        protected double lasthit;   //kiedy ostatnio uderzył

        protected CFlame()
            : base()
        {
            this.fire_size = 1f;
            this.fire_distance = 1f;
        }
        public CFlame( CSprite sprite, float speed, int damage, float size, float distance ) //konstruktor do tworzenia modelu pocisku
            : this()
        {
            this.m_damage = damage;
            this.m_speed = speed;
            this.m_sprite = sprite.DeepCopy();
            this.fire_size = size;
            this.fire_distance = distance;
            this.lasthit = 0;
        }
        public CFlame( Vector2 position, CEnemy target, CSprite sprite, float speed, int damage, float size, float distance, CStage stage ) //konstruktor do tworzenia całego obiektu
            : this( sprite, speed, damage, size, distance )
        {
            this.m_sprite.m_position = m_start = position;
            this.m_stage = stage;
            if( target != null )
            {
                this.m_target = target;
                float angle = MyFunctions.Angle( m_start, m_target.Position );
                this.m_Vtarget = MyFunctions.CirclePoint( m_start, fire_distance, 360, ( int )( angle > 90 ? angle - 90 : 360 - ( 90 - angle ) ) );
                //niech cel będzie odrobinkę losowy
                this.m_Vtarget.X += MyFunctions.NextFloat( m_stage.Random, StaticConsts.Towers.FlameRandom );
                this.m_Vtarget.Y += MyFunctions.NextFloat( m_stage.Random, StaticConsts.Towers.FlameRandom );
                float dist = Vector2.Distance( m_start, m_Vtarget );
                int lol = ( int )dist;

                this.m_rotate = angle;
            }
            else
            {
                this.m_target = null;
                this.m_Vtarget = Vector2.Zero;
            }
        }
        public CFlame( CFlame model, Vector2 position, CEnemy target, CStage stage ) //konstruktor do tworzenia obiektu z modelu
            : this( position, target, model.m_sprite, model.m_speed, model.m_damage, model.fire_size, model.fire_distance, stage ) { }
        public CFlame( CFlame obiekt )  //konstruktor kopiujący
            : this( obiekt.m_position, obiekt.m_target, obiekt.m_sprite, obiekt.m_speed, obiekt.m_damage, obiekt.fire_size, obiekt.fire_distance, obiekt.m_stage ) { this.effect = obiekt.effect; }

        public override CBullet DeepCopy()
        {
            return new CFlame( this );
        }
        public override CBullet CopyModel()
        {
            CFlame ret = new CFlame( m_sprite, m_speed, m_damage, fire_size, fire_distance );
            ret.effect = effect;
            return ret;
        }
        public override CBullet Create( Vector2 position, CEnemy target, CStage stage )
        {
            CFlame ret = new CFlame( this, position, target, stage );
            ret.effect = effect;
            ret.fire_distance = fire_distance;
            ret.fire_size = fire_size;
            
            return ret;
        }

        public override void Update( GameTime gameTime )
        {
            m_logs.Clear();

            Move( gameTime );
            CheckCollision( gameTime );
        }
        protected override void Move( GameTime gameTime )
        {
            base.Move( gameTime );

            if( Vector2.Distance( m_start, m_position ) > fire_distance )
                Destroy();
        }
        protected override void CheckCollision( GameTime gameTime )
        {
            List<CEnemy> result = m_stage.GetEnemy( m_position, StaticConsts.Towers.BulletSize );
            foreach( CEnemy enem in result )
            {
                if( enem != null ) //ostrożności nigdy za wiele
                    Hit( enem, gameTime );
            }
        }
        protected override void Hit( CEnemy enemy, GameTime gameTime )
        {
            double now = gameTime.TotalGameTime.TotalSeconds;
            if( now < lasthit + StaticConsts.Towers.FlameTick )
                return;
            lasthit = now;

            enemy.Attacked( m_damage );
            if( effect != null )
                enemy.AddEffect( gameTime, effect.Create( enemy ) );
        }
    }
    public class CThunder : CBullet
    {
        protected float range;
        protected List<CEnemy> atacked;

        protected CThunder()
            : base()
        {
            this.range = 0f;
            this.atacked = new List<CEnemy>();
        }
        public CThunder( CSprite sprite, float speed, int damage, float range ) //konstruktor do tworzenia modelu pocisku
            : this()
        {
            this.range = range;
            this.m_damage = damage;
            this.m_speed = speed;
            this.m_sprite = sprite.DeepCopy();
            this.Scale = 0f;
        }
        public CThunder( Vector2 position, CEnemy target, CSprite sprite, float speed, int damage, float range, CStage stage ) //konstruktor do tworzenia całego obiektu
            : this( sprite, speed, damage, range )
        {
            this.m_sprite.m_position = m_start = this.m_Vtarget = position;
            this.m_stage = stage;
            if( target != null )
            {
                this.m_target = target;
            }
            else
            {
                this.m_target = null;
                this.m_Vtarget = Vector2.Zero;
            }
        }
        public CThunder( CThunder model, Vector2 position, CEnemy target, CStage stage ) //konstruktor do tworzenia obiektu z modelu
            : this( position, target, model.m_sprite, model.m_speed, model.m_damage, model.range, stage ) { }
        public CThunder( CThunder obiekt )  //konstruktor kopiujący
            : this( obiekt.m_position, obiekt.m_target, obiekt.m_sprite, obiekt.m_speed, obiekt.m_damage, obiekt.range, obiekt.m_stage ) { this.effect = obiekt.effect; }

        public override CBullet DeepCopy()
        {
            return new CThunder( this );
        }
        public override CBullet CopyModel()
        {
            CThunder ret = new CThunder( m_sprite, m_speed, m_damage, range );
            ret.effect = effect;
            return ret;
        }
        public override CBullet Create( Vector2 position, CEnemy target, CStage stage )
        {
            CThunder ret = new CThunder( this, position, target, stage );
            ret.effect = effect;
            return ret;
        }

        public override void Update( GameTime gameTime )
        {
            Move( gameTime );
            CheckCollision( gameTime );
        }
        protected override void Hit( CEnemy enemy, GameTime gameTime )
        {
            if( atacked != null )
                foreach( CEnemy enem in atacked )
                    if( enem.Equals( enemy ) )
                        return;
                    else
                        atacked.Add( enem );

            enemy.Attacked( m_damage );
            if( effect != null )
                enemy.AddEffect( gameTime, effect.Create( enemy ) );
        }
        protected override void Move( GameTime gameTime )
        {
            double time = gameTime.ElapsedGameTime.TotalSeconds;
            float size = (float)(m_speed * time);
            float scale = size / m_sprite.FrameSize.X;
            Scale += scale;
            

            if( m_sprite.FrameSize.X *Scale / 2 >= range )
            { Destroy(); }
        }
        protected override void CheckCollision( GameTime gameTime )
        {
            List<CEnemy> Aoe = m_stage.GetEnemy( m_position, range * 2 );
            foreach( CEnemy enem in Aoe )
            {
                float dist = Vector2.Distance( enem.Position, m_position );
                float roznica = Math.Max( dist, m_sprite.Width * Scale / 2 ) - Math.Min( dist, m_sprite.Width * Scale / 2 );
                if( roznica <= StaticConsts.Towers.Thunderthickness )
                    Hit( enem, gameTime );
            }
        }
    }
    public class CLasser : CBullet
    {
        public CEnemy m_target;   //przeciwnik
        protected double lastTick;
        protected int beamTickness;
        public float powerpercent;
        protected Line line;
        public Color[] Colors = new Color[3];

        public Vector2 m_position   //pozycja połączona z m_sprite.m_position
        {
            get { return m_start; }
            set { line.p1 = m_start = value; }
        }

        protected CLasser()
            : base()
        {
            this.powerpercent = StaticConsts.Towers.LasserMinPower;
            this.line = new Line( Vector2.Zero, Vector2.Zero, StaticConsts.Towers.LasserMinTickness, Color.White );
            this.lastTick = 0;
        }
        public CLasser( int damage, Color[] colors ) //konstruktor do tworzenia modelu
            : this()
        {
            this.m_damage = damage;
            this.Colors = colors;
            //this.m_sprite = sprite.DeepCopy();
        }
        public CLasser( Vector2 position, CEnemy target, int damage, Color[] colors, CStage stage ) //konstruktor do tworzenia całego obiektu
            : this( damage, colors )
        {
            this.m_position = m_start = position;
            this.m_stage = stage;
            //this.line.p1 = position;
            if( target != null )
            {
                this.m_target = target;
                this.m_Vtarget = target.Position;
            }
            else
            {
                this.m_target = null;
                this.m_Vtarget = Vector2.Zero;
            }
        }
        public CLasser( CLasser model, Vector2 position, CEnemy target, CStage stage ) //konstruktor do tworzenia obiektu z modelu
            : this( position, target, model.m_damage, model.Colors, stage ) { }
        public CLasser( CLasser obiekt )  //konstruktor kopiujący
            : this( obiekt.m_position, obiekt.m_target, obiekt.m_damage, obiekt.Colors, obiekt.m_stage ) { this.effect = obiekt.effect; }

        public override CBullet DeepCopy()
        {
            return new CLasser( this );
        }
        public CLasser CopyModel()
        {
            CLasser ret = new CLasser( m_damage, Colors );
            ret.effect = this.effect;
            ret.Colors = this.Colors;
            return ret;
        }
        public CLasser Create( Vector2 position, CEnemy target, CStage stage )
        {
            CLasser ret = new CLasser( this, position, target, stage );
            ret.effect = this.effect;
            ret.Colors = this.Colors;
            return ret;
        }

        public override void Update( GameTime gameTime )
        {
            m_logs.Clear();

            if( m_target != null)
                line.p2 = m_Vtarget = m_target.Position;
            line.Update( gameTime );
            Hit( m_target, gameTime );
        }
        public override void Draw( SpriteBatch spriteBatch, GameTime gameTime )
        {
            if( m_target == null )
                return;
            //sprawdzenie koloru lasera
            CheckColor();
            //obliczanie grubości lasera
            CheckTickness();
            //rysowanie lini
            line.Draw( spriteBatch, gameTime );
        }
        protected virtual void Hit( CEnemy enemy, GameTime gameTime )
        {
            double now = gameTime.TotalGameTime.TotalSeconds;
            //czy już minął czas od ostatniego uderzenia?
            if( lastTick + StaticConsts.Towers.LasserTick  > now )
                return;
            lastTick = now;
            //sprawdzanie istnienia przeciwnika i zmniejszanie mocy
            if( enemy == null )
            {
                if( powerpercent > StaticConsts.Towers.LasserMinPower )
                    powerpercent -= StaticConsts.Towers.LasserPowerSubSpeed;
                if( powerpercent < StaticConsts.Towers.LasserMinPower )
                    powerpercent = StaticConsts.Towers.LasserMinPower;
                return;
            }
            //zwiększanie mocy lasera
            if( powerpercent < 1 )
                powerpercent += StaticConsts.Towers.LasserPowerAddSpeed;
            if( powerpercent > 1 )
                powerpercent = 1;
            //obliczanie prawdziwych obrażeń
            int trueDamage = (int)(m_damage * powerpercent);
            if( trueDamage <= 0 )
                trueDamage = 1;
            //atakowanie wroga
            enemy.Attacked( trueDamage );
            //dodawanie efektu strzału
            if( effect != null )
                enemy.AddEffect( gameTime, effect.Create( enemy ) );
            //Destroy();
        }
        protected void CheckColor()
        {
            int numOfColors = Colors.Count();   //pobieranie ilości kolorów
            float przedzial = (float)1 / numOfColors;  //co ile procent powinien się zmienić kolor
            int index = (int)( powerpercent / przedzial);
            line.color = Colors[index];
        }
        protected void CheckTickness()
        {
            int roznica = StaticConsts.Towers.LasserMaxTickness - StaticConsts.Towers.LasserMinTickness;
            int add = ( int )( powerpercent * roznica );
            beamTickness = StaticConsts.Towers.LasserMinTickness + add;
            line.thickness = beamTickness;
        }
    }

    public abstract class CEffect
    {
        protected CEnemy unit;  //referencja na obiekt, na którym znajduje się dany efekt
        protected bool activated;   //czy obiekt jest obecnie włączony
        protected double time;  //czas trwania efektu
        protected double timeEnd;   //czas gry, w którym efekt się kończy
        protected string m_name;    //nazwa efektu (by móc go identyfikować)
        protected Color m_color;    //kolor przebarwienia sprites'a oraz paska informujacego

        protected CStage Stage { get { return unit.m_stage; } }

        public bool Lock;
        public string Name { get { return m_name; } }   //ustawienie pozwalające na odczytanie nazwy efektu

        public CEffect(CEnemy unit, double time, string name)   //pełny konstruktor
            : this(time, name)
        {
            this.unit = unit;
            this.activated = false;
            this.Lock = false;
            this.m_color = Color.White;
        }
        public CEffect(double time, string name)    //konstruktor do modelu
        {
            this.time = time;
            this.m_name = name;
        }
        public CEffect(CEffect model, CEnemy unit)  //konstruktor do tworzenia z modelu
            : this(unit, model.time, model.m_name) { }
        public CEffect(CEffect obj) //konstruktor kopiujący
            : this(obj.unit, obj.time, obj.m_name) { }

        public abstract CEffect Create( CEnemy enemy );
        public abstract CEffect DeepCopy();

        public virtual void Refresh( GameTime gameTime )
        {
            double now = gameTime.TotalGameTime.TotalSeconds;
            if( now >= timeEnd )
                Lock = false;
            else
                timeEnd = now + time;   //ustalenie czasu końca
        }
        public virtual void Draw( SpriteBatch spriteBatch, GameTime gameTime, int index )
        {
            Vector2 LeftTop = new Vector2();
            LeftTop.Y = unit.Position.Y - unit.TextureSize.Y / 2;
            LeftTop.X = unit.Position.X - unit.TextureSize.X / 2;

            double now = gameTime.TotalGameTime.TotalSeconds; //pobranie obecnej sekundy

            float percent = ( float )( ( timeEnd - now ) / time );    //ułamek reprezentujący pozostały czas (1=start, 0=end)
            int barheight = ( int )( unit.TextureSize.Y * percent );    //wyosokość paska
            int roznica = ( int )unit.TextureSize.Y - barheight;    //roznica wysokosci spritesa i wysokosci paska
            int x = ( int )LeftTop.X - StaticConsts.Effects.effb_offset - StaticConsts.Effects.effb_width;  //pozycja paska o indeksie 0
            x -= index * ( StaticConsts.Effects.effb_offset + StaticConsts.Effects.effb_width );    //obliczanie daljszej pozycji (jesli index=0, nic nie robi)
            Rectangle bar = new Rectangle( x, ( int )LeftTop.Y + roznica, StaticConsts.Effects.effb_width, barheight );
            spriteBatch.Draw( StaticTextures.Dot, bar, m_color );
        }
        public virtual void Start( GameTime gameTime )
        {
            double now = gameTime.TotalGameTime.TotalSeconds; //pobranie obecnej sekundy
            timeEnd = now + time;   //ustalenie czasu końca
            activated = true;   //zakwitowanie odpalenia efektu

            if( unit.Color == Color.White )
                unit.Color = m_color;
        }
        public virtual bool Update( GameTime gameTime )
        {
            //jeśli efekt nie jest jeszcze włączony, włącza go
            if( !activated && !Lock )
                Start( gameTime );

            //pobranie czasu
            double now = gameTime.TotalGameTime.TotalSeconds;

            //jeśli minął odpowiedni czas, zakończ efekt
            if( now >= timeEnd )
                End();

            //zmiana koloru unita, jeśli zwolnił się po użyciu przez inny efekt
            if( activated && unit.Color == Color.White )
                unit.Color = m_color;

            return activated;
        }
        public virtual void End()
        {
            activated = false;  //wyłączenie efektu
            unit.Color = Color.White;
            Lock = true;
        }

        //'przechwycone' metody
        /// <summary>
        ///     NIE WOLNO UŻYWAĆ unit.Attacked WEWNĄTRZ TEJ FUNKCJI
        /// </summary>
        public virtual void HandleAttacked(int damage) { }
        public virtual void HandleKilled() { }
    }
    public class CSlow : CEffect
    {
        private float prewSpeed;
        private float power;

        public CSlow(CEnemy unit, double time, string name, float power)    //cały
            : base(unit, time, name)
        {
            this.power = power;
            this.m_color = StaticConsts.Effects.ColorSlow;
        }
        public CSlow( double time, string name, float power ) //model
            : base( time, name )
        {
            this.power = power;
            this.m_color = StaticConsts.Effects.ColorSlow;
        }
        public CSlow( CSlow model, CEnemy unit )  //z modelu
            : base( unit, model.time, model.m_name ) { this.power = model.power; }
        public CSlow(CSlow obj) //kopiujący
            : this(obj.unit, obj.time, obj.Name, obj.power) { }

        public override CEffect DeepCopy()
        {
            return new CSlow(this);
        }
        public override CEffect Create(CEnemy enemy)
        {
            return new CSlow(enemy, this.time, this.m_name, this.power);
        }
        public override void Start(GameTime gameTime)
        {
            double now = gameTime.TotalGameTime.TotalSeconds; //pobranie obecnej sekundy
            timeEnd = now + time;   //ustalenie czasu końca
            prewSpeed = unit.m_speed;   //zapisanie początkowej prędkośći jednostki
            unit.m_speed = prewSpeed * power;   //zmiana prędkości jednostki
            activated = true;   //zakwitowanie odpalenia efektu

            if( unit.Color == Color.White)
                unit.Color = m_color;
        }
        public override void End()
        {
            unit.m_speed = prewSpeed; //przywrócenie normalnej prędkości
            activated = false;  //wyłączenie efektu
            unit.Color = Color.White;
            Lock = true;
        }
    }
    public class CFire : CEffect
    {
        private const double tick = StaticConsts.Effects.fire_tick_time;
        private double lastTick;
        private int damage;

        public CFire( CEnemy unit, double time, string name, int damage )    //cały
            : base( unit, time, name )
        {
            this.damage = damage;
            this.m_color = StaticConsts.Effects.ColorFire;
            this.lastTick = 0;
        }
        public CFire( double time, string name, int damage ) //model
            : base( time, name )
        {
            this.damage = damage;
            this.m_color = StaticConsts.Effects.ColorFire;
            this.lastTick = 0;
        }
        public CFire( CFire model, CEnemy unit )  //z modelu
            : base( unit, model.time, model.m_name ) { this.damage = model.damage; }
        public CFire( CFire obj ) //kopiujący
            : this( obj.unit, obj.time, obj.Name, obj.damage ) { }

        public override CEffect DeepCopy()
        {
            return new CFire( this );
        }
        public override CEffect Create( CEnemy enemy )
        {
            return new CFire( enemy, this.time, this.m_name, this.damage );
        }
        public override bool Update( GameTime gameTime )
        {
            double now = gameTime.TotalGameTime.TotalSeconds;

            //jeśli minął czas ticku, zabierz hp
            if( now >= lastTick + tick )
            {
                //unit.Attacked( damage );
                unit.m_health -= damage;
                lastTick = now;
            }
            base.Update( gameTime );

            return activated;
        }
        public override void Start( GameTime gameTime )
        {
            base.Start( gameTime );
            this.lastTick = gameTime.TotalGameTime.TotalSeconds;
        }
    }
    public class CDamage : CEffect
    {
        private float prewSpeed;
        private float power;

        public CDamage( CEnemy unit, double time, string name, float power )    //cały
            : base( unit, time, name )
        {
            this.power = power;
            this.m_color = StaticConsts.Effects.ColorDamage;
        }
        public CDamage( double time, string name, float power ) //model
            : base( time, name )
        {
            this.power = power;
            this.m_color = StaticConsts.Effects.ColorDamage;
        }
        public CDamage( CDamage model, CEnemy unit )  //z modelu
            : base( unit, model.time, model.m_name ) { this.power = model.power; }
        public CDamage( CDamage obj ) //kopiujący
            : this( obj.unit, obj.time, obj.Name, obj.power ) { }

        public override CEffect DeepCopy()
        {
            return new CDamage( this );
        }
        public override CEffect Create( CEnemy enemy )
        {
            return new CDamage( enemy, this.time, this.m_name, this.power );
        }
        public override void HandleAttacked(int damage)
        {
            unit.m_health -= (int)(power * damage);
        }
        
    }
}