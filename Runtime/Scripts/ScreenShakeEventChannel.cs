using UnityEngine;
using UnityEngine.Events;

namespace JuanBorges.ScreenShake
{
    [CreateAssetMenu(fileName = "Screen Shake Event Channel", menuName = "Scriptable Objects/Event Channels/Screen Shake")]
    public class ScreenShakeEventChannel : ScriptableObject
    {
        public UnityAction<ShakeIntensity> OnShakeRequested;

        /// <summary>
        /// Raises a screen shake event with the specified intensity.
        /// </summary>
        public void RaiseEvent(ShakeIntensity intensity) 
            => OnShakeRequested?.Invoke(intensity);
    }
}
