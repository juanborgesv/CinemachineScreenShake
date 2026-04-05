using UnityEngine;

namespace JuanBorges.ScreenShake
{
    [RequireComponent(typeof(ScreenShakeTrigger))]
    public class ScreenShakeTriggerSingletonProvider : MonoBehaviour
    {
        public static ScreenShakeTrigger Instance { get; private set; }

        private void Awake() => Instance = GetComponent<ScreenShakeTrigger>();
    }
}
