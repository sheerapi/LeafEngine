using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using Newtonsoft.Json;
using SFML.Graphics;

namespace Leaf
{
    public class Application
    {
        [JsonProperty]
        protected internal RenderWindow Window { get; private set; }

        /// <summary>
        /// The width of the window
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// The height of the window
        /// </summary>
        public int Height { get; private set; }

        [JsonProperty]
        protected internal List<LDrawable> Drawables { get; set; } = new List<LDrawable>();

        /// <summary>
        /// The maximum of Frames Per Second the window can go
        /// </summary>
        public int FrameRateLimit { get; set; } = 60;

        /// <summary>
        /// Whether the window should have VSync or not
        /// </summary>
        public bool VSync { get; set; } = true;

        [JsonProperty]
        protected internal Scene scene { get; set; }

        /// <summary>
        /// The current (active) window/application
        /// </summary>
        public static Application Default { get; private set; }

        [JsonProperty]
        protected internal ContextSettings settings { get; set; }

        /// <summary>
        /// Gets executed before <see cref="MainLoop()"/> happens (useful for initializing variables and things)
        /// </summary>
        private Action Start { get; set; } = () => { };

        /// <summary>
        /// Gets executed every frame, this wont count as script or GameObject, it will be just code executed
        /// </summary>
        private Action Tick { get; set; } = () => { };

        #region Overloads

        public Application(int width, int height, string title, Scene Scene)
        {
            CreateWindow(width, height, title, Scene, start: () => { }, update: () => { });
        }

        public Application(int width, int height, string title, Scene Scene, bool antiAliasing = true)
        {
            CreateWindow(width, height, title, Scene, antiAliasing, start: () => { }, update: () => { });
        }

        public Application(int width, int height, string title, Scene Scene, Action start, Action update)
        {
            CreateWindow(width, height, title, Scene, start:start, update:update);
        }

        public Application(int width, int height, string title, Scene Scene, bool antiAliasing, Action start, Action update)
        {
            CreateWindow(width, height, title, Scene, antiAliasing, start, update);
        }

        #endregion

        #region Window Creation

        void CreateWindow(int width, int height, string title, Scene Scene, bool antiAliasing = true, Action start = null, Action update = null)
        {
            settings = new ContextSettings()
            {
                AntialiasingLevel = antiAliasing ? (uint)8 : (uint)0
            };

            Window = new RenderWindow(new VideoMode((uint)width, (uint)height), title, Styles.Default, settings);
            Width = (int)Window.Size.Y;
            Height = (int)Window.Size.X;

            Default = this;

            scene = Scene;

            Window.Resized += OnResize;
            Window.Closed += OnClosed;
            Window.JoystickConnected += JoytickConnect;
            Window.LostFocus += Focus;
            Window.GainedFocus += Focus;
            Window.MouseLeft += MouseLeft;
            Window.JoystickDisconnected += JoystickDisconnect;
            Window.KeyPressed += KeyPressed;
            Window.KeyReleased += KeyReleased;
            Window.MouseMoved += MouseMoved;
            Window.MouseButtonPressed += MouseButtonPressed;
            Window.MouseButtonReleased += MouseButtonReleased;
            Tick = update;
            Start = start;

            Logger.Log("Window initialized", Logger.LogLevel.Trace);

            scene.Push(new GameObject(new Script[] { new Camera() }, "Main Camera"));

            Logger.Log("Scene created", Logger.LogLevel.Trace);

            foreach (GameObject gameObject in scene.objects)
            {
                foreach (Script script in gameObject.components)
                {
                    if (script.enabled == true)
                    {
                        script.Start();
                    }
                }
            }

            // Everything after this line gets ignored
            MainLoop();
        }
        #endregion

        #region Events
        private void MouseLeft(object sender, EventArgs e)
        {
            CallGlobalEvent("MouseLeft", new object[] { });
        }

        private void MouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            Input.MouseButtonPressed = e.Button;
            Input.MouseHold = true;
            Input.MousePressed = true;
            Input.MousePressed = false;
        }

        private void MouseButtonReleased(object sender, MouseButtonEventArgs e)
        {
            Input.MouseButtonPressed = e.Button;
            Input.MouseHold = false;
            Input.MousePressed = false;
        }

        private void KeyReleased(object sender, KeyEventArgs e)
        {
            Input.KeyHold = false;
            Input.PressedKey = e.Code;
            Input.KeyPressed = false;
        }

        private void MouseMoved(object sender, MouseMoveEventArgs e)
        {
            Input.mousePosition = new Vector2(e.X, e.Y);
            CallGlobalEvent("MouseMove", new object[] { Input.mousePosition });
        }

