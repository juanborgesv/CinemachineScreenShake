using UnityEngine;

namespace JuanBorges.ScreenShake
{
    public class SampleScreenShakeTriggerRequester : MonoBehaviour
    {
        [field: SerializeField, Tooltip("The screen shake intensity to request.")]
        public ShakeIntensity ShakeIntensity { get; protected set; }

        public void RequestScreenShake()
        {
            if (ScreenShakeTrigger.Instance == null)
            {
                Debug.LogError("Screen Shake Trigger instance is missing. Please add it to your scene.");
                return;
            }

            ScreenShakeTrigger.Instance.Shake(ShakeIntensity);
        }
    }
}