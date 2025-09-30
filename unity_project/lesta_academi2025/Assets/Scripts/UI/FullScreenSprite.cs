using UnityEngine;

/// <summary>
/// ��������� ��� ��������������� ��������������� ������� �� ���� �����.
/// </summary>
public class FullScreenSprite : MonoBehaviour
{
    #region Unity Events

    /// <summary>
    /// ��� ������� ����� ������������� ��������� ������ ��� ������� ������.
    /// </summary>
    private void Start()
    {
        AdjustSpriteToScreen();
    }

    #endregion

    #region �������� ������

    /// <summary>
    /// ������������ � ������������� ������ ���, ����� �� ������� ���� �����.
    /// </summary>
    private void AdjustSpriteToScreen()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr == null) return;

        // �������� ������� ������ � ������� �����������
        float worldScreenHeight = Camera.main.orthographicSize * 2;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        // ������������ ������ �� ������ � ������ ������
        Transform spriteTransform = transform;
        Vector3 spriteSize = sr.bounds.size;

        Vector3 scale = spriteTransform.localScale;
        scale.x = worldScreenWidth / spriteSize.x;
        scale.y = worldScreenHeight / spriteSize.y;

        spriteTransform.localScale = scale;

        // ���������� ������ ������������ ������
        spriteTransform.position = new Vector3(
            Camera.main.transform.position.x,
            Camera.main.transform.position.y,
            spriteTransform.position.z
        );
    }

    #endregion
}