        private void KeyPressed(object sender, KeyEventArgs e)
        {
            Input.PressedKey = e.Code;
            Input.KeyHold = true;
            Input.KeyPressed = true;
            Input.KeyPressed = false;
        }

        private void Focus(object sender, EventArgs e)
        {
            CallGlobalEvent("OnFocusChange", new object[] { Window.HasFocus() });
        }

        private void JoytickConnect(object sender, JoystickConnectEventArgs e)
        {
            Logger.Log("A Joystick was connected", Logger.LogLevel.Info);
            CallGlobalEvent("JoystickConnect", new object[] { (int)e.JoystickId });
        }

        private void JoystickDisconnect(object sender, JoystickConnectEventArgs e)
        {
            Logger.Log("A Joystick was connected", Logger.LogLevel.Info);
            CallGlobalEvent("JoystickDisconnect", new object[] { (int)e.JoystickId });
        }

        private void OnClosed(object sender, EventArgs e)
        {
            Window.Close();
            Logger.Log("Window Closed", Logger.LogLevel.Warning);

            CallGlobalEvent("OnWindowClose", Array.Empty<object>());
        }

        void OnResize(object sender, SizeEventArgs e)
        {
            Width = (int)e.Width;
            Height = (int)e.Height;

            Logger.Log("Window Is Being Resized", Logger.LogLevel.Trace);

            CallGlobalEvent("OnWindowResize", new object[] { new Vector2(e.Width, e.Height) });
        }

        void CallGlobalEvent(string name, object[] parameters)
        {
            if (scene.objects == null) return;

            if (scene.objects.Length > 0)
            {
                foreach (GameObject gameObject in scene.objects)
                {
                    if (gameObject.components.Length > 0)
                    {
                        foreach (Script script in gameObject.components)
                        {
                            if (script.enabled == true)
                            {
                                script.GetType().GetMethod(name).Invoke(script, parameters);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region Main Loop

        private async void Render()
        {
            foreach (LDrawable drawable in Drawables)
            {
                RenderStates renderStates = new RenderStates(drawable.BlendMode);
                
                if (drawable.Shader != null)
                {
                    renderStates.Shader = drawable.Shader;
                }

                Window.Draw(drawable.Drawable, renderStates);
            }

            await Task.Delay(15);
        }

        async Task<Task> MainLoop()
        {
            Start();

            while (Window.IsOpen == true)
            {
                Window.DispatchEvents();

                Window.Clear(new SFML.Graphics.Color((byte)Camera.main.backgroundColor.r, (byte)Camera.main.backgroundColor.g, (byte)Camera.main.backgroundColor.b, (byte)Camera.main.backgroundColor.a));

                Window.SetFramerateLimit((uint)FrameRateLimit);

                Render();

                UpdateScripts();

                Tick();

                Width = (int)Window.Size.X;
                Height = (int)Window.Size.Y;

                TimeEvents();

                Window.SetVerticalSyncEnabled(VSync);
                
                Window.Display();
            }

            return Task.CompletedTask;
        }

        async void UpdateScripts()
        {
            if (scene.objects == null) return;
            
            if (scene.objects.Length > 0)
            {
                foreach (GameObject gameObject in scene.objects)
                {
                    if (gameObject.components.Length > 0)
                    {
                        foreach (Script script in gameObject.components)
                        {
                            if (script.enabled == true)
                            {
                                script.Update();
                            }
                            await Task.Delay(15);
                        }
                    }
                }
            }
        }

        public void TimeEvents()
        {
            Time.DeltaTick();
            Time.LateTick();
        }

        #endregion

        #region Window Methods

        public void UpdateCursor(byte[] cursor, Vector2 cursorSize, Vector2 cursorHotspot)
        {
            Window.SetMouseCursor(new Cursor(cursor, new SFML.System.Vector2u((uint)cursorSize.x, (uint)cursorSize.y), new SFML.System.Vector2u((uint)cursorHotspot.x, (uint)cursorHotspot.y)));
        }

        public void SetCursorAsGrabbed(bool grabbed)
        {
            Window.SetMouseCursorGrabbed(grabbed);
        }

        public void UpdateTitle(string title)
        {
            Window.SetTitle(title);
        }

        public void SuscribeDrawable(LDrawable drawable)
        {
            Drawables.Add(drawable);
        }

        public void UpdateIcon(byte[] icon)
        {
            Texture iconTex = new Texture(icon);
            Window.SetIcon(iconTex.Size.X, iconTex.Size.Y, icon);
        }

        #endregion

        /// <summary>
        /// Returns a JSON string that represents the current object
        /// </summary>
        /// <returns><see cref="string"/></returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, this.GetType(), Formatting.Indented, new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }
    }
}
