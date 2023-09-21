using UnityEngine;

public class PlayAnimationOnMouseClick2D : MonoBehaviour
{
    public string animationTriggerName = "PlayAnimation"; // Имя триггера анимации
    private Animator animator; // Ссылка на компонент Animator
    private bool isMouseOver; // Флаг, показывающий, что курсор мыши находится внутри зоны триггера

    private void Start()
    {
        // Получаем компонент Animator из объекта
        animator = GetComponent<Animator>();

        // Проверяем, есть ли компонент Animator на объекте
        if (animator == null)
        {
            Debug.LogError("Animator component not found on the object.");
            enabled = false; // Отключаем скрипт, если компонент Animator отсутствует
        }
    }

    private void Update()
    {
        if (isMouseOver && Input.GetMouseButtonDown(0))
        {
            // Если курсор мыши находится внутри зоны триггера и была нажата левая кнопка мыши
            // Запускаем анимацию с использованием триггера
            animator.SetTrigger(animationTriggerName);
        }
    }

    private void OnMouseEnter()
    {
        // Вызывается, когда курсор мыши входит в зону триггера
        isMouseOver = true;
    }

    private void OnMouseExit()
    {
        // Вызывается, когда курсор мыши покидает зону триггера
        isMouseOver = false;
    }
}
