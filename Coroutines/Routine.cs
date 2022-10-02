using System;

namespace MonoBunni.Library.Coroutines
{
    /// <summary>
    /// A routine than can be executed synchronously within a Behavior.
    /// </summary>
    public abstract class Routine
    {
        /// <summary>
        /// Executes the routine.
        /// </summary>
        public abstract void Execute();

        /// <summary>
        /// Updates the routine.
        /// </summary>
        /// <param name="gameTime">The gameTime.</param>
        public virtual void Update(GameTime gameTime) { }

        /// <summary>
        /// Is this routine done?
        /// </summary>
        public bool IsDone { get; protected set; }
    }
}
