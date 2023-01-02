using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TowerDefence
{
    public static class StaticFonts     //statyczna klasa zawierająca czcionki
    {
        public static SpriteFont Info;
        public static SpriteFont TowerInfo;
        public static SpriteFont Description;
        public static SpriteFont Popup;
        public static SpriteFont CopyRight;

        public static void Load(ContentManager Content)
        {
            Info = Content.Load<SpriteFont>("Fonts/Info");
            TowerInfo = Content.Load<SpriteFont>("Fonts/Towerinfo");
            Popup = Content.Load<SpriteFont>("Fonts/popup");
            Description = Content.Load<SpriteFont>( "Fonts/descriptions" );
            CopyRight = Content.Load<SpriteFont>( "Fonts/copyright" );
        }
    }
    public static class StaticTextures  //statyczna klasa zawierająca textury
    {
        public static Texture2D Dot;
        
        //mapy
        public static Texture2D Stage001;
        public static Texture2D Stage002;
        public static Texture2D Stage003;
        //koniec poziomu
        public static Texture2D win;
        public static Texture2D defeat;
        //przeciwnicy
        public static Texture2D Enemy_Normal;
        public static Texture2D Enemy_Slug;
        public static Texture2D Enemy_Fast;
        public static Texture2D Enemy_Fly;
        public static Texture2D Enemy_Boss;
        public static Texture2D Enemy_Bossfly;
        public static Texture2D Enemy_Spawner;
        public static Texture2D Enemy_Spawned;
        public static Texture2D Enemy_Teleporter;
        //efekty
        public static Texture2D Detail_Teleport;
        public static Texture2D Explode;
        //pociski
        public static Texture2D Bullet;
        public static Texture2D Bullet_Slow;
        public static Texture2D Rocket;
        public static Texture2D Flame;
        public static Texture2D Thunder;
        //wieżyczki
        public static Texture2D Tower_Gun1;
        public static Texture2D Tower_Gun2;
        public static Texture2D Tower_Gun3;
        public static Texture2D Tower_Rocket1;
        public static Texture2D Tower_Rocket2;
        public static Texture2D Tower_Slower;
        public static Texture2D Tower_Slower2;
        public static Texture2D Tower_Flamethrower;
        public static Texture2D Tower_Flamethrower2;
        public static Texture2D Tower_Pulsator;
        public static Texture2D Tower_Pulsator2;
        public static Texture2D Tower_Lasser_anim;
        public static Texture2D Tower_Lasser2_anim;
        public static Texture2D Range;
        public static Texture2D TowerStage;
        public static Texture2D TowerStagev2;
        //menu główne
        public static Texture2D Menu_Main_Background;
        public static Texture2D Menu_Border_Frame;
        public static Texture2D Menu_gamename;

        public static Texture2D Menu_Button_Stage001;
        public static Texture2D Menu_Button_Stage002;
        public static Texture2D Menu_Button_Stage003;

        public static Texture2D Menu_Button_Stage001f;
        public static Texture2D Menu_Button_Stage002f;
        public static Texture2D Menu_Button_Stage003f;
        public static Texture2D Menu_Button_Lock;

        public static class Buttons //tekstury wszelkich przycisków
        {
            //budowa wieżyczek
            public static Texture2D BuyTower;
            public static Texture2D BuyTower_f;
            public static Texture2D BuyTower_l;

            //ulepszanie/sprzedarz wieżyczek
            public static Texture2D Upgrade;
            public static Texture2D Upgrade_f;   //focus
            public static Texture2D Upgrade_l;   //lock
            public static Texture2D Upgrade_s;   //special

            public static Texture2D Sell;
            public static Texture2D Sell_f;   //focus
            public static Texture2D Sell_l;   //lock

            //start
            public static Texture2D Start;
            public static Texture2D Start_f;
            public static Texture2D Start_l;

            //powrót do menu
            public static Texture2D Menu;
            public static Texture2D Menu_f;

            //koniec gry
            public static Texture2D back_to_menu;
            public static Texture2D back_to_menu_f;
            public static Texture2D quit_the_game;
            public static Texture2D quit_the_game_f;

            //menu
            public static Texture2D Menu_Quit;
            public static Texture2D Menu_Quit_f;

            //menu podczasz rozgrywki
            public static Texture2D igm_BackToGame;
            public static Texture2D igm_BackToGame_f;
            public static Texture2D igm_BackToMenu;
            public static Texture2D igm_BackToMenu_f;
            public static Texture2D igm_Exit;
            public static Texture2D igm_Exit_f;
        }
        public static class Panels //panele, czyli wszystkie sztywne elementy na ekranie
        {
            public static Texture2D MainRight;
            public static Texture2D InfoBoxDual;
            public static Texture2D InfoBoxMono;
            public static Texture2D InGameMenu;
        }
        public static class Helper  //tabliczki używane przy samouczku
        {
            public static Texture2D Step1;
            public static Texture2D Step2;
            public static Texture2D Step3;
            public static Texture2D Step4;
            public static Texture2D Step5;
            public static Texture2D Step6;
            public static Texture2D Step7;
            public static Texture2D Step8;
            public static Texture2D Step9;
        }

        public static void Load(ContentManager Content)
        {
            Dot = Content.Load<Texture2D>("dot");
            Stage001 = Content.Load<Texture2D>( "Stages/stage001" );
            Stage002 = Content.Load<Texture2D>( "Stages/stage002" );
            Stage003 = Content.Load<Texture2D>( "Stages/stage003" );

            win = Content.Load<Texture2D>( "Interface/Stages/win2" );
            defeat = Content.Load<Texture2D>( "Interface/Stages/defeat2" );

            Enemy_Normal = Content.Load<Texture2D>( "Enemies/normal" );
            Enemy_Slug = Content.Load<Texture2D>( "Enemies/slug" );
            Enemy_Fast = Content.Load<Texture2D>( "Enemies/fast" );
            Enemy_Fly = Content.Load<Texture2D>( "Enemies/fly" );
            Enemy_Boss = Content.Load<Texture2D>( "Enemies/boss" );
            Enemy_Bossfly = Content.Load<Texture2D>( "Enemies/flyboss" );
            Enemy_Spawner = Content.Load<Texture2D>( "Enemies/spawner" );
            Enemy_Spawned = Content.Load<Texture2D>( "Enemies/spawned" );
            Enemy_Teleporter = Content.Load<Texture2D>( "Enemies/teleporter" );

            Detail_Teleport = Content.Load<Texture2D>( "Enemies/anim_teleport" );

            Bullet = Content.Load<Texture2D>("Bullets/bullet");
            Rocket = Content.Load<Texture2D>("Bullets/rocket_anim");
            Flame = Content.Load<Texture2D>( "Bullets/flame" );
            Bullet_Slow = Content.Load<Texture2D>("Bullets/bullet_slow");
            Thunder = Content.Load<Texture2D>( "Bullets/thunderv2" );

            Explode = Content.Load<Texture2D>("Bullets/explode");

            Tower_Gun1 = Content.Load<Texture2D>( "Towers/gun1v2" );
            Tower_Gun2 = Content.Load<Texture2D>( "Towers/gun2v2" );
            Tower_Gun3 = Content.Load<Texture2D>( "Towers/gun3" );
            Tower_Rocket1 = Content.Load<Texture2D>("Towers/tower_rocket_1v2");
            Tower_Rocket2 = Content.Load<Texture2D>("Towers/tower_rocket_2v2");
            Tower_Slower = Content.Load<Texture2D>("Towers/Slower");
            Tower_Slower2 = Content.Load<Texture2D>( "Towers/Slower2" );
            Tower_Flamethrower = Content.Load<Texture2D>( "Towers/TowerFlamethrowerv2" );
            Tower_Flamethrower2 = Content.Load<Texture2D>( "Towers/firebat2" );
            Tower_Pulsator = Content.Load<Texture2D>( "Towers/pulsatorv2" );
            Tower_Pulsator2 = Content.Load<Texture2D>( "Towers/pulsator2" );
            Tower_Lasser_anim  = Content.Load<Texture2D>( "Towers/lasserv2anim" );
            Tower_Lasser2_anim = Content.Load<Texture2D>( "Towers/lasser2anim" );

            Range = Content.Load<Texture2D>("Towers/range2");
            TowerStage = Content.Load<Texture2D>("Towers/TowerStage");
            TowerStagev2 = Content.Load<Texture2D>( "Towers/TowerStagev2" );

            Menu_Main_Background = Content.Load<Texture2D>( "Interface/Menu/menu_bg" );
            Menu_Border_Frame = Content.Load<Texture2D>( "Interface/Menu/menu_frame" );
            Menu_gamename = Content.Load<Texture2D>( "Interface/Menu/gamename" );

            Menu_Button_Stage001 = Content.Load<Texture2D>( "Stages/small/mstage001" );
            Menu_Button_Stage002 = Content.Load<Texture2D>( "Stages/small/mstage002" );
            Menu_Button_Stage003 = Content.Load<Texture2D>( "Stages/small/mstage003" );
            Menu_Button_Stage001f = Content.Load<Texture2D>( "Stages/small/mstage001_f" );
            Menu_Button_Stage002f = Content.Load<Texture2D>( "Stages/small/mstage002_f" );
            Menu_Button_Stage003f = Content.Load<Texture2D>( "Stages/small/mstage003_f" );
            Menu_Button_Lock = Content.Load<Texture2D>( "Stages/small/mstage_lock" );

            Panels.MainRight = Content.Load<Texture2D>( "Interface/Stages/PrawyPanel2" );
            Panels.InfoBoxDual = Content.Load<Texture2D>( "Interface/Stages/InfoboxDual" );
            Panels.InfoBoxMono = Content.Load<Texture2D>( "Interface/Stages/InfoboxMono" );
            Panels.InGameMenu = Content.Load<Texture2D>( "Interface/Stages/InGameMenuBg" );

            Buttons.BuyTower = Content.Load<Texture2D>( "Buttons/RightPanel/TowerBuy" );
            Buttons.BuyTower_f = Content.Load<Texture2D>( "Buttons/RightPanel/TowerBuy_f" );
            Buttons.BuyTower_l = Content.Load<Texture2D>( "Buttons/RightPanel/TowerBuy_l" );

            Buttons.Upgrade = Content.Load<Texture2D>( "Buttons/Upgrader/upgrade" );
            Buttons.Upgrade_f = Content.Load<Texture2D>( "Buttons/Upgrader/upgrade_f" );
            Buttons.Upgrade_l = Content.Load<Texture2D>( "Buttons/Upgrader/upgrade_l" );
            Buttons.Upgrade_s = Content.Load<Texture2D>( "Buttons/Upgrader/upgrade_s" );
            Buttons.Sell = Content.Load<Texture2D>( "Buttons/Upgrader/sell" );
            Buttons.Sell_f = Content.Load<Texture2D>( "Buttons/Upgrader/sell_f" );
            Buttons.Sell_l = Content.Load<Texture2D>( "Buttons/Upgrader/sell_l" );

            Buttons.Start = Content.Load<Texture2D>( "Buttons/Upgrader/start" );
            Buttons.Start_f = Content.Load<Texture2D>( "Buttons/Upgrader/start_f" );
            Buttons.Start_l = Content.Load<Texture2D>( "Buttons/Upgrader/start_l" );

            Buttons.Menu= Content.Load<Texture2D>( "Buttons/Other/menu" );
            Buttons.Menu_f = Content.Load<Texture2D>( "Buttons/Other/menu_f" );

            Buttons.back_to_menu = Content.Load<Texture2D>( "Buttons/GameOver/btm" );
            Buttons.back_to_menu_f = Content.Load<Texture2D>( "Buttons/GameOver/btm_f" );
            Buttons.quit_the_game = Content.Load<Texture2D>( "Buttons/GameOver/qtg" );
            Buttons.quit_the_game_f = Content.Load<Texture2D>( "Buttons/GameOver/qtg_f" );

            Buttons.Menu_Quit = Content.Load<Texture2D>( "Buttons/MMenu/b_quit" );
            Buttons.Menu_Quit_f = Content.Load<Texture2D>( "Buttons/MMenu/b_quit_f" );

            Buttons.igm_BackToGame = Content.Load<Texture2D>( "Buttons/InGameMenu/igm_BackToGame" );
            Buttons.igm_BackToGame_f = Content.Load<Texture2D>( "Buttons/InGameMenu/igm_BackToGame_f" );
            Buttons.igm_BackToMenu = Content.Load<Texture2D>( "Buttons/InGameMenu/igm_BackToMenu" );
            Buttons.igm_BackToMenu_f = Content.Load<Texture2D>( "Buttons/InGameMenu/igm_BackToMenu_f" );
            Buttons.igm_Exit = Content.Load<Texture2D>( "Buttons/InGameMenu/igm_Exit" );
            Buttons.igm_Exit_f = Content.Load<Texture2D>( "Buttons/InGameMenu/igm_Exit_f" );

            Helper.Step1 = Content.Load<Texture2D>( "Helper/step1" );
            Helper.Step2 = Content.Load<Texture2D>( "Helper/step2" );
            Helper.Step3 = Content.Load<Texture2D>( "Helper/step3" );
            Helper.Step4 = Content.Load<Texture2D>( "Helper/step4" );
            Helper.Step5 = Content.Load<Texture2D>( "Helper/step5" );
            Helper.Step6 = Content.Load<Texture2D>( "Helper/step6" );
            Helper.Step7 = Content.Load<Texture2D>( "Helper/step7" );
            Helper.Step8 = Content.Load<Texture2D>( "Helper/step8" );
            Helper.Step9 = Content.Load<Texture2D>( "Helper/step9" );
        }

    }
    public static class StaticSprites   //statyczna klasa zawierająca sprites'y
    {
        public static CAnimation    Enemy_Normal;
        public static CSprite       Enemy_Slug;
        public static CSprite       Enemy_fast;
        public static CSprite       Enemy_Fly;
        public static CSprite       Enemy_Boss;
        public static CSprite       Enemy_Bossfly;
        public static CAnimation    Enemy_Spawner;
        public static CSprite       Enemy_Spawned;
        public static CAnimation    Enemy_Teleporter;

        public static CAnimation Detail_Teleport;

        public static CSprite Bullet;
        public static CSprite Bullet_Slow;
        public static CAnimation Rocket;
        public static CSprite Flame;
        public static CAnimation Thunder;


        public static CAnimation Explode;
        public static CSprite Tower_Gun1;
        public static CSprite Tower_Gun2;
        public static CSprite Tower_Gun3;
        public static CSprite Tower_Slower;
        public static CSprite Tower_Slower2;
        public static CSprite Tower_Flamethrower;
        public static CSprite Tower_Flamethrower2;
        public static CSprite Tower_Rocket1;
        public static CSprite Tower_Rocket2;
        public static CSprite Tower_Pulsator;
        public static CSprite Tower_Pulsator2;
        public static CAnimation Tower_Lasser2_anim;
        public static CAnimation Tower_Lasser_anim;
        public static CSprite Range;
        public static CSprite TowerStagev2;

        public static void Load()
        {
            Enemy_Normal = new CAnimation(StaticTextures.Enemy_Normal, 4, 1);
            Enemy_Slug = new CSprite(StaticTextures.Enemy_Slug, 1);
            Enemy_fast = new CSprite( StaticTextures.Enemy_Fast, 1 );
            Enemy_Fly = new CSprite( StaticTextures.Enemy_Fly, 1 );
            Enemy_Boss = new CSprite( StaticTextures.Enemy_Boss, 1 );
            Enemy_Bossfly = new CSprite( StaticTextures.Enemy_Bossfly, 1 );
            Enemy_Spawner = new CAnimation( StaticTextures.Enemy_Spawner, 3, 1 );
            Enemy_Spawned = new CSprite( StaticTextures.Enemy_Spawned, 1 );
            Enemy_Teleporter = new CAnimation( StaticTextures.Enemy_Teleporter, 3, 1 );

            Detail_Teleport = new CAnimation( StaticTextures.Detail_Teleport, 5, 1 );
            Detail_Teleport.m_loop = false;

            Bullet = new CSprite(StaticTextures.Bullet, 1);
            Bullet_Slow = new CSprite(StaticTextures.Bullet_Slow, 1);
            Rocket = new CAnimation(StaticTextures.Rocket, 4, 1);
            Flame = new CSprite( StaticTextures.Flame, 1 );
            Thunder = new CAnimation( StaticTextures.Thunder, 4, 1 );


            Explode = new CAnimation(StaticTextures.Explode, 5, 1);
            Explode.m_loop = false;
            Tower_Gun1 = new CSprite(StaticTextures.Tower_Gun1, 1);
            Tower_Gun2 = new CSprite( StaticTextures.Tower_Gun2, 1 );
            Tower_Gun3 = new CSprite( StaticTextures.Tower_Gun3, 1 );
            Tower_Slower = new CSprite(StaticTextures.Tower_Slower, 1);
            Tower_Slower2 = new CSprite( StaticTextures.Tower_Slower2, 1 );
            Tower_Flamethrower = new CSprite( StaticTextures.Tower_Flamethrower, 1 );
            Tower_Flamethrower2 = new CSprite( StaticTextures.Tower_Flamethrower2, 1 );
            Tower_Rocket1 = new CSprite(StaticTextures.Tower_Rocket1, 1);
            Tower_Rocket2 = new CSprite(StaticTextures.Tower_Rocket2, 1);
            Tower_Pulsator = new CSprite( StaticTextures.Tower_Pulsator, 1 );
            Tower_Pulsator2 = new CSprite( StaticTextures.Tower_Pulsator2, 1 );
            Tower_Lasser_anim = new CAnimation( StaticTextures.Tower_Lasser_anim, 3, 2 );
            Tower_Lasser2_anim = new CAnimation( StaticTextures.Tower_Lasser2_anim, 3, 2 );
            Range = new CSprite(StaticTextures.Range, 1);
            TowerStagev2 = new CSprite( StaticTextures.TowerStagev2, 1 );

            Tower_Lasser_anim.m_framerate = 0.1;
        }
    }

    public static class StaticTowers    //statyczna klasa zawierająca wieżyczki
    {
        public static CTower Gun1;
        public static CTower Gun2;
        public static CTower Gun3;
        public static CTower Slower;
        public static CTower Slower2;
        public static CTower Flamethrower;
        public static CTower Flamethrower2;
        public static CTower Rocket1;
        public static CTower Rocket2;
        public static CTower Thunder;
        public static CTower Thunder2;
        public static CLasserTower Lasser;
        public static CLasserTower Lasser2;
        
        private static void init_Gun1()
        {
                //wieżyczka
            const string name = "Dzialo";
            const string desc = "Szybkostrzelna\nbron o duzym\npolu razenia";
            const int cost = 25;

            const int damage = 8;
            const float reload = 0.7f;
            const float range = 90f;
            const float rotate_speed = 2880; //pełen obrót w 1/8 sekundy
                //pocisk
            const float b_speed = 1190f;
            CSprite b_spr = StaticSprites.Bullet;
                //spritesy
            CSprite spr_tower = StaticSprites.Tower_Gun1;
            CSprite spr_stage = StaticSprites.TowerStagev2;

            CBullet pocisk = new CBullet(b_spr, b_speed, damage);
            CTower next = Gun2; //wieżyczka, w którą się ulepsza
            
            Gun1 = new CTower(damage, reload, range, spr_tower, spr_stage, rotate_speed, pocisk, next, name, desc, cost);
        }
        private static void init_Gun2()
        {
            //wieżyczka
            const string name = "Super Dzialo";
            const string desc = "Szybkostrzelna\nbron o duzym\npolu razenia";
            const int cost = 30;

            const int damage = 11;
            const float reload = 0.7f;
            const float range = 110f;
            const float rotate_speed = 2880; //pełen obrót w 1/8 sekundy
            //pocisk
            const float b_speed = 1190f;
            CSprite b_spr = StaticSprites.Bullet;
            //spritesy
            CSprite spr_tower = StaticSprites.Tower_Gun2;
            CSprite spr_stage = StaticSprites.TowerStagev2;

            CBullet pocisk = new CBullet( b_spr, b_speed, damage );
            CTower next = Gun3; //wieżyczka, w którą się ulepsza

            Gun2 = new CTower( damage, reload, range, spr_tower, spr_stage, rotate_speed, pocisk, next, name, desc, cost );
        }
        private static void init_Gun3()
        {
            //wieżyczka
            const string name = "Super Turbo Dzialo";
            const string desc = "Szybkostrzelna\nbron o duzym\npolu razenia";
            const int cost = 30;

            const int damage = 24;
            const float reload = 0.9f;
            const float range = 170f;
            const float rotate_speed = 2880; //pełen obrót w 1/8 sekundy
            //pocisk
            const float b_speed = 1190f;
            CSprite b_spr = StaticSprites.Bullet;
            //spritesy
            CSprite spr_tower = StaticSprites.Tower_Gun3;
            CSprite spr_stage = StaticSprites.TowerStagev2;

            CBullet pocisk = new CBullet( b_spr, b_speed, damage );
            CTower next = null; //wieżyczka, w którą się ulepsza

            Gun3 = new CTower( damage, reload, range, spr_tower, spr_stage, rotate_speed, pocisk, next, name, desc, cost );
        }
        private static void init_Slower()
        {
            //wieżyczka
            const string name = "Spowalniacz";
            const string desc = "Bron biologiczna,\nktora spowalnia\nwrogow";
            const int cost = 30;

            const int damage = 3;
            const float reload = 1.3f;
            const float range = 90f;
            const float rotate_speed = 2880; //pełen obrót w 1/8 sekundy
            //pocisk
            const float b_speed = 1190f;
            const float b_range = 20;
            const int b_damage = 0;
            CSprite b_spr = StaticSprites.Bullet_Slow;
            //spritesy
            CSprite spr_tower = StaticSprites.Tower_Slower;
            //CAnimation spr_tower = StaticSprites.Thunder;
            CSprite spr_stage = StaticSprites.TowerStagev2;
            //effect
            const double ef_time = 3d;
            const string ef_name = "slow";
            const float ef_power = 0.7f;
            CSlow effect = new CSlow(ef_time, ef_name, ef_power);

            CRocket pocisk = new CRocket(b_spr, b_speed, damage, b_range, b_damage);
            pocisk.effect = effect;

            CTower next = Slower2; //wieżyczka, w którą się ulepsza

            Slower = new CTower(damage, reload, range, spr_tower, spr_stage, rotate_speed, pocisk, next, name, desc, cost);
        }
        private static void init_Slower2()
        {
            //wieżyczka
            const string name = "Spowalniacz2";
            const string desc = "Bron biologiczna,\nktora spowalnia\nwrogow";
            const int cost = 60;

            const int damage = 6;
            const float reload = 1.0f;
            const float range = 90f;
            const float rotate_speed = 2880; //pełen obrót w 1/8 sekundy
            //pocisk
            const float b_speed = 1190f;
            const float b_range = 50;
            const int b_damage = 0;
            CSprite b_spr = StaticSprites.Bullet_Slow;
            //spritesy
            CSprite spr_tower = StaticSprites.Tower_Slower2;
            //CAnimation spr_tower = StaticSprites.Thunder;
            CSprite spr_stage = StaticSprites.TowerStagev2;
            //effect
            const double ef_time = 3d;
            const string ef_name = "slow";
            const float ef_power = 0.7f;
            CSlow effect = new CSlow( ef_time, ef_name, ef_power );

            CRocket pocisk = new CRocket( b_spr, b_speed, damage, b_range, b_damage );
            pocisk.effect = effect;

            CTower next = null; //wieżyczka, w którą się ulepsza

            Slower2 = new CTower( damage, reload, range, spr_tower, spr_stage, rotate_speed, pocisk, next, name, desc, cost );
        }
        private static void init_Flamethrower()
        {
            //wieżyczka
            const string name = "Miotacz Ognia";
            const string desc = "Miota plomieniami\npodpalajac\nprzeciwnikow";
            const int cost = 40;

            const int damage = 2;
            const float reload = 0.2f;
            const float range = 80f;
            const float rotate_speed = 250;
            //pocisk
            const float b_speed = 290;
            //const float b_range = 80;
            //const float b_distance = range;
            const float b_size = 1f;
            CSprite b_spr = StaticSprites.Flame;
            //spritesy
            CSprite spr_tower = StaticSprites.Tower_Flamethrower;
            CSprite spr_stage = StaticSprites.TowerStagev2;
            //effect
            const double ef_time = 1d;
            const string ef_name = "fire";
            const int ef_damage = 2;
            CFire effect = new CFire( ef_time, ef_name, ef_damage );

            CFlame pocisk = new CFlame( b_spr, b_speed, damage, b_size, range );
            pocisk.effect = effect;

            CTower next = Flamethrower2; //wieżyczka, w którą się ulepsza

            Flamethrower = new CTower( damage, reload, range, spr_tower, spr_stage, rotate_speed, pocisk, next, name, desc, cost );
        }
        private static void init_Flamethrower2()
        {
            //wieżyczka
            const string name = "Miotacz Ognia2";
            const string desc = "Miota plomieniami\npodpalajac\nprzeciwnikow";
            const int cost = 40;

            const int damage = 4;
            const float reload = 0.2f;
            const float range = 100f;
            const float rotate_speed = 210;
            //pocisk
            const float b_speed = 290;
            //const float b_range = 80;
            //const float b_distance = range;
            const float b_size = 2f;
            CSprite b_spr = StaticSprites.Flame;
            //spritesy
            CSprite spr_tower = StaticSprites.Tower_Flamethrower2;
            CSprite spr_stage = StaticSprites.TowerStagev2;
            //effect
            const double ef_time = 1d;
            const string ef_name = "fire";
            const int ef_damage = 3;
            CFire effect = new CFire( ef_time, ef_name, ef_damage );

            CFlame pocisk = new CFlame( b_spr, b_speed, damage, b_size, range );
            pocisk.effect = effect;

            CTower next = null; //wieżyczka, w którą się ulepsza

            Flamethrower2 = new CTower( damage, reload, range, spr_tower, spr_stage, rotate_speed, pocisk, next, name, desc, cost );
        }
        private static void init_Rocket_1()
        {
            //wieżyczka
            const string name = "Wyrzutnia Rakiet"; //nazwa
            const string desc = "Rakiety zadaja\nobrazenia pobliskim\nprzeciwnikom";
            const int cost = 25;    //koszt (kupna lub ulepszenia)

            const int damage = 9;   //obrażenia
            const float reload = 1.0f;  //prędkość przeładowania (im większa wartość, tym wolniejszy strzał)
            const float range = 115f;   //zasięg
            const float rotate_speed = 1440; //pełen obrót w 1/4 sekundy
            //pocisk
            const float b_speed = 550f; //prędkość lotu pocisku
            const float b_boom_range = 30;
            const int b_boom_damage = 2;
            CSprite b_spr = StaticSprites.Rocket;   //sprites pocisku
            //spritesy
            CSprite spr_tower = StaticSprites.Tower_Rocket1;   //sprites wieżyczki
            CSprite spr_stage = StaticSprites.TowerStagev2;   //sprites podstawy wieżyczki

            CRocket pocisk = new CRocket(b_spr, b_speed, damage, b_boom_range, b_boom_damage);
            //pocisk.effect = effect;

            CTower next = Rocket2; //wieżyczka, w którą się ulepsza

            Rocket1 = new CTower(damage, reload, range, spr_tower, spr_stage, rotate_speed, pocisk, next, name, desc, cost);
        }
        private static void init_Rocket_2()
        {
            //wieżyczka
            const string name = "Turbo Wyrzutnia Rakiet";
            const string desc = "Rakiety zadaja\nobrazenia pobliskim\nprzeciwnikom";
            const int cost = 30;

            const int damage = 11;
            const float reload = 1.0f;
            const float range = 135f;
            const float rotate_speed = 1440; //pełen obrót w 1/4 sekundy
            //pocisk
            const float b_speed = 750f; //prędkość lotu pocisku
            const float b_boom_range = 45;
            const int b_boom_damage = 5;
            CSprite b_spr = StaticSprites.Rocket;
            //spritesy
            CSprite spr_tower = StaticSprites.Tower_Rocket2;
            CSprite spr_stage = StaticSprites.TowerStagev2;

            CRocket pocisk = new CRocket(b_spr, b_speed, damage, b_boom_range, b_boom_damage);
            CTower next = null; //wieżyczka, w którą się ulepsza

            Rocket2 = new CTower(damage, reload, range, spr_tower, spr_stage, rotate_speed, pocisk, next, name, desc, cost);
        }
        private static void init_Thunder()
        {
            //wieżyczka
            const string name = "Pulsar";
            const string desc = "Bron emitujaca\nenergie, ktora\nblyskawicznie\ndociera do wroga";
            const int cost = 35;

            const int damage = 3;
            const float reload = 1.1f;
            const float range = 54f;
            const float rotate_speed = 123; //ta wartość zupełnie nic nie zmienia ;_;
            //pocisk
            const float b_speed = 600f;
            //CSprite b_spr = StaticSprites.Bullet;
            CSprite b_spr = StaticSprites.Thunder;
            //spritesy
            CSprite spr_tower = StaticSprites.Tower_Pulsator;
            CSprite spr_stage = StaticSprites.TowerStagev2;

            CThunder pocisk = new CThunder( b_spr, b_speed, damage, range );
            CTower next = Thunder2; //wieżyczka, w którą się ulepsza

            Thunder = new CTower( damage, reload, range, spr_tower, spr_stage, rotate_speed, pocisk, next, name, desc, cost );
            Thunder.freeze_rotate = true;
            Thunder.ignore_aim = true;
        }
        private static void init_Thunder2()
        {
            //wieżyczka
            const string name = "Pulsar2";
            const string desc = "Bron emitujaca\nenergie, ktora\nblyskawicznie\ndociera do wroga";
            const int cost = 40;

            const int damage = 4;
            const float reload = 0.4f;
            const float range = 70f;
            const float rotate_speed = 123; //ta wartość zupełnie nic nie zmienia ;_;
            //pocisk
            const float b_speed = 900f;
            //CSprite b_spr = StaticSprites.Bullet;
            CSprite b_spr = StaticSprites.Thunder;
            //spritesy
            CSprite spr_tower = StaticSprites.Tower_Pulsator2;
            CSprite spr_stage = StaticSprites.TowerStagev2;

            CThunder pocisk = new CThunder( b_spr, b_speed, damage, range );
            
            CTower next = null; //wieżyczka, w którą się ulepsza

            Thunder2 = new CTower( damage, reload, range, spr_tower, spr_stage, rotate_speed, pocisk, next, name, desc, cost );
            Thunder2.freeze_rotate = true;
            Thunder2.ignore_aim = true;
        }
        private static void init_Lasser()
        {
            //wieżyczka
            const string name = "LazZeR";
            const string desc = "Promien laseru\nnagrzewa sie,\nzadajac coraz\nwieksze obrazenia";
            const int cost = 50;

            const int damage = 13;
            const float check = 0.1f;  //czas, który musi upłynąć przed namierzeniem następnego przeciwnika ( w obiekcie posłużyłem się istniejącą zmienną m_reload )
            const float range = 110f;
            const float rotate_speed = 350;
            //pocisk
            //spritesy
            CAnimation spr_tower = StaticSprites.Tower_Lasser_anim;
            CSprite spr_stage = StaticSprites.TowerStagev2;

            Color[] Colors = new Color[] { new Color( 0x66, 0xff, 0x03 ), new Color( 0x7d, 0xff, 0x28 ), new Color( 0x95, 0xff, 0x4f ) };
            
            CLasser pocisk = new CLasser( damage, Colors );
            CTower next = Lasser2; //wieżyczka, w którą się ulepsza

            Lasser = new CLasserTower( damage, range, check, spr_tower, spr_stage, rotate_speed, pocisk, next, name, desc, cost );
        }
        private static void init_Lasser2()
        {
            //wieżyczka
            const string name = "LazZeR2";
            const string desc = "Promien laseru\nnagrzewa sie,\nzadajac coraz\nwieksze obrazenia";
            const int cost = 35;

            const int damage = 19;
            const float check = 0.1f;  //czas, który musi upłynąć przed namierzeniem następnego przeciwnika ( w obiekcie posłużyłem się istniejącą zmienną m_reload )
            const float range = 140f;
            const float rotate_speed = 350;
            //pocisk
            //spritesy
            CAnimation spr_tower = StaticSprites.Tower_Lasser2_anim;
            CSprite spr_stage = StaticSprites.TowerStagev2;

            Color[] Colors = new Color[] { new Color( 0xc5, 0x15, 0x4f ), new Color( 0xd9, 0x15, 0x4f ), new Color( 0xd9, 0x34, 0x72 ) };

            CLasser pocisk = new CLasser( damage, Colors );
            CTower next = null; //wieżyczka, w którą się ulepsza

            Lasser2 = new CLasserTower( damage, range, check, spr_tower, spr_stage, rotate_speed, pocisk, next, name, desc, cost );
        }

        public static void Load()
        {   //ulepszenia powinno się
            //inicjować od tyłu !
            init_Gun3();
            init_Gun2();
            init_Gun1();
            init_Slower2();
            init_Slower();
            init_Flamethrower2();
            init_Flamethrower();
            init_Rocket_2();
            init_Rocket_1();
            init_Thunder2();
            init_Thunder();
            init_Lasser2();
            init_Lasser();
        }
    }
    public static class StaticEnemies   //statyczna klasa zawierająca przeciwników
    {
        public static CEnemy Normal;
        public static CEnemy Slug;
        public static CEnemy Fast;
        public static CEnemy SuperFast;
        public static CEnemy Fly;
        public static CEnemy SuperFly;
        public static CEnemy Boss;
        public static CEnemy BossFly;
        public static CEnemy MegaBoss;
        public static CEnemy Spawner;
        public static CEnemy Spawned;
        public static CEnemy Teleporter;
        public static CEnemy TeleporterAdrenaline;

        public static void init_normal()
        {
            CAnimation spr = StaticSprites.Enemy_Normal;
            int hp = 28;
            //float speed = 120;
            float speed = 50;
            int reward = 1;
            int damage = 1;
            EnemyType type = EnemyType.Normal;

            Normal =  new CEnemy(spr, hp, speed, reward, damage, type);
        }
        public static void init_slug()
        {
            CSprite spr = StaticSprites.Enemy_Slug;
            int hp = 46;
            float speed = 60;
            int reward = 2;
            int damage = 1;
            EnemyType type = EnemyType.Normal;

            Slug = new CEnemy( spr, hp, speed, reward, damage, type );
        }
        public static void init_fast()
        {
            CSprite spr = StaticSprites.Enemy_fast;
            int hp = 12;
            float speed = 230;
            int reward = 1;
            int damage = 1;
            EnemyType type = EnemyType.Normal;

            Fast = new CEnemy( spr, hp, speed, reward, damage, type );
        }
        public static void init_superfast()
        {
            CSprite spr = StaticSprites.Enemy_fast;
            int hp = 37;
            float speed = 230;
            int reward = 1;
            int damage = 1;
            EnemyType type = EnemyType.Normal;

            SuperFast = new CEnemy( spr, hp, speed, reward, damage, type );
        }
        public static void init_fly()
        {
            CSprite spr = StaticSprites.Enemy_Fly;
            int hp = 6;
            float speed = 75;
            int reward = 1;
            int damage = 1;
            EnemyType type = EnemyType.Fly;

            Fly = new CEnemy( spr, hp, speed, reward, damage, type );
        }
        public static void init_superfly()
        {
            CSprite spr = StaticSprites.Enemy_Fly;
            int hp = 90;
            float speed = 55;
            int reward = 2;
            int damage = 1;
            EnemyType type = EnemyType.Fly;

            SuperFly = new CEnemy( spr, hp, speed, reward, damage, type );
        }
        public static void init_boss()
        {
            CSprite spr = StaticSprites.Enemy_Boss;
            int hp = 515;
            float speed = 90;
            int reward = 25;
            int damage = 3;
            EnemyType type = EnemyType.Normal;

            Boss = new CEnemy( spr, hp, speed, reward, damage, type );
        }
        public static void init_bossfly()
        {
            CSprite spr = StaticSprites.Enemy_Bossfly;
            int hp = 800;
            float speed = 60;
            int reward = 65;
            int damage = 4;
            EnemyType type = EnemyType.Fly;

            BossFly = new CEnemy( spr, hp, speed, reward, damage, type );
        }
        public static void init_megaboss()
        {
            CSprite spr = StaticSprites.Enemy_Boss;
            int hp = 6515;
            float speed = 20;
            int reward = 250;
            int damage = 10;
            EnemyType type = EnemyType.Normal;

            MegaBoss = new CEnemy( spr, hp, speed, reward, damage, type );
        }
        public static void init_spawner()
        {
            CAnimation spr = StaticSprites.Enemy_Spawner;
            int hp = 20;
            float speed = 40;
            int reward = 1;
            int damage = 2;
            EnemyType type = EnemyType.Normal;
            
            //special
            CEnemy spawned = Spawned;
            int ammount = 3;

            Spawner = new CSpawner( spr, hp, speed, reward, damage, spawned, ammount, type );
        }
        public static void init_spawned()
        {
            CSprite spr = StaticSprites.Enemy_Spawned;
            int hp = 16;
            float speed = 90;
            int reward = 0;
            int damage = 1;
            EnemyType type = EnemyType.Normal;

            Spawned = new CEnemy( spr, hp, speed, reward, damage, type );
        }
        public static void init_teleporter()
        {
            CAnimation spr = StaticSprites.Enemy_Teleporter;
            int hp = 15;
            float speed = 160;
            int reward = 1;
            int damage = 1;
            EnemyType type = EnemyType.Normal;

            CAnimation spr_tp = StaticSprites.Detail_Teleport;
            double cooldown = 1.5;
            float distance = 80;

            Teleporter = new CTeleporter( spr, hp, speed, reward, damage, spr_tp, cooldown, distance,  type );
        }
        public static void init_teleporteradrenaline()
        {
            CAnimation spr = StaticSprites.Enemy_Teleporter;
            int hp = 15;
            float speed = 210;
            int reward = 2;
            int damage = 1;
            EnemyType type = EnemyType.Normal;

            CAnimation spr_tp = StaticSprites.Detail_Teleport;
            double cooldown = 0.5;
            float distance = 80;

            TeleporterAdrenaline = new CTeleporter( spr, hp, speed, reward, damage, spr_tp, cooldown, distance, type );
        }

        public static void Load()
        {
            init_normal();
            init_slug();
            init_fast();
            init_superfast();
            init_fly();
            init_superfly();
            init_boss();
            init_bossfly();
            init_megaboss();
            init_spawned();
            init_spawner();
            init_teleporter();
            init_teleporteradrenaline();
        }

    }
    public static class StaticStages
    {
        public static CStage[] stages = new CStage[3];

        private static void InitStage1()
        {
            //nazwa, textura tła
            stages[0] = new CStage( StaticTextures.Stage001 );

            //droga, po której poruszają się przeciwnicy
            List<Vector2> way = new List<Vector2>( 17 );
            way.Add( new Vector2( 190, 0 ) );
            way.Add( new Vector2( 190, 160 ) );
            way.Add( new Vector2( 70, 160 ) );
            way.Add( new Vector2( 70, 400 ) );
            way.Add( new Vector2( 230, 400 ) );
            way.Add( new Vector2( 230, 320 ) );
            way.Add( new Vector2( 350, 320 ) );
            way.Add( new Vector2( 350, 400 ) );
            way.Add( new Vector2( 550, 400 ) );
            way.Add( new Vector2( 550, 240 ) );
            way.Add( new Vector2( 390, 240 ) );
            way.Add( new Vector2( 390, 200 ) );
            way.Add( new Vector2( 350, 200 ) );
            way.Add( new Vector2( 350, 120 ) );
            way.Add( new Vector2( 470, 120 ) );
            way.Add( new Vector2( 470, 160 ) );
            way.Add( new Vector2( 620, 160 ) );
            stages[0].AddWay( way );

                //FALE
            //fala pierwsza
            CWave wav1 = new CWave();
            wav1.Enemies.Add( StaticEnemies.Slug );
            wav1.Enemies.Add( StaticEnemies.Slug );
            wav1.Enemies.Add( StaticEnemies.Normal);
            wav1.Enemies.Add( StaticEnemies.Normal );
            wav1.Enemies.Add( StaticEnemies.Normal );
            wav1.Enemies.Add( StaticEnemies.Normal );
            wav1.Enemies.Add( StaticEnemies.Normal );
            wav1.Enemies.Add( StaticEnemies.Fast );
            wav1.Enemies.Add( StaticEnemies.Fast );
            //fala druga
            CWave wav2 = new CWave();
            wav2.Enemies.Add( StaticEnemies.Slug );
            wav2.Enemies.Add( StaticEnemies.Slug );
            wav2.Enemies.Add( StaticEnemies.Slug );
            wav2.Enemies.Add( StaticEnemies.Slug );
            wav2.Enemies.Add( StaticEnemies.Normal );
            wav2.Enemies.Add( StaticEnemies.Teleporter );
            wav2.Enemies.Add( StaticEnemies.Normal );
            wav2.Enemies.Add( StaticEnemies.Teleporter );
            wav2.Enemies.Add( StaticEnemies.Normal );
            wav2.Enemies.Add( StaticEnemies.Teleporter );
            wav2.Enemies.Add( StaticEnemies.Normal );
            wav2.Enemies.Add( StaticEnemies.Teleporter );
            wav2.Enemies.Add( StaticEnemies.Normal );
            wav2.Enemies.Add( StaticEnemies.Teleporter );
            wav2.Enemies.Add( StaticEnemies.Fast );
            wav2.Enemies.Add( StaticEnemies.Fast );
            wav2.Enemies.Add( StaticEnemies.Fast );
            //fala trzecia
            CWave wav3 = new CWave();
            wav3.Enemies.Add( StaticEnemies.Slug );
            wav3.Enemies.Add( StaticEnemies.Slug );
            wav3.Enemies.Add( StaticEnemies.Slug );
            wav3.Enemies.Add( StaticEnemies.Slug );
            wav3.Enemies.Add( StaticEnemies.Slug );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Fly );
            wav3.Enemies.Add( StaticEnemies.Fly );
            wav3.Enemies.Add( StaticEnemies.Fly );
            //fala czwarta
            CWave wav4 = new CWave();
            wav4.Enemies.Add( StaticEnemies.Slug );
            wav4.Enemies.Add( StaticEnemies.Slug );
            wav4.Enemies.Add( StaticEnemies.Slug );
            wav4.Enemies.Add( StaticEnemies.Slug );
            wav4.Enemies.Add( StaticEnemies.Normal );
            wav4.Enemies.Add( StaticEnemies.Teleporter );
            wav4.Enemies.Add( StaticEnemies.Normal );
            wav4.Enemies.Add( StaticEnemies.Teleporter );
            wav4.Enemies.Add( StaticEnemies.Normal );
            wav4.Enemies.Add( StaticEnemies.Teleporter );
            wav4.Enemies.Add( StaticEnemies.Normal );
            wav4.Enemies.Add( StaticEnemies.Teleporter );
            wav4.Enemies.Add( StaticEnemies.Normal );
            wav4.Enemies.Add( StaticEnemies.Teleporter );
            wav4.Enemies.Add( StaticEnemies.Fast );
            wav4.Enemies.Add( StaticEnemies.Fast );
            wav4.Enemies.Add( StaticEnemies.Fast );
            //fala piąta
            CWave wav5 = new CWave();
            wav5.Enemies.Add( StaticEnemies.Slug );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Slug );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Slug );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Slug );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Slug );
            wav5.Enemies.Add( StaticEnemies.Fast );
            wav5.Enemies.Add( StaticEnemies.Teleporter );
            wav5.Enemies.Add( StaticEnemies.Fast );
            wav5.Enemies.Add( StaticEnemies.Teleporter );
            wav5.Enemies.Add( StaticEnemies.Fast );
            wav5.Enemies.Add( StaticEnemies.Teleporter );
            wav5.Enemies.Add( StaticEnemies.Fast );
            wav5.Enemies.Add( StaticEnemies.Teleporter );
            wav5.Enemies.Add( StaticEnemies.Fast );
            wav5.Enemies.Add( StaticEnemies.Teleporter );
            wav5.Enemies.Add( StaticEnemies.Boss );

            //tablica z pojedynczymi falami
            List<CWave> waves = new List<CWave>();
            waves.Add( wav1 );
            waves.Add( wav2 );
            waves.Add( wav3 );
            waves.Add( wav4 );
            waves.Add( wav5 );

            //inicjalizacja wave'ów
            stages[0].Waver.Initialize( waves );
        }
        private static void InitStage2()
        {
            //nazwa, textura tła
            stages[1] = new CStage( StaticTextures.Stage002 );

            //droga, po której poruszają się przeciwnicy
            List<Vector2> way = new List<Vector2>( 9 );
            way.Add( new Vector2( 0, 40 ) );
            way.Add( new Vector2( 230, 40 ) );
            way.Add( new Vector2( 230, 120 ) );
            way.Add( new Vector2( 70, 120 ) );
            way.Add( new Vector2( 70, 320 ) );
            way.Add( new Vector2( 390, 320 ) );
            way.Add( new Vector2( 390, 200 ) );
            way.Add( new Vector2( 470, 200 ) );
            way.Add( new Vector2( 470, 480 ) );
            stages[1].AddWay( way );
            stages[1].WayRectangle.Add( new Rectangle( 190, 200, 160, 80 ) );
            stages[1].WayRectangle.Add( new Rectangle( 150, 200, 0, 40 ) );

            //FALE
            //fala pierwsza
            CWave wav1 = new CWave();
            wav1.Enemies.Add( StaticEnemies.Normal );
            wav1.Enemies.Add( StaticEnemies.Slug );
            wav1.Enemies.Add( StaticEnemies.Normal );
            wav1.Enemies.Add( StaticEnemies.Slug );
            wav1.Enemies.Add( StaticEnemies.Slug );
            wav1.Enemies.Add( StaticEnemies.Normal );
            wav1.Enemies.Add( StaticEnemies.Slug );
            wav1.Enemies.Add( StaticEnemies.Slug );
            wav1.Enemies.Add( StaticEnemies.Normal );
            wav1.Enemies.Add( StaticEnemies.Slug );
            wav1.Enemies.Add( StaticEnemies.Normal );
            wav1.Enemies.Add( StaticEnemies.Slug );
            wav1.Enemies.Add( StaticEnemies.Slug );
            wav1.Enemies.Add( StaticEnemies.Normal );
            wav1.Enemies.Add( StaticEnemies.Slug );
            wav1.Enemies.Add( StaticEnemies.Slug );
            wav1.Enemies.Add( StaticEnemies.Normal );
            wav1.Enemies.Add( StaticEnemies.Normal );
            wav1.Enemies.Add( StaticEnemies.Normal );
            wav1.Enemies.Add( StaticEnemies.Normal );
            wav1.Enemies.Add( StaticEnemies.Normal );
            //fala druga
            CWave wav2 = new CWave();
            wav2.Enemies.Add( StaticEnemies.Fast );
            wav2.Enemies.Add( StaticEnemies.Normal );
            wav2.Enemies.Add( StaticEnemies.Normal );
            wav2.Enemies.Add( StaticEnemies.Fast );
            wav2.Enemies.Add( StaticEnemies.Normal );
            wav2.Enemies.Add( StaticEnemies.Normal );
            wav2.Enemies.Add( StaticEnemies.Fast );
            wav2.Enemies.Add( StaticEnemies.Normal );
            wav2.Enemies.Add( StaticEnemies.Normal );
            wav2.Enemies.Add( StaticEnemies.Fast );
            wav2.Enemies.Add( StaticEnemies.Normal );
            wav2.Enemies.Add( StaticEnemies.Normal );
            wav2.Enemies.Add( StaticEnemies.Fast );
            wav2.Enemies.Add( StaticEnemies.Slug );
            wav2.Enemies.Add( StaticEnemies.Spawner );
            wav2.Enemies.Add( StaticEnemies.Spawner );
            wav2.Enemies.Add( StaticEnemies.Slug );
            wav2.Enemies.Add( StaticEnemies.Spawner );
            wav2.Enemies.Add( StaticEnemies.Spawner );
            wav2.Enemies.Add( StaticEnemies.Slug );
            wav2.Enemies.Add( StaticEnemies.Spawner );
            wav2.Enemies.Add( StaticEnemies.Spawner );
            wav2.Enemies.Add( StaticEnemies.Slug );
            wav2.Enemies.Add( StaticEnemies.Spawner );
            wav2.Enemies.Add( StaticEnemies.Spawner );
            wav2.Enemies.Add( StaticEnemies.Fast );
            wav2.Enemies.Add( StaticEnemies.Normal );
            wav2.Enemies.Add( StaticEnemies.Normal );
            wav2.Enemies.Add( StaticEnemies.Fast );
            wav2.Enemies.Add( StaticEnemies.Normal );
            wav2.Enemies.Add( StaticEnemies.Normal );
            wav2.Enemies.Add( StaticEnemies.Fast );
            wav2.Enemies.Add( StaticEnemies.Normal );
            wav2.Enemies.Add( StaticEnemies.Normal );
            wav2.Enemies.Add( StaticEnemies.Fast );
            wav2.Enemies.Add( StaticEnemies.Normal );
            wav2.Enemies.Add( StaticEnemies.Normal );
            wav2.Enemies.Add( StaticEnemies.Fast );
            wav2.Enemies.Add( StaticEnemies.Slug );
            wav2.Enemies.Add( StaticEnemies.Spawner );
            wav2.Enemies.Add( StaticEnemies.Spawner );
            wav2.Enemies.Add( StaticEnemies.Slug );
            wav2.Enemies.Add( StaticEnemies.Spawner );
            wav2.Enemies.Add( StaticEnemies.Spawner );
            wav2.Enemies.Add( StaticEnemies.Slug );
            wav2.Enemies.Add( StaticEnemies.Spawner );
            wav2.Enemies.Add( StaticEnemies.Spawner );
            wav2.Enemies.Add( StaticEnemies.Slug );
            wav2.Enemies.Add( StaticEnemies.Spawner );
            wav2.Enemies.Add( StaticEnemies.Spawner );
            wav2.Enemies.Add( StaticEnemies.Slug );
            //fala trzecia
            CWave wav3 = new CWave();
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Fly );
            wav3.Enemies.Add( StaticEnemies.Fast );
            wav3.Enemies.Add( StaticEnemies.Fast );
            wav3.Enemies.Add( StaticEnemies.Fly );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Fly );
            wav3.Enemies.Add( StaticEnemies.Fast );
            wav3.Enemies.Add( StaticEnemies.Fast );
            wav3.Enemies.Add( StaticEnemies.Fly );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Fly );
            wav3.Enemies.Add( StaticEnemies.Fast );
            wav3.Enemies.Add( StaticEnemies.Fast );
            wav3.Enemies.Add( StaticEnemies.Fly );
            wav3.Enemies.Add( StaticEnemies.Normal );
            //fala czwarta
            CWave wav4 = new CWave();
            wav4.Enemies.Add( StaticEnemies.Normal );
            wav4.Enemies.Add( StaticEnemies.SuperFly );
            wav4.Enemies.Add( StaticEnemies.Teleporter );
            wav4.Enemies.Add( StaticEnemies.Fly );
            wav4.Enemies.Add( StaticEnemies.Fly );
            wav4.Enemies.Add( StaticEnemies.Teleporter );
            wav4.Enemies.Add( StaticEnemies.SuperFly );
            wav4.Enemies.Add( StaticEnemies.SuperFly );
            wav4.Enemies.Add( StaticEnemies.Teleporter );
            wav4.Enemies.Add( StaticEnemies.Fly );
            wav4.Enemies.Add( StaticEnemies.Fly );
            wav4.Enemies.Add( StaticEnemies.Teleporter );
            wav4.Enemies.Add( StaticEnemies.SuperFly );
            wav4.Enemies.Add( StaticEnemies.SuperFly );
            wav4.Enemies.Add( StaticEnemies.Teleporter );
            wav4.Enemies.Add( StaticEnemies.Fly );
            wav4.Enemies.Add( StaticEnemies.Fly );
            wav4.Enemies.Add( StaticEnemies.Teleporter );
            wav4.Enemies.Add( StaticEnemies.Teleporter );
            wav4.Enemies.Add( StaticEnemies.Teleporter );
            wav4.Enemies.Add( StaticEnemies.Teleporter );
            wav4.Enemies.Add( StaticEnemies.Teleporter );
            wav4.Enemies.Add( StaticEnemies.Teleporter );
            //fala piąta
            CWave wav5 = new CWave();
            wav5.Enemies.Add( StaticEnemies.Normal );
            wav5.Enemies.Add( StaticEnemies.Normal );
            wav5.Enemies.Add( StaticEnemies.Slug );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Teleporter );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Teleporter );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            //fala szósta
            CWave wav6 = new CWave();
            wav6.Enemies.Add( StaticEnemies.SuperFast );
            wav6.Enemies.Add( StaticEnemies.SuperFast );
            wav6.Enemies.Add( StaticEnemies.SuperFast );
            wav6.Enemies.Add( StaticEnemies.SuperFast );
            wav6.Enemies.Add( StaticEnemies.SuperFast );
            wav6.Enemies.Add( StaticEnemies.SuperFast );
            wav6.Enemies.Add( StaticEnemies.SuperFly );
            wav6.Enemies.Add( StaticEnemies.SuperFast );
            wav6.Enemies.Add( StaticEnemies.SuperFly );
            wav6.Enemies.Add( StaticEnemies.SuperFast );
            wav6.Enemies.Add( StaticEnemies.SuperFly );
            wav6.Enemies.Add( StaticEnemies.SuperFast );
            wav6.Enemies.Add( StaticEnemies.SuperFly );
            wav6.Enemies.Add( StaticEnemies.SuperFast );
            wav6.Enemies.Add( StaticEnemies.SuperFly );
            wav6.Enemies.Add( StaticEnemies.SuperFast );
            wav6.Enemies.Add( StaticEnemies.SuperFly );
            wav6.Enemies.Add( StaticEnemies.SuperFly );
            //fala siódma
            CWave wav7 = new CWave();
            wav7.Enemies.Add( StaticEnemies.SuperFast );
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.SuperFast );
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.SuperFast );
            wav7.Enemies.Add( StaticEnemies.SuperFast );
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.SuperFast );
            wav7.Enemies.Add( StaticEnemies.Slug );
            wav7.Enemies.Add( StaticEnemies.Slug);
            wav7.Enemies.Add( StaticEnemies.Slug );
            wav7.Enemies.Add( StaticEnemies.Slug);
            wav7.Enemies.Add( StaticEnemies.Slug );
            wav7.Enemies.Add( StaticEnemies.Slug);
            wav7.Enemies.Add( StaticEnemies.Slug );
            wav7.Enemies.Add( StaticEnemies.MegaBoss );

            //tablica z pojedynczymi falami
            List<CWave> waves = new List<CWave>();
            waves.Add( wav1 );
            waves.Add( wav2 );
            waves.Add( wav3 );
            waves.Add( wav4 );
            waves.Add( wav5 );
            waves.Add( wav6 );
            waves.Add( wav7 );

            //inicjalizacja wave'ów
            stages[1].Waver.Initialize( waves );
        }
        private static void InitStage3()
        {
            //nazwa, textura tła
            stages[2] = new CStage( StaticTextures.Stage003 );

            //droga, po której poruszają się przeciwnicy
            List<Vector2> way = new List<Vector2>( 9 );
            way.Add( new Vector2( 190, 0 ) );
            way.Add( new Vector2( 190, 160 ) );
            way.Add( new Vector2( 30, 160 ) );
            way.Add( new Vector2( 30, 360 ) );
            way.Add( new Vector2( 110, 360 ) );
            way.Add( new Vector2( 110, 440 ) );
            way.Add( new Vector2( 390, 440 ) );
            way.Add( new Vector2( 390, 80 ) );
            way.Add( new Vector2( 510, 80 ) );
            way.Add( new Vector2( 510, 480 ) );
            stages[2].AddWay( way );
            stages[2].WayRectangle.Add( new Rectangle( 230, 80, 120, 200 ) );
            stages[2].WayRectangle.Add( new Rectangle( 430, 320, 40, 120 ) );
            stages[2].WayRectangle.Add( new Rectangle( 150, 200, 40, 80 ) );

            //FALE
            //fala pierwsza
            CWave wav1 = new CWave();
            wav1.Enemies.Add( StaticEnemies.Fly );
            wav1.Enemies.Add( StaticEnemies.Spawner );
            wav1.Enemies.Add( StaticEnemies.Spawner );
            wav1.Enemies.Add( StaticEnemies.Fly );
            wav1.Enemies.Add( StaticEnemies.Spawner );
            wav1.Enemies.Add( StaticEnemies.Spawner );
            wav1.Enemies.Add( StaticEnemies.Fly );
            wav1.Enemies.Add( StaticEnemies.Spawner );
            wav1.Enemies.Add( StaticEnemies.Spawner );
            wav1.Enemies.Add( StaticEnemies.Fly );
            wav1.Enemies.Add( StaticEnemies.Spawner );
            wav1.Enemies.Add( StaticEnemies.Spawner );
            wav1.Enemies.Add( StaticEnemies.Fly );
            wav1.Enemies.Add( StaticEnemies.Slug );
            wav1.Enemies.Add( StaticEnemies.Slug );
            wav1.Enemies.Add( StaticEnemies.Slug );
            wav1.Enemies.Add( StaticEnemies.Slug );
            wav1.Enemies.Add( StaticEnemies.Slug );
            wav1.Enemies.Add( StaticEnemies.Slug );
            wav1.Enemies.Add( StaticEnemies.Slug );
            wav1.Enemies.Add( StaticEnemies.Slug );
            wav1.Enemies.Add( StaticEnemies.Slug );

            CWave wav2 = new CWave();
            wav2.Enemies.Add( StaticEnemies.Fly );
            wav2.Enemies.Add( StaticEnemies.Fast );
            wav2.Enemies.Add( StaticEnemies.Fast );
            wav2.Enemies.Add( StaticEnemies.Fly );
            wav2.Enemies.Add( StaticEnemies.Fast );
            wav2.Enemies.Add( StaticEnemies.Fast );
            wav2.Enemies.Add( StaticEnemies.Fly );
            wav2.Enemies.Add( StaticEnemies.Fast );
            wav2.Enemies.Add( StaticEnemies.Fast );
            wav2.Enemies.Add( StaticEnemies.Fly );
            wav2.Enemies.Add( StaticEnemies.SuperFast );
            wav2.Enemies.Add( StaticEnemies.SuperFast );
            wav2.Enemies.Add( StaticEnemies.SuperFast );
            wav2.Enemies.Add( StaticEnemies.SuperFast );
            wav2.Enemies.Add( StaticEnemies.SuperFast );
            wav2.Enemies.Add( StaticEnemies.SuperFast );
            wav2.Enemies.Add( StaticEnemies.SuperFly );
            wav2.Enemies.Add( StaticEnemies.SuperFly );
            wav2.Enemies.Add( StaticEnemies.SuperFly );

            CWave wav3 = new CWave();
            wav3.Enemies.Add( StaticEnemies.SuperFly );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.SuperFly );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.SuperFly );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.SuperFly );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.SuperFly );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.SuperFly );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.SuperFly );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.SuperFly );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Normal );
            wav3.Enemies.Add( StaticEnemies.Slug );
            wav3.Enemies.Add( StaticEnemies.Slug );
            wav3.Enemies.Add( StaticEnemies.Slug );
            wav3.Enemies.Add( StaticEnemies.Slug );
            wav3.Enemies.Add( StaticEnemies.Slug );
            wav3.Enemies.Add( StaticEnemies.Slug );

            CWave wav4 = new CWave();
            wav4.Enemies.Add( StaticEnemies.Slug );
            wav4.Enemies.Add( StaticEnemies.Slug );
            wav4.Enemies.Add( StaticEnemies.Slug );
            wav4.Enemies.Add( StaticEnemies.Slug );
            wav4.Enemies.Add( StaticEnemies.Slug );
            wav4.Enemies.Add( StaticEnemies.Slug );
            wav4.Enemies.Add( StaticEnemies.Slug );
            wav4.Enemies.Add( StaticEnemies.SuperFast );
            wav4.Enemies.Add( StaticEnemies.SuperFast );
            wav4.Enemies.Add( StaticEnemies.SuperFast );
            wav4.Enemies.Add( StaticEnemies.SuperFast );
            wav4.Enemies.Add( StaticEnemies.TeleporterAdrenaline );
            wav4.Enemies.Add( StaticEnemies.TeleporterAdrenaline );
            wav4.Enemies.Add( StaticEnemies.TeleporterAdrenaline );
            wav4.Enemies.Add( StaticEnemies.TeleporterAdrenaline );
            wav4.Enemies.Add( StaticEnemies.SuperFast );
            wav4.Enemies.Add( StaticEnemies.SuperFast );
            wav4.Enemies.Add( StaticEnemies.SuperFast );
            wav4.Enemies.Add( StaticEnemies.SuperFast );

            CWave wav5 = new CWave();
            wav5.Enemies.Add( StaticEnemies.SuperFly );
            wav5.Enemies.Add( StaticEnemies.SuperFly );
            wav5.Enemies.Add( StaticEnemies.SuperFly );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Boss );
            wav5.Enemies.Add( StaticEnemies.SuperFly );
            wav5.Enemies.Add( StaticEnemies.SuperFly );
            wav5.Enemies.Add( StaticEnemies.SuperFly );
            wav5.Enemies.Add( StaticEnemies.SuperFly );
            wav5.Enemies.Add( StaticEnemies.SuperFly );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.Spawner );
            wav5.Enemies.Add( StaticEnemies.SuperFly );
            wav5.Enemies.Add( StaticEnemies.SuperFly );
            wav5.Enemies.Add( StaticEnemies.SuperFly );
            wav5.Enemies.Add( StaticEnemies.SuperFly );
            wav5.Enemies.Add( StaticEnemies.Boss );

            CWave wav6 = new CWave();
            wav6.Enemies.Add( StaticEnemies.SuperFly );
            wav6.Enemies.Add( StaticEnemies.SuperFly );
            wav6.Enemies.Add( StaticEnemies.SuperFly );
            wav6.Enemies.Add( StaticEnemies.SuperFly );
            wav6.Enemies.Add( StaticEnemies.Spawner );
            wav6.Enemies.Add( StaticEnemies.Spawner );
            wav6.Enemies.Add( StaticEnemies.Spawner );
            wav6.Enemies.Add( StaticEnemies.Spawner );
            wav6.Enemies.Add( StaticEnemies.Spawner );
            wav6.Enemies.Add( StaticEnemies.Spawner );
            wav6.Enemies.Add( StaticEnemies.SuperFast );
            wav6.Enemies.Add( StaticEnemies.SuperFast );
            wav6.Enemies.Add( StaticEnemies.SuperFast );
            wav6.Enemies.Add( StaticEnemies.TeleporterAdrenaline );
            wav6.Enemies.Add( StaticEnemies.TeleporterAdrenaline );
            wav6.Enemies.Add( StaticEnemies.TeleporterAdrenaline );
            wav6.Enemies.Add( StaticEnemies.Boss );
            wav6.Enemies.Add( StaticEnemies.Boss );

            CWave wav7 = new CWave();
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.SuperFly );
            wav7.Enemies.Add( StaticEnemies.BossFly );

            CWave wav8 = new CWave();
            wav8.Enemies.Add( StaticEnemies.BossFly );
            wav8.Enemies.Add( StaticEnemies.BossFly );
            wav8.Enemies.Add( StaticEnemies.Fly );
            wav8.Enemies.Add( StaticEnemies.Boss );
            wav8.Enemies.Add( StaticEnemies.Fly );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Fly );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Fly );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Fly );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Fly );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Fly );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Fly );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.Spawner );
            wav8.Enemies.Add( StaticEnemies.TeleporterAdrenaline );
            wav8.Enemies.Add( StaticEnemies.TeleporterAdrenaline );
            wav8.Enemies.Add( StaticEnemies.TeleporterAdrenaline );
            wav8.Enemies.Add( StaticEnemies.TeleporterAdrenaline );
            wav8.Enemies.Add( StaticEnemies.TeleporterAdrenaline );
            wav8.Enemies.Add( StaticEnemies.BossFly );

            CWave wav9 = new CWave();
            wav9.Enemies.Add( StaticEnemies.BossFly );
            wav9.Enemies.Add( StaticEnemies.TeleporterAdrenaline );
            wav9.Enemies.Add( StaticEnemies.TeleporterAdrenaline );
            wav9.Enemies.Add( StaticEnemies.TeleporterAdrenaline );
            wav9.Enemies.Add( StaticEnemies.TeleporterAdrenaline );
            wav9.Enemies.Add( StaticEnemies.SuperFast );
            wav9.Enemies.Add( StaticEnemies.Spawner );
            wav9.Enemies.Add( StaticEnemies.Spawner );
            wav9.Enemies.Add( StaticEnemies.SuperFast );
            wav9.Enemies.Add( StaticEnemies.Spawner );
            wav9.Enemies.Add( StaticEnemies.Spawner );
            wav9.Enemies.Add( StaticEnemies.SuperFast );
            wav9.Enemies.Add( StaticEnemies.Spawner );
            wav9.Enemies.Add( StaticEnemies.Spawner );
            wav9.Enemies.Add( StaticEnemies.SuperFast );
            wav9.Enemies.Add( StaticEnemies.Spawner );
            wav9.Enemies.Add( StaticEnemies.Spawner );
            wav9.Enemies.Add( StaticEnemies.BossFly );
            wav9.Enemies.Add( StaticEnemies.TeleporterAdrenaline );
            wav9.Enemies.Add( StaticEnemies.TeleporterAdrenaline );
            wav9.Enemies.Add( StaticEnemies.TeleporterAdrenaline );
            wav9.Enemies.Add( StaticEnemies.TeleporterAdrenaline );
            wav9.Enemies.Add( StaticEnemies.MegaBoss );
            wav9.Enemies.Add( StaticEnemies.Fast );
            wav9.Enemies.Add( StaticEnemies.Slug );
            wav9.Enemies.Add( StaticEnemies.Fast );
            wav9.Enemies.Add( StaticEnemies.Slug );
            wav9.Enemies.Add( StaticEnemies.Fast );
            wav9.Enemies.Add( StaticEnemies.Slug );
            wav9.Enemies.Add( StaticEnemies.Fast );
            wav9.Enemies.Add( StaticEnemies.Slug );
            wav9.Enemies.Add( StaticEnemies.Fast );
            wav9.Enemies.Add( StaticEnemies.Slug );
            wav9.Enemies.Add( StaticEnemies.Fast );
            wav9.Enemies.Add( StaticEnemies.Slug );
            wav9.Enemies.Add( StaticEnemies.Fast );
            wav9.Enemies.Add( StaticEnemies.Slug );
            wav9.Enemies.Add( StaticEnemies.Fast );
            wav9.Enemies.Add( StaticEnemies.Slug );
            wav9.Enemies.Add( StaticEnemies.Fast );
            wav9.Enemies.Add( StaticEnemies.Slug );
            wav9.Enemies.Add( StaticEnemies.Fast );
            wav9.Enemies.Add( StaticEnemies.Slug );
            wav9.Enemies.Add( StaticEnemies.Fast );
            wav9.Enemies.Add( StaticEnemies.Slug );
            wav9.Enemies.Add( StaticEnemies.Fast );
            wav9.Enemies.Add( StaticEnemies.Fast );
            wav9.Enemies.Add( StaticEnemies.Slug );
            wav9.Enemies.Add( StaticEnemies.Fast );
            wav9.Enemies.Add( StaticEnemies.Slug );
            wav9.Enemies.Add( StaticEnemies.Slug );

            //tablica z pojedynczymi falami
            List<CWave> waves = new List<CWave>();
            waves.Add( wav1 );
            waves.Add( wav2 );
            waves.Add( wav3 );
            waves.Add( wav4 );
            waves.Add( wav5 );
            waves.Add( wav6 );
            waves.Add( wav7 );
            waves.Add( wav8 );
            waves.Add( wav9 );

            //inicjalizacja wave'ów
            stages[2].Waver.Initialize( waves );
        }

        public static void CreateStages()
        {
            InitStage1();
            InitStage2();
            InitStage3();
        }
    }

    public static class StaticRectangles    //statyczna klasa zawierająca prostokąty (obszary gry, menu, etc.)
    {
        public static class Upgrader
        {
            public static readonly Rectangle Upgrade = new Rectangle(125, 390, 180, 80);
            public static readonly Rectangle Sell = new Rectangle(315, 390, 180, 80);
        }
    }
    public static class StaticVectors   //statyczna klasa zawierająca wektory (położenie różnych obiektów na ekranie)
    {
        public static readonly Vector2 Start = new Vector2( 507, 41 );
        public static readonly Vector2 BackToMenu = new Vector2( 507, 5 );

        public static class Menu    //wektory użyte podczas budowy menu (wybór poziomu)
        {
            public static readonly Vector2 GameName = new Vector2( 66, 25 );    //położenie napisu z nazwą gry
            public static readonly Vector2 Frame = new Vector2( 130, 189 );     //położenie ramki i tła pod przyciski z mapkami

            public static readonly Vector2 Button_quit = new Vector2( 632, 402 );   //przycisk wyjścia z gry
            public static readonly Vector2[] Buttons_stage = { new Vector2( 146, 205 ), new Vector2( 321, 205 ), new Vector2( 496, 205 ) };
        }
        public static class RighMenu //pozycje guzików w menu po prawej stronie (budowa wieżyczek)
        {
            public static readonly Vector2[] Turret = { new Vector2( 625, 165 ), new Vector2( 625, 212 ), new Vector2( 625, 259 ), new Vector2( 625, 306 ), new Vector2( 625, 353 ), new Vector2( 625, 400 ) };
            public static readonly Vector2[] Text = { new Vector2( 673, 171 ), new Vector2( 673, 218 ), new Vector2( 673, 265 ), new Vector2( 673, 312 ), new Vector2( 673, 359 ), new Vector2( 673, 406 ) };
            public static readonly Vector2[] Image = { new Vector2( 647, 188 ), new Vector2( 647, 235 ), new Vector2( 647, 282 ), new Vector2( 647, 329 ), new Vector2( 647, 376 ), new Vector2( 647, 423 ) };
        }
        public static class Texts //położenie napisów
        {
            public static readonly Vector2 Health = new Vector2( 735, 20 );
            public static readonly Vector2 Cash = new Vector2( 730, 62 );
            public static readonly Vector2 Level = new Vector2( 725, 110 );
        }
        public static class Upgrader //ulepszanie i sprzedarz wieżyczek
        {
            public static readonly Vector2 Upgrade = new Vector2( 507, 82 );
            public static readonly Vector2 Sell = new Vector2( 507, 123 );

            public static readonly Vector2 UpgradeCost = new Vector2( 562, 96 );
            public static readonly Vector2 SellValue = new Vector2( 562, 136 );
        }
        public static class Panels  //położenie wszystkich sztywnych elementów (tła, ramki itd.)
        {
            public static readonly Vector2 Right = new Vector2( 620, 0 ); //prawy panel na ekranie
            public static readonly Vector2 Win = new Vector2( 70, 25 );     //położenie napisów wygranej
            public static readonly Vector2 Defeat = new Vector2( 70, 52 );  // i przegranej
            public static readonly Vector2 back_to_menu = new Vector2( 200, 287 );  //położenie przycisku powrotu do menu
            public static readonly Vector2 quit_the_game = new Vector2( 200, 336 ); //i wyjścia z gry

            public static class InGameMenu  //menu wewnątrz gry
            {
                public static readonly Vector2 background = new Vector2( 80, 96 ); //Położenie tła
                public static readonly Vector2 BackToGame = new Vector2( 121, 137 ); //powrót do gry
                public static readonly Vector2 BackToMenu = new Vector2( 121, 207 ); //powrót do menu
                public static readonly Vector2 Exit = new Vector2( 121, 277 ); //wyjście z gry
            }
            public static class InfoBox //panel z informacjami o wieżyczce
            {
                public static readonly Vector2 position = new Vector2( 507, 164 );  //pozycja tła infoboxu
                public static readonly Vector2 img0 = new Vector2( 543, 167 );  //pozycja obrazu wieżyczki bez ulepszeń
                public static readonly Vector2 img1 = new Vector2( 510, 167 );  //pozycja obrazu wieżyczki
                public static readonly Vector2 img2 = new Vector2( 576, 167 );  //pozycja obrazu ulepszonej wieżyczki
                public static readonly Vector2 descriptoin = new Vector2( 511, 258 );  //pozycja tekstu - opisu wieżyczki

                /*                                          siła                           zasięg                       prędkość        */
                public static readonly Vector2[] bars1 = { new Vector2( 510, 217 ), new Vector2( 510, 232 ), new Vector2( 510, 247 ) }; //położenie pasków z informacjami o wieżyczce
                public static readonly Vector2[] bars2 = { new Vector2( 576, 217 ), new Vector2( 576, 232 ), new Vector2( 576, 247 ) }; //położenie pasków z informacjami o  ulepszonej wieżyczce
            }
        }
    }
    public static class StaticConsts    //statyczna klasa zawierająca resztę stałych, w tym zmienne skalarne
    {
        //public const int GridSize = 26; //wielkość siatki w pixelach
        public const int GridSize = 40; //wielkość siatki w pixelach
        public const int WayReward = 10;//nagroda za ukończenie fali przeciwników
        public const int MarginX = 10;
        public const int MarginY = 20;
        public const int StageWidth = 620;
        public const int StageHeight = 480;

        public static class Helper  //stałe związane z samouczkiem
        {
            public const double info_time = 8;  //jak długo mają się wyświetlać tabliczki czasowe?
            public const byte fade_power = 130;    //jak bardzo przezroczyste mają być tabliczki?
            public const byte fade_speed = 5; //jak szybko ma się zmieniać przezroczystocs tabliczki? (ilosc/klatka)
        }
        public static class Infobox //stałe związane z infoboxem (informacje o wieżyczce)
        {
                //kolory barów
            public static Color bar_power1 = new Color( 219, 8, 0 );
            public static Color bar_power2 = new Color( 54, 0, 0 );
            public static Color bar_range1 = new Color( 0, 190, 0 );
            public static Color bar_range2 = new Color( 0, 79, 0 );
            public static Color bar_rate1 = new Color( 226, 197, 0 );
            public static Color bar_rate2 = new Color( 156, 95, 0 );

            public const int bar_width_dual = 38;    //szerokość paska
            public const int bar_width_mono = 104;    //szerokość paska
            public const int bar_height = 3;    //wysokość paska

            //odniesienia pasków [ (statystyka_wieżyczki / odniesienie) * szerokosc_paska = zamalowana czesc paska  ]
            //inaczej maksymalna wielkosc danej statystyki, jesli jakas wieżyczka będzie mieć więcej, pasek wyjdzie poza swoje granice ;>
            public static float bar_power_max = 25f;
            public static float bar_range_max = 200f;
            public static float bar_rate_max = 4f;   //ta wartość wyświetla się odwrotnie, niż reszta, więc tutaj podajemy najwolniejszą wieżyczkę
        }
        public static class Menu
        {
            public const int ErrorGameName = 3; //jak bardzo ma drżeć nazwa gry?
        }
        public static class Popup   //stałe związane z Popup'ami (czyli tekstami pojawiającymi się na ekranie i znikającymi po chwili)
        {
            public const int CashDistance = 10; //przez ile pixelów ma się przesuwać ilość zdobytej kasy za zabicie
            public const int HealtDistance = 10; //przez ile pixelów ma się przesuwać ilość straconych punktów życia
            public const double CashTime = 1.4; //przez jaki czas ma być widoczna liczba zdobytej kasy
            public const double HealthTime = 2.2; //przez jaki czas ma być widoczna liczba zdobytej kasy
        }
        public static class Enemies //stałe związane z przeciwnikami
        {
            public const int MoveError = 10;    //żeby przeciwnicy nie chodzili tempo od punktu do punktu, dodaję errory
            public const double SpawnRate = 200; //co ile milisekund pojawia się potworek
            public const int hpb_height = 2;    //wysokość paska hp
            public const int hpb_offset = 2;    //ilość pixeli odstępu między przeciwnikiem a paskiem hp
            public static readonly Color hpb_color_health = Color.Orange;    //kolor paska z życiem
            public static readonly Color hpb_color_need = Color.DarkRed;  //kolor paska z brakującym życiem
            public const float Spawner_error = 5;   //w jakiej maksymalnej (losowej) odległości od spawnera pojawiają się spawny
            public const float Teleporter_time_error = 0.2f;    //maksymalna losowa wartość dodana do cooldowna teleportacji
            public const int TeleportError = 3;    //żeby przeciwnicy nie chodzili tempo od punktu do punktu, dodaję errory
        }
        public static class Effects //stałe związane z efektami (na przeciwnikach)
        {
            public static Color ColorSlow = Color.DarkGreen;
            public static Color ColorFire = Color.Red;
            public static Color ColorDamage = Color.Brown;
            public static Color ColorLivingBomb = Color.Yellow;

            public const int effb_width = 2;   //szerokość paska informującego
            public const int effb_offset = 0;   //odległość paska od texturki/innego paska

            //fire
            public const double fire_tick_time = 1;
        }
        public static class Towers //stałe związane z wieżyczkami
        {
            public const float MaxAimError = 10f;  //maksymalny kąt między lufą, a przeciwnikiem
            public const float SellPercent = 0.50f; //przelicznik zwrotu kasy za wieżyczkę
            public const float BulletSize  = 20f;    //zasięg kolidowania poccisków
            public const float FlameRandom = 8f;   //margines błędu celowania miotacza ognia
            public const double FlameTick = 0.5;    //co ile sekund uderza pocisk miotacza ognia
            public const float Thunderthickness = 8f;   //grubość obwodu pocisku typu CThunder
            public const int LasserMinTickness = 1; //minimalna grubość lasera
            public const int LasserMaxTickness = 4; //maksymalna grubość lasera
            public const float LasserMinPower = 0.1f; //minimalny procent mocy lasera 
            public const float LasserPowerAddSpeed = 0.03f; //prędkość wzrastania mocy lassera
            public const float LasserPowerSubSpeed = LasserPowerAddSpeed / 2; //prędkość spadania mocy lassera
            public const double LasserTick = 0.2;    //co ile sekund uderza pocisk miotacza ognia
        }
    }
}
