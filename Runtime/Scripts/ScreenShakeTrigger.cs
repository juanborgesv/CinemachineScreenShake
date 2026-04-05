using System;
using System.Collections.Generic;

using UnityEngine;
using Cinemachine;

namespace JuanBorges.ScreenShake
{
    public class ScreenShakeTrigger : MonoBehaviour
    {
        [Serializable]
        public struct ShakeProfile
        {
            public ShakeIntensity type;
            public CinemachineImpulseSource source;
        }

        [SerializeField, Tooltip("A collection of shake intensity profiles paired with their respective Cinemachine Impulse Sources. Ensure each type is unique to avoid initialization errors.")]
        private List<ShakeProfile> _shakeTriggers = new();

        private Dictionary<ShakeIntensity, CinemachineImpulseSource> _sourceMap;

        private void Awake() => InitializeDictionary();

        /// <summary>
        /// Converts the list of shake profiles into a dictionary for optimized runtime lookups.
        /// </summary>
        private void InitializeDictionary()
        {
            _sourceMap = new Dictionary<ShakeIntensity, CinemachineImpulseSource>();

            foreach (var profile in _shakeTriggers)
            {
                if (profile.source == null)
                {
                    Debug.LogWarning($"ScreenShakeManager: The source for '{profile.type}' is unassigned.", this);
                    continue;
                }

                // Safely add to the dictionary, ignoring duplicates.
                if (!_sourceMap.ContainsKey(profile.type))
                    _sourceMap.Add(profile.type, profile.source);
                else
                    Debug.LogWarning($"Duplicated types of shake intensities found. Duplicated type: {profile.type}");
            }
        }

        /// <summary>
        /// Fires a screen shake event of the specified intensity.
        /// </summary>
        /// <param name="type">The type of intensity to play.</param>
        public void Shake(ShakeIntensity type)
        {
            // Find impulse associated with the type given to produce the screen shake.
            if (_sourceMap.TryGetValue(type, out var impulseSource))
                impulseSource.GenerateImpulse();
            else
                Debug.LogWarning($"Screen shake failed: No valid impulse source mapped for type {type}.", this);
        }
    }
}