using UnityEngine;
using System.Collections;


public class ChangeColorAlphaOverTime : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Ссылка на SpriteRenderer объекта, цвет которого нужно изменить
    public Color startColor = Color.white; // Начальный цвет
    public Color targetColor = Color.red; // Целевой цвет
    public float duration = 2.0f; // Время, за которое должен измениться цвет
    public bool loop = true; // Включить цикл изменения цвета

    private float startTime;
    private bool isForward = true; // Флаг, определяющий направление изменения цвета

    private void Start()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        // Установка начального цвета
        spriteRenderer.color = startColor;

        // Запуск корутины для изменения цвета
        startTime = Time.time;
        StartCoroutine(ChangeColor());
    }

    private IEnumerator ChangeColor()
    {
        while (loop || isForward) // Проверяем, нужно ли продолжать цикл
        {
            float progress = (Time.time - startTime) / duration;

            if (isForward)
            {
                spriteRenderer.color = Color.Lerp(startColor, targetColor, progress);
            }
            else
            {
                spriteRenderer.color = Color.Lerp(targetColor, startColor, progress);
            }

            if (progress >= 1.0f)
            {
                // Переключаем направление изменения цвета
                isForward = !isForward;
                startTime = Time.time;

                // Если выключен цикл, завершаем корутин
                if (!loop && !isForward)
                {
                    yield break;
                }
            }

            yield return null;
        }
    }
}