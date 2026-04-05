using UnityEngine;

namespace JuanBorges.ScreenShake
{
    [RequireComponent(typeof(ScreenShakeTrigger))]
    public class ScreenShakeTriggerEventListener : MonoBehaviour
    {
        [SerializeField] private ScreenShakeEventChannel _eventChannel;
        private ScreenShakeTrigger _trigger;

        private void Awake() => _trigger = GetComponent<ScreenShakeTrigger>();
        private void OnEnable() => _eventChannel.OnShakeRequested += _trigger.Shake;
        private void OnDisable() => _eventChannel.OnShakeRequested -= _trigger.Shake;
    }
}
