using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace IGS1Consol
{

    class Program
    {
      
      
        class Game : GameWindow
        {
            static float NextFloat(Random random)
            {
                double mantissa = (random.NextDouble() * 2.0) - 1.0;
                double exponent = Math.Pow(2.0, random.Next(-1, 1));
                return (float)(mantissa * exponent);
            }

            // float x= rnd.Next(0, this.Width) * 0.0001f,  
            ////       y= rnd.Next(0, this.Height) * 0.0001f,
            //      radius = rnd.Next(0,this.Height) * 0.001f;
            //Создание объекта для генерации чисел

            //Получить очередное (в данном случае - первое) случайное число

            //Вывод полученного числа в консоль

            //    GL.Enable(EnableCap.Blend);
            //  GL.BlendFunc(BlendingFactor.SrcAlpha, BlendingFactor.OneMinusSrcAlpha);
            void setrectangle()
            {
                Random random=new Random();
                float width = NextFloat(random);
                float height = NextFloat(random);
                point1.X = NextFloat(random);
                point1.Y = NextFloat(random);
                point2.X = point1.X+width;
                point2.Y = point1.Y;
                point3.X = point2.X;
                point3.Y = point2.Y+height;
                point4.X = point1.X;
                point4.Y = point3.Y;
                rectangle.width = width;
                rectangle.height = height;
            }
            void setrandcircle()
            {
                Random random = new Random();
                circle.X = NextFloat(random);
                circle.Y = NextFloat(random);
                circle.Radius = NextFloat(random);

            }
            public float dx = 0.003f;
            public float dy = 0.003f;
            public  Point point1 = new Point();
            public  Point point2 = new Point();
            public  Point point3 = new Point();
            public  Point point4 = new Point();
            public Rectangle rectangle = new Rectangle(point1, point2, point3, point4);
            public Circle circle = new Circle();

            public Game()
                : base(800, 800, GraphicsMode.Default, "OpenTK Quick Start Sample")
            {
                VSync = VSyncMode.On;


            }
           
           
            

        protected override void OnLoad(EventArgs e)
            {
                base.OnLoad(e);
                GL.ClearColor(0.1f, 0.2f, 0.5f, 0.0f);
                GL.Enable(EnableCap.DepthTest);
                setrectangle();
                setrandcircle();
                if (checkall())
                //  if (isCircleToRect(circle.X, circle.Y, circle.Radius, rectangle.ver4.X, rectangle.ver4.Y, rectangle.ver4.X - rectangle.ver3.X, rectangle.ver4.Y - rectangle.ver1.Y))
                { Console.WriteLine("пересеклося"); Exit(); }
            }

            protected override void OnResize(EventArgs e)
            {
                base.OnResize(e);

                GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);

                Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);
                GL.MatrixMode(MatrixMode.Projection);
                //   GL.LoadMatrix(ref projection);
            }

            protected override void OnUpdateFrame(FrameEventArgs e)
            {
                base.OnUpdateFrame(e);
                
            }

      

            protected override void OnRenderFrame(FrameEventArgs e)
            {

                base.OnRenderFrame(e);

                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                GL.MatrixMode(MatrixMode.Modelview);
                Color4 red = new Color4(1f, 0f, 0f, 0.9f);
                DrawRandRectangle(red);
                Color4 green = new Color4(0f, 1f, 0f, 0f);
                DrawRandomCircle(green);
                //    Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);

                //   GL.LoadMatrix(ref modelview);

                //    GL.Begin(BeginMode.Points);

                // DrawRandomCircle(yellow);
                //DrawRandRectangle(yellow);


                //   GL.Color3(1.0f, 1.0f, 0.0f); GL.Vertex2(-1.0f, -1.0f);
                //   GL.Color3(1.0f, 0.0f, 0.0f); GL.Vertex2(1.0f, -1.0f);
                //   GL.Color3(0.2f, 0.9f, 1.0f); GL.Vertex2(0.0f, 1.0f);
                //   GL.Color3(0.2f, 0.9f, 1.0f); GL.Vertex2(2.0f, 1.0f);
                //    GL.End();

                //if (canDraw)
                //{
                //    foreach (var p in points)
                //    {
                //        GL.Begin(BeginMode.Points);
                //        // Pass coordinates of the point to a_Position
                //        GL.Color3(1.0f, 1.0f, 0.0f);
                //        GL.Vertex2(p.X, p.Y);
                //        GL.End();
                //        // Draw the point
                //        //   GL.DrawArrays(PrimitiveType.Points, 0, 1);

                //        // Draw the line
                //        DrawPolygon(points);
                //        if (points.Count % 4 == 0)
                //        {
                //            //bool d = checkIntersectionOfTwoLineSegments(points[points.Count - 4], points[points.Count - 3], points[points.Count - 2], points[points.Count - 1]);
                //            //if (d)
                //            //{
                //            //    Point IX = Intersection(points[points.Count - 4], points[points.Count - 3], points[points.Count - 2], points[points.Count - 1]);
                //            //    Color4 yellow = new Color4(1f, 1f, 0f, 0f);
                //            //    DrawCircle(IX.X, IX.Y, 0.1f, yellow);

                //            //}
                //            //else
                //            //{
                //            //    Color4 red = new Color4(1.0f, 0f, 0f, 0f);
                //            //    DrawCircle(Width / 2 * 0.0001f, Height / 2 * 0.0001f, 0.1f, red);

                //            //}

                //        }

                //    }



                //}



                SwapBuffers();
            }


            protected override void OnKeyDown(KeyboardKeyEventArgs e)
            {
                base.OnKeyDown(e);
                switch (e.Key)
                {
                    case Key.Down: //action
                        {
                            Move("down");
                         
                        }
                        break;
                    case Key.Right:
                        {
                           
                            Move("right");
                        }//action
                        break;
                    case Key.Up:
                        {
                           
                            Move("up");
                        }
                        break;
                    case Key.Left:
                        {
                           
                            Move("left");
                        }
                        break;
                    case Key.Escape:
                        {
                            Exit();
                        }
                        break;
                }
            }

            private void Move(string where)
            {
                switch (where)
                {
                    case "down": //action
                        {
                            Console.WriteLine("нажато вниз");
                            rectangle.ver1.Y = rectangle.ver1.Y - dy;
                            rectangle.ver2.Y = rectangle.ver2.Y - dy;
                            rectangle.ver3.Y = rectangle.ver3.Y - dy;
                            rectangle.ver4.Y = rectangle.ver4.Y - dy;
                            if (checkall())
                            //   if (isCircleToRect(circle.X, circle.Y, circle.Radius, rectangle.ver4.X, rectangle.ver4.Y, rectangle.ver4.X - rectangle.ver3.X, rectangle.ver4.Y - rectangle.ver1.Y))
                            { Console.WriteLine("пересеклося"); Exit(); }
                        }
                        break;
                    case "right":
                        {
                            Console.WriteLine("нажато вправо");
                            rectangle.ver1.X = rectangle.ver1.X + dx;
                            rectangle.ver2.X = rectangle.ver2.X + dx;
                            rectangle.ver3.X = rectangle.ver3.X + dx;
                            rectangle.ver4.X = rectangle.ver4.X + dx;
                            if (checkall())
                            //  if (isCircleToRect(circle.X, circle.Y, circle.Radius, rectangle.ver4.X, rectangle.ver4.Y, rectangle.ver4.X - rectangle.ver3.X, rectangle.ver4.Y - rectangle.ver1.Y))
                            { Console.WriteLine("пересеклося"); Exit(); }

                        }

                        break;
                    case "up":
                        {
                            Console.WriteLine("нажато вверх");
                            rectangle.ver1.Y = rectangle.ver1.Y + dy;
                            rectangle.ver2.Y = rectangle.ver2.Y + dy;
                            rectangle.ver3.Y = rectangle.ver3.Y + dy;
                            rectangle.ver4.Y = rectangle.ver4.Y + dy;
                            if (checkall())
                            //  if (isCircleToRect(circle.X, circle.Y, circle.Radius, rectangle.ver4.X, rectangle.ver4.Y, rectangle.ver4.X - rectangle.ver3.X, rectangle.ver4.Y - rectangle.ver1.Y))
                            { Console.WriteLine("пересеклося"); Exit(); }
                        }
                        break;
                    case "left":
                        {
                            Console.WriteLine("нажато влево");
                            rectangle.ver1.X = rectangle.ver1.X - dx;
                            rectangle.ver2.X = rectangle.ver2.X - dx;
                            rectangle.ver3.X = rectangle.ver3.X - dx;
                            rectangle.ver4.X = rectangle.ver4.X - dx;
                            if (checkall())
                            //  if (isCircleToRect(circle.X, circle.Y, circle.Radius, rectangle.ver4.X, rectangle.ver4.Y, rectangle.ver4.X - rectangle.ver3.X, rectangle.ver4.Y - rectangle.ver1.Y))
                            { Console.WriteLine("пересеклося");
                                Exit();
                            }
                        }
                        break;
                }
            }

         
            public  void DrawRandomCircle( Color4 c)
            {
              
                GL.Begin(PrimitiveType.TriangleFan);
                GL.Color4(c);

                GL.Vertex2(circle.X, circle.Y);
                for (int i = 0; i < 360; i++)
                {
                    GL.Color4(c);
                    GL.Vertex2(circle.X + Math.Cos(i) * circle.Radius, circle.Y + Math.Sin(i) * circle.Radius);
                }

                GL.End();
             
            }

         
            public static bool intersect(Rectangle r, Circle c)
            {

                float testX = c.X;
                float testY = c.Y;

                if (testX < r.ver1.X)
                    testX = r.ver1.X;
                if (testX > (r.ver1.X + r.width))
                    testX = (r.ver1.X + r.width);

                if (testY < r.ver1.Y)
                    testY = r.ver1.Y;
                if (testY > (r.ver1.Y + r.height))
                    testY = (r.ver1.Y + r.height);

                return ((c.X - testX) * (c.X - testX) + (c.Y - testY) * (c.Y - testY)) < c.Radius * c.Radius;
            }
            public static bool intersect2(Rectangle r, Circle c)
            {

                float testX = c.X;
                float testY = c.Y;

                if (testX < r.ver2.X)
                    testX = r.ver2.X;
                if (testX > (r.ver2.X - r.width))
                    testX = (r.ver2.X - r.width);

                if (testY < r.ver2.Y)
                    testY = r.ver2.Y;
                if (testY > (r.ver2.Y + r.height))
                    testY = (r.ver2.Y + r.height);

                return ((c.X - testX) * (c.X - testX) + (c.Y - testY) * (c.Y - testY)) < c.Radius * c.Radius;
            }
            public static bool intersect3(Rectangle r, Circle c)
            {

                float testX = c.X;
                float testY = c.Y;

                if (testX < r.ver3.X)
                    testX = r.ver3.X;
                if (testX > (r.ver3.X - r.width))
                    testX = (r.ver3.X - r.width);

                if (testY < r.ver3.Y)
                    testY = r.ver3.Y;
                if (testY > (r.ver3.Y - r.height))
                    testY = (r.ver3.Y - r.height);

                return ((c.X - testX) * (c.X - testX) + (c.Y - testY) * (c.Y - testY)) < c.Radius * c.Radius;
            }
            public static bool intersect4(Rectangle r, Circle c)
            {

                float testX = c.X;
                float testY = c.Y;

                if (testX < r.ver4.X)
                    testX = r.ver4.X;
                if (testX > (r.ver4.X + r.width))
                    testX = (r.ver4.X + r.width);

                if (testY < r.ver4.Y)
                    testY = r.ver4.Y;
                if (testY > (r.ver4.Y - r.height))
                    testY = (r.ver4.Y - r.height);

                return ((c.X - testX) * (c.X - testX) + (c.Y - testY) * (c.Y - testY)) < c.Radius * c.Radius;
            }

            bool checkall()
            {
                bool first = intersect(rectangle, circle);
                    bool second = intersect2(rectangle, circle);
                     bool third = intersect3(rectangle, circle);
                    bool four = intersect4(rectangle, circle);
                return (first || second || third || four);
                
              
                  
            }

           

            public void DrawRandRectangle(Color4 c)
            {
                
                GL.Begin(PrimitiveType.Quads);
                GL.Color4(c);
                GL.Vertex2(rectangle.ver1.X, rectangle.ver1.Y);
                GL.Vertex2(rectangle.ver2.X, rectangle.ver2.Y);
                GL.Vertex2(rectangle.ver3.X, rectangle.ver3.Y);
                GL.Vertex2(rectangle.ver4.X, rectangle.ver4.Y);
                GL.End();

            }


       

            [STAThread]
            static void Main()
            {
                // The 'using' idiom guarantees proper resource cleanup.
                // We request 30 UpdateFrame events per second, and unlimited
                // RenderFrame events (as fast as the computer can handle).
                using (Game game = new Game())
                {
                    game.Run(30.0);
                
                }
            }
        }
    }
}
