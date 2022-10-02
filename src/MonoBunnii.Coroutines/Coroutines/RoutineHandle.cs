using System.Collections;
using System.Collections.Generic;

namespace MonoBunni.Library.Coroutines
{
    internal class RoutineHandle
    {
        public RoutineHandle(IEnumerable routines)
        {
            Routines = routines.GetEnumerator();
        }

        /// <summary>
        /// The list of active coroutines.
        /// </summary>
        private readonly IEnumerator Routines;

        /// <summary>
        /// Updates the routine.
        /// </summary>
        public void Update(GameTime gameTime)
        {
            var routine = Routines.Current as Routine;

            if (routine == null || routine.IsDone)
            {
                Step();
                return;
            }

            routine.Update(gameTime);
        }

        /// <summary>
        /// Steps forward in the routine.
        /// </summary>
        public void Step()
        {
            if (!Routines.MoveNext())
            {
                return;
            }

            var routine = Routines.Current as Routine;

            if (routine != null)
            {
                routine.Execute();
            }
        }

        /// <summary>
        /// Returns true if the routine cannot proceed any further.
        /// </summary>
        public bool Done
        {
            get { return !Routines.MoveNext(); } 
        }

    }
}