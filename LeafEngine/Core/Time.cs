using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;

namespace Leaf
{
    public class Time
    {
        protected internal static Clock deltaClock { get; set; } = new Clock();
        protected internal static Clock lateClock { get; set; } = new Clock();

        /// <summary>
        /// The time elapsed since the last frame (in seconds)
        /// </summary>
        public static float deltaTime { get; private set; }

        /// <summary>
        /// The time elapsed since the last five frames (i reccomend to use <see cref="Time.deltaTime"/> since this can return crazy values)
        /// </summary>
        public static float lateTime { get; private set; }

        protected internal static void DeltaTick()
        {
            deltaTime = deltaClock.Restart().AsSeconds();
        }

        protected internal static async void LateTick()
        {
            await Task.Delay(5);
            lateTime = lateClock.Restart().AsSeconds();
        }
    }
}
