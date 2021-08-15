using MyNewAsteroids.GameObjects;
using MyNewAsteroids.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using static MyNewAsteroids.Model.BattleJournal;

namespace MyNewAsteroids.Scenes
{
    public class GameScene : BaseScene
    {
        private static List<SpaceObject> asteroids;
        private static List<SpaceObject> stars;
        private static Planet planet;
        private static Background background;
        private static LaserBeam laserBeam;
        private static Ship ship;
        private static Fuel fuel;
        private static BattleJournal battleJournal;
        private static AddNoteToFile addNoteToFileDelegate;
        private static Random random;
        private static readonly Timer timer = new Timer();
        private static int asteroidsCount;
        private static bool wasFuel;
        
        private static RecordsJournal recordsJournal;

        //static GameScene() { }


        public override void Init(Form form)
        {
            base.Init(form);
            Load();

            timer.Interval = 100;
            timer.Start();
            timer.Tick += Timer_Tick;

            Ship.DieEvent += GameOver;
            AddString += BattleJournal_AddString;
            form.FormClosed += Form_FormClosed;

            battleJournal.AddNote($"{DateTime.Now} Игра началась!");
            battleJournal.AddNewString();

        }
        private static void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            battleJournal.AddNote($"{DateTime.Now} Игрок покинул игру.");
            battleJournal.AddNewString();
            battleJournal.End();
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public override void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);

            background.Draw();

            foreach (var star in stars)
                star.Draw();

            planet.Draw();

            foreach (var asteroid in asteroids)
                asteroid?.Draw();

            laserBeam?.Draw();

            if (ship != null)
            {
                ship.Draw();
                Buffer.Graphics.DrawString($"Энергия: {ship.Energy}", SystemFonts.DefaultFont, Brushes.Black, 10, 10);
                Buffer.Graphics.DrawString($"Сбитые астероиды: {ship.DestroyAsteroidsCount}", SystemFonts.DefaultFont, Brushes.Black, 100, 10);
            }

            if (fuel == null && ship.DestroyAsteroidsCount != 0 && ship.DestroyAsteroidsCount % 5 == 0 && wasFuel == false)
            {
                var x = random.Next(100, 300);
                var y = random.Next(100, 300);
                var randomXDir = random.Next(1, 5);
                var randomYDir = random.Next(1, 5);
                fuel = new Fuel(new Point(x, y), new Point(randomXDir, randomYDir));
                wasFuel = true;
            }
            fuel?.Draw();

            Buffer.Render();
        }
        public static void Update()
        {
            if(asteroids.Count == 0)
            {
                asteroidsCount += 2;
                for (int i = 0; i < asteroidsCount; i++)
                {
                    var x = random.Next(100, 700);
                    var y = random.Next(100, 500);
                    var size = random.Next(40, 60);
                    var randomXDir = random.Next(15, 25);
                    var randomYDir = random.Next(15, 25);
                    asteroids.Add(new Asteroid(new Point(x, y), new Point(randomXDir, randomYDir), new Size(size, size)));
                }
            }

            foreach (var asteroid in asteroids)
            {
                asteroid.Update();
            }

            foreach (var asteroid in asteroids)
            {
                if (laserBeam != null && asteroid.Collision(laserBeam))
                {
                    battleJournal.AddNote($"Лазер попал в астероид по координатам X={asteroid.Rectangle.X}, Y={asteroid.Rectangle.Y}");
                    battleJournal.AddNewString();

                    asteroids.Remove(asteroid);
                    laserBeam = null;
                    ship.IncreaseCount();
                    if (wasFuel)
                    {
                        wasFuel = false;
                    }

                    battleJournal.AddNote($"Корабль уничтожил астероид. Счёт - {ship.DestroyAsteroidsCount}");
                    battleJournal.AddNewString();

                    break;
                }
                if (asteroid.Collision(ship))
                {
                    battleJournal.AddNote($"Астероид столкнулся с кораблём по координатам X={asteroid.Rectangle.X}, Y={asteroid.Rectangle.Y}");
                    battleJournal.AddNewString();

                    asteroids.Remove(asteroid);
                    int damage = random.Next(10, 33);
                    ship.DamageShip(damage);
                    ship.IncreaseCount();
                    if (wasFuel)
                    {
                        wasFuel = false;
                    }

                    battleJournal.AddNote($"Корабль получил урон равный {damage}");
                    battleJournal.AddNewString();
                    battleJournal.AddNote($"Корабль уничтожил астероид своим корпусом. Счёт - {ship.DestroyAsteroidsCount}");
                    battleJournal.AddNewString();

                    if (ship.Energy <= 0)
                    {
                        ship.Die();
                    }
                    break;
                }
            }

            foreach (var star in stars)
                star.Update();

            laserBeam?.Update();

            planet.Update();

            fuel?.Update();

            if (fuel != null && laserBeam != null)
            {
                if (ship.Collision(fuel) || laserBeam.Collision(fuel))
                {
                    laserBeam = null;
                    int heal = random.Next(20, 50);
                    ship.HealShip(heal);
                    fuel = null;

                    battleJournal.AddNote($"Корабль подобрал топливо и восстановил {heal} энергии.");
                    battleJournal.AddNewString();
                }
            }
        }
        public static void Load()
        {
            random = new Random();

            background = new Background(new Point(0, 0), new Size(600, 800));

            planet = new Planet(new Point(100, 100), new Point(0, 0));

            asteroidsCount = 8;

            asteroids = new List<SpaceObject>();
            for (int i = 0; i < asteroidsCount; i++)
            {
                var x = random.Next(100, 700);
                var y = random.Next(100, 500);
                var size = random.Next(40, 60);
                var randomXDir = random.Next(15, 25);
                var randomYDir = random.Next(15, 25);
                asteroids.Add(new Asteroid(new Point(x, y), new Point(randomXDir, randomYDir), new Size(size, size)));
            }

            stars = new List<SpaceObject>();
            for (int i = 0; i < 40; i++)
            {
                var x = random.Next(0, 700);
                var y = random.Next(0, 500);
                var size = random.Next(5, 21);
                stars.Add(new Star(new Point(x, y), new Point(-i, -i), new Size(size, size)));
            }

            ship = new Ship(new Point(10, 400), new Point(5, 5));

            battleJournal = new BattleJournal();

            recordsJournal = new RecordsJournal();

            addNoteToFileDelegate = battleJournal.AddNoteInFile;

            wasFuel = false;
        }
        private static void GameOver(object sender, EventArgs e)
        {
            timer.Stop();
            recordsJournal.TryAddRecord(ship.DestroyAsteroidsCount);
            recordsJournal.WriteToFile();
            Buffer.Graphics.DrawString("GAME OVER", new Font(FontFamily.GenericSansSerif, 60, FontStyle.Underline), Brushes.Black, 150, 200);
            Buffer.Render();
            if (fuel != null)
            {
                fuel = null;
            }

            battleJournal.AddNote($"{DateTime.Now} Корабль уничтожен. Игра закончена");
            battleJournal.AddNewString();
            battleJournal.End();
        }
        private static void BattleJournal_AddString(object sender, BattleJournalEventArgs e)
        {
            Debug.WriteLine(DateTime.Now + " " + e.Note);
            addNoteToFileDelegate?.Invoke();
        }
        public override void SceneKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ControlKey)
            {
                laserBeam = new LaserBeam(new Point(ship.Rectangle.X + 128, ship.Rectangle.Y + 30), new Point(0, 0), new Size(10, 40));
            }
            if (e.KeyCode == Keys.Up)
            {
                ship.Up();
            }
            if (e.KeyCode == Keys.Down)
            {
                ship.Down();
            }

            if (e.KeyCode == Keys.Back)
            {
                timer.Stop();
                battleJournal.End();
                Buffer.Dispose();
                Dispose();
                SceneManager                // Обратимся к менеджеру сцен
                    .Get()
                    .Init<MenuScene>(Form) // Проинициализируем меню
                    .Draw();
            }
            if (e.KeyCode == Keys.Escape)
            {
                Form.Close(); // Закрываем форму, завершаем работу приложения
            }
        }
    }
}
