using System.Collections;
using System.Collections.Generic;

namespace MonoBunni.Library.Coroutines
{
    /// <summary>
    /// Manages active coroutines
    /// </summary>
    public class CoroutineManager : GameComponent, ICoroutineManager
    {
        /// <summary>
        /// The list of active coroutines.
        /// </summary>
        private readonly IList<RoutineHandle> Routines;

        /// <summary>
        /// Initializes a new instance of <see cref="CoroutineManager"./>
        /// </summary>
        public CoroutineManager() => Routines = new List<RoutineHandle>();

        /// <summary>
        /// Starts a coroutine with the given coroutine source.
        /// </summary>
        /// <param name="source">The given coroutine source.</param>
        public void StartCoroutine(IEnumerable source)
        {
            var coroutineHandler = new RoutineHandle(source);
            Routines.Add(coroutineHandler);
            coroutineHandler.Step();
        }

        /// <summary>
        /// Updates each coroutine.
        /// </summary>
        /// <param name="gameTime">The gameTime.</param>
        public override void Update(GameTime gameTime)
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
