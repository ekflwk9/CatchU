using System.Collections.Generic;
using UnityEngine;

public static class SoundManager
{
    private static Dictionary<string, AudioClip> sounds = new();
    private static GameObject Instance;

    private static AudioSource musicSource;
    private static AudioSource[] effectSource;
    private static int playEffectCount;

    private static void CheckStart()
    {
        if (Instance == null)
        {
            Instance = new GameObject(Str.SoundManager);
            MonoBehaviour.DontDestroyOnLoad(Instance);

            musicSource = Instance.AddComponent<AudioSource>();
            musicSource.playOnAwake = false;
            musicSource.loop = true;

            effectSource = new AudioSource[10];

            for (int i = 0; i < effectSource.Length; i++)
            {
                effectSource[i] = Instance.AddComponent<AudioSource>();
                effectSource[i].playOnAwake = false;
                effectSource[i].loop = false;
            }

            var loadSounds = Resources.LoadAll<AudioClip>(Str.Sounds);

            for (int i = 0; i < loadSounds.Length; i++)
            {
                sounds.Add(loadSounds[i].name, loadSounds[i]);
            }
        }
    }

    /// <summary>
    /// 배경음 재생
    /// </summary>
    /// <param name="_soundName"></param>
    public static void OnMusic(string _soundName)
    {
        CheckStart();

        if (sounds.ContainsKey(_soundName))
        {
            musicSource.clip = sounds[_soundName];
            musicSource.Play();
        }

        else
        {
            Utility.Log($"{_soundName}는 추가되지 않은 사운드");
        }
    }

    /// <summary>
    /// 효과음 재생
    /// </summary>
    /// <param name="_soundName"></param>
    public static void OnEffect(string _soundName)
    {
        CheckStart();
        if (!sounds.ContainsKey(_soundName)) return;

        playEffectCount++;
        if (effectSource.Length <= playEffectCount) playEffectCount = 0;

        effectSource[playEffectCount].clip = sounds[_soundName];
        effectSource[playEffectCount].Play();
    }
}
