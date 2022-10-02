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
            var handler = new RoutineHandle(source);
            Routines.Add(handler);
            handler.Step();
        }

        /// <summary>
        /// Updates this <see cref="GameComponent"/>
        /// </summary>
        /// <param name="gameTime"></param>
        public override void Update(GameTime gameTime)
        {
            Routines.ForEach(routineHandle => routineHandle.Update(gameTime));
            foreach(var handle in Routines.Where(handle => handle.Done))
            {
                Routines.Remove(handle);
            }
        }
    }
}
