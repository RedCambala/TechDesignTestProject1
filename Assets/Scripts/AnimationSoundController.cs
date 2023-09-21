using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationSoundController : MonoBehaviour
{
    public Animator animator; // Ссылка на компонент Animator
    public AudioClip soundClip; // Звуковой клип для воспроизведения

    private AudioSource audioSource; // Компонент AudioSource для воспроизведения звука

    private int animationStateHash; // Хэш-код состояния анимации, которое мы хотим отслеживать

    private void Start()
    {
        // Получаем компонент AudioSource
        audioSource = GetComponent<AudioSource>();

        // Проверяем, что у нас есть ссылка на компонент Animator
        if (animator == null)
        {
            Debug.LogError("Не установлена ссылка на компонент Animator!");
            enabled = false; // Отключаем скрипт, чтобы избежать ошибок
            return;
        }

        // Получаем хэш-код состояния анимации по его имени
        animationStateHash = Animator.StringToHash("YourAnimationStateName");
    }

    private void Update()
    {
        // Проверяем, активировано ли состояние анимации
        if (animator.GetCurrentAnimatorStateInfo(0).shortNameHash == animationStateHash)
        {
            // Воспроизводим звук, если состояние анимации активировано
            if (!audioSource.isPlaying)
            {
                audioSource.PlayOneShot(soundClip);
            }
        }
    }
}
