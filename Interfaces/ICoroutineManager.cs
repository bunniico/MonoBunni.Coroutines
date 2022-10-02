using System.Collections;

namespace MonoBunni.Coroutines
{
    /// <summary>
    /// Executes and manages coroutines
    /// </summary>
    public interface ICoroutineManager
    {
        /// <summary>
        /// Starts a Couroutine.
        /// </summary>
        /// <param name="source">The source coroutine to be started.</param>
        void StartCoroutine(IEnumerable source);
    }
}