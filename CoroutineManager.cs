using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace MonoBunni.Coroutines
{
    /// <summary>
    /// Manages active coroutines
    /// </summary>
    public static class CoroutineManager
    {
        /// <summary>
        /// The list of active coroutines.
        /// </summary>
        private static readonly IList<RoutineHandle> Routines = new List<RoutineHandle>();

        /// <summary>
        /// Starts a coroutine with the given coroutine source.
        /// </summary>
        /// <param name="source">The given coroutine source.</param>
        public static void StartCoroutine(IEnumerable source)
        {
            var coroutineHandler = new RoutineHandle(source);
            Routines.Add(coroutineHandler);
            coroutineHandler.Step();
        }

        /// <summary>
        /// Updates each coroutine.
        /// </summary>
        /// <param name="gameTime">The gameTime.</param>
        public static void Update(GameTime gameTime)
        {
            // Update each coroutine.
            foreach (var routineHandle in Routines)
            {
                routineHandle.Update(gameTime);
            }

            // Clean up finished coroutines.
            foreach(var handle in Routines.Where(handle => handle.Done))
            {
                Routines.Remove(handle);
            }
        }
    }
}
