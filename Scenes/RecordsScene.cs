﻿using MyNewAsteroids.GameObjects;
using MyNewAsteroids.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyNewAsteroids.Scenes
{
    class RecordsScene : BaseScene
    {
        private static Background background;
        private static List<SpaceObject> stars;
        private static Random random;
        private static readonly Timer timer = new Timer();
        private static Ship ship;
        private static Planet planet;
        private static RecordsList recordsList;

        public override void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            background.Draw();

            foreach (var star in stars)
                star.Draw();
            planet.Draw();
            ship.Draw();
            recordsList.Draw();
            Buffer.Render();
        }
        private void Load()
        {
            random = new Random();
            background = new Background(new Point(0, 0), new Size(600, 800));
            stars = new List<SpaceObject>();
            for (int i = 0; i < 40; i++)
            {
                var x = random.Next(0, 700);
                var y = random.Next(0, 500);
                var size = random.Next(5, 21);
                stars.Add(new Star(new Point(x, y), new Point(-i, -i), new Size(size, size)));
            }
            planet = new Planet(new Point(100, 100), new Point(0, 0));
            ship = new Ship(new Point(10, 400), new Point(5, 5));
            recordsList = new RecordsList();
        }
        public static void Update()
        {
            foreach (var star in stars)
                star.Update();
            planet.Update();
            ship.Update();
        }
        public override void Init(Form form)
        {
            base.Init(form);
            Load();

            timer.Interval = 100;
            timer.Start();
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        public override void SceneKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Form.Close(); // Закрываем форму, завершаем работу приложения
            }
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Back)
            {
                timer.Stop();
                Buffer.Dispose();
                Dispose();
                SceneManager                // Обратимся к менеджеру сцен
                    .Get()
                    .Init<MenuScene>(Form) // Проинициализируем сцену с меню
                    .Draw();
            }
        }
    }
}
