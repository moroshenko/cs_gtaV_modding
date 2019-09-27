using System;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using System.Windows.Forms;
using System.Drawing;
using GTA;

namespace Lesson1
{
    class class1 : Script
    {
        UISprite cursor;
        bool showCorsor;

        
        public class1()
        {
            KeyDown += SHowHello;
            Tick += ShowCursor;

            cursor = new UISprite("cursor", "cursor", new Size(30, 30), new Point(UI.WIDTH/2 , UI.HEIGHT/2));
            showCorsor = false;
        }

        private void ShowCursor(object sender, EventArgs e)
        {
            if (showCorsor)
            {
                Entity target = Game.Player.GetTargetedEntity();
                if(target != null && target is Ped)
                {
                    Ped cel = target as Ped;
                    
                    if (cel.Gender == Gender.Female)
                        World.AddExplosion(cel.Position, ExplosionType.Grenade, 10, 1);
                    if (cel.IsAlive)
                        changeCursor("cursor_can_kill");
                    else
                        changeCursor("cursor_dead");
                }
                else
                {
                    changeCursor("cursor");
                }

                cursor.Draw();
            }
        }

        private void changeCursor(string fdf) 
        {
            cursor = new UISprite("cursor", fdf, new Size(30, 30), new Point(UI.WIDTH / 2, UI.HEIGHT / 2));
        }

        private void SHowHello(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.K)
            {
                showCorsor = !showCorsor;
            }
        }
    }
}
