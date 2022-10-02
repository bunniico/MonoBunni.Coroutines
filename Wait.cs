using System;
using Microsoft.Xna.Framework;

namespace MonoBunni.Coroutines
{
    /// <summary>
    /// Pauses execution of a coroutine for the specified interval.
    /// </summary>
    public class Wait : Routine
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Wait()
        {
            Interval = TimeSpan.Zero;
        }

        /// <summary>
        /// Waits until the next Update cycle to continue execution.
        /// </summary>
        /// <returns>null.</returns>
        public static Wait ForNextUpdate()
        {
            return new Wait
            {
                Interval = TimeSpan.FromMilliseconds(0)
            };
        }

        /// <summary>
        /// Waits for the specified amount of seconds in game time.
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        public static Wait Seconds(double seconds)
        {
            return new Wait
            {
                Interval = TimeSpan.FromSeconds(seconds)
            };
        }

        ///<summary>
        /// The amount of time elapsed.
        ///</summary>
        private TimeSpan elapsedTime;

        /// <summary>
        /// Resets the elapsedTime to zero.
        /// </summary>
        public override void Execute()
        {
            elapsedTime = TimeSpan.Zero;
        }

        /// <summary>
        /// Performs a check to see if the amount of elapsed time is greater than or equal to the requested amount of time to be taken.
        /// </summary>
        /// <param name="gameTime">The gameTime.</param>
        public override void Update(GameTime gameTime)
        {
            elapsedTime = elapsedTime.Add(gameTime.ElapsedGameTime);

            if (elapsedTime.TotalMilliseconds >= Interval.TotalMilliseconds)
            {
                IsDone = true;
            }
        }

        /// <summary>
        /// The amount of time to wait.
        /// </summary>
        public TimeSpan Interval { get; set; }
    }
}