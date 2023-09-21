using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour
{
    public Button button; // Ссылка на кнопку, на которой будет воспроизводиться звук
    public AudioClip clickSound; // Звук, который будет воспроизводиться

    private AudioSource audioSource;

    private void Start()
    {
        // Получаем компонент AudioSource на этом объекте или создаем новый, если его нет
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Привязываем метод PlayClickSound к событию нажатия кнопки
        button.onClick.AddListener(PlayClickSound);
    }

    private void PlayClickSound()
    {
        // Проверяем, есть ли звук для воспроизведения
        if (clickSound != null)
        {
            // Проигрываем звук при нажатии на кнопку
            audioSource.PlayOneShot(clickSound);
        }
    }
}
