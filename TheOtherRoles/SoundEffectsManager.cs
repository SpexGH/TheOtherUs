﻿using System;
using System.Collections.Generic;
using System.Reflection;
using TheOtherRoles.Utilities;
using UnityEngine;

namespace TheOtherRoles
{
    // Class to preload all audio/sound effects that are contained in the embedded resources.
    // The effects are made available through the soundEffects Dict / the get and the play methods.
    public static class SoundEffectsManager

    {
        private static Dictionary<string, AudioClip> soundEffects = new();

        public static void Load()
        {
            soundEffects = new Dictionary<string, AudioClip>();
        }

        public static void play(AudioClip audioClip, float volume = 0.8f, bool loop = false)
        {
            if (!TORMapOptions.enableSoundEffects) return;
            AudioClip clipToPlay = audioClip;
            stop(audioClip);
            if (Constants.ShouldPlaySfx() && clipToPlay != null)
            {
                AudioSource source = SoundManager.Instance.PlaySound(clipToPlay, false, volume);
                source.loop = loop;
            }
        }
        public static void playAtPosition(AudioClip audioClip, Vector2 position, float maxDuration = 15f, float range = 5f, bool loop = false)
        {
            if (!TORMapOptions.enableSoundEffects || !Constants.ShouldPlaySfx()) return;
            AudioClip clipToPlay = audioClip;

            AudioSource source = SoundManager.Instance.PlaySound(clipToPlay, false, 1f);
            source.loop = loop;
            HudManager.Instance.StartCoroutine(Effects.Lerp(maxDuration, new Action<float>((p) =>
            {
                if (source != null)
                {
                    if (p == 1)
                    {
                        source.Stop();
                    }
                    float distance, volume;
                    distance = Vector2.Distance(position, CachedPlayer.LocalPlayer.PlayerControl.GetTruePosition());
                    if (distance < range)
                        volume = 1f - (distance / range);
                    else
                        volume = 0f;
                    source.volume = volume;
                }
            })));
        }

        public static void stop(AudioClip audioClip)
        {
            var soundToStop = audioClip;
            if (soundToStop != null)
                if (Constants.ShouldPlaySfx()) SoundManager.Instance.StopSound(soundToStop);
        }

		public static void stopAll()
		{
			SoundManager.Instance.StopAllSound();
		}
	}
}
