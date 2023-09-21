using UnityEngine;
using System.Collections;

public class RotateObjectInLoop : MonoBehaviour
{
    public float targetRotationY = 90f; // Целевой угол вращения по оси Y (в градусах)
    public float rotationDuration = 2.0f; // Время, за которое нужно выполнить вращение

    private float startRotationY; // Начальный угол вращения
    private float currentRotationY; // Текущий угол вращения
    private float startTime; // Время начала вращения
    private bool isForward = true; // Флаг, указывающий направление вращения

    private void Start()
    {
        // Запоминаем начальный угол вращения
        startRotationY = transform.eulerAngles.y;
        currentRotationY = startRotationY;

        // Запускаем корутину для цикличного вращения объекта
        StartCoroutine(RotateObject());
    }

    private IEnumerator RotateObject()
    {
        while (true) // Бесконечный цикл для цикличного вращения
        {
            startTime = Time.time;

            while (Time.time - startTime < rotationDuration)
            {
                float progress = (Time.time - startTime) / rotationDuration;

                if (isForward)
                {
                    currentRotationY = Mathf.Lerp(startRotationY, targetRotationY, progress);
                }
                else
                {
                    currentRotationY = Mathf.Lerp(targetRotationY, startRotationY, progress);
                }

                Vector3 newRotation = transform.eulerAngles;
                newRotation.y = currentRotationY;
                transform.eulerAngles = newRotation;

                yield return null;
            }

            // Убедитесь, что целевой угол установлен точно после завершения вращения
            currentRotationY = isForward ? targetRotationY : startRotationY;

            // Инвертируем направление вращения
            isForward = !isForward;
        }
    }
}
