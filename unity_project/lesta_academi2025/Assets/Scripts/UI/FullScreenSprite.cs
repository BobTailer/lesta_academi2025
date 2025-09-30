using UnityEngine;

/// <summary>
/// Компонент для автоматического масштабирования спрайта на весь экран.
/// </summary>
public class FullScreenSprite : MonoBehaviour
{
    #region Unity Events

    /// <summary>
    /// При запуске сцены автоматически подгоняет спрайт под размеры экрана.
    /// </summary>
    private void Start()
    {
        AdjustSpriteToScreen();
    }

    #endregion

    #region Основная логика

    /// <summary>
    /// Масштабирует и позиционирует спрайт так, чтобы он занимал весь экран.
    /// </summary>
    private void AdjustSpriteToScreen()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        // Получаем размеры камеры в мировых координатах
        float worldScreenHeight = Camera.main.orthographicSize * 2;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        // Масштабируем спрайт по ширине и высоте экрана
        Transform spriteTransform = transform;
        Vector3 spriteSize = sr.bounds.size;

        Vector3 scale = spriteTransform.localScale;
        scale.x = worldScreenWidth / spriteSize.x;
        scale.y = worldScreenHeight / spriteSize.y;

        spriteTransform.localScale = scale;

        // Центрируем спрайт относительно камеры
        spriteTransform.position = new Vector3(
            Camera.main.transform.position.x,
            Camera.main.transform.position.y,
            spriteTransform.position.z
        );
    }

    #endregion
}
