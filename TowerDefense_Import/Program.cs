/*	       
 *         Grzegorz (Hagis) Kupczyk
 *	Copyright 2014 (c)
 *	Wszystkie prawa zastrze¿one
 *  Contact: hagisek1998@gmail.com
 */
using System;

namespace TowerDefence
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Game1 game = new Game1())
            {
                game.Window.Title = "Interaktywny produkt IT";
                //game.Window.AllowUserResizing = true;
                game.IsMouseVisible = true;
                
                game.Run();
            }
        }
    }
#endif
}

