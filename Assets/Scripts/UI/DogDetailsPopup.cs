using UnityEngine;
using UnityEngine.UI;
using Zenject;
using DG.Tweening;

public class DogDetailsPopup : MonoBehaviour
{
    public Text titleText;
    public Text descriptionText;
    public Button closeButton;
    public RectTransform contentRect;

    // ��������� ��������
    public float animationDuration = 0.3f;
    public float padding = 20f; // ������ ��� ���������� �������� ������

    private float initialHeight;

    private void Awake()
    {
        if (closeButton != null)
            closeButton.onClick.AddListener(Hide);

        // ��������� �������� ������, ����� ����� ���� � ������������ ��� �������� ������
        initialHeight = contentRect.sizeDelta.y;
        // ��������� ��������� ���� � �������
        gameObject.SetActive(false);
    }

    public void Show(string breedName, string breedDescription)
    {
        gameObject.SetActive(true);

        if (titleText != null)
            titleText.text = breedName;
        if (descriptionText != null)
            descriptionText.text = breedDescription;

        // ��������� ���������������� ������ ��� ������� ���������� ��������
        float titleHeight = titleText != null ? LayoutUtility.GetPreferredHeight(titleText.rectTransform) : 0f;
        float descriptionHeight = descriptionText != null ? LayoutUtility.GetPreferredHeight(descriptionText.rectTransform) : 0f;

        float targetHeight = titleHeight + descriptionHeight + padding;

        // ��������� ��������� ������ contentRect � ������������ ������
        contentRect.DOSizeDelta(new Vector2(contentRect.sizeDelta.x, targetHeight), animationDuration);
    }

    public void Hide()
    {
        // ��������� ����������� � �������� ������, ����� ���� ��������� ����
        contentRect.DOSizeDelta(new Vector2(contentRect.sizeDelta.x, initialHeight), animationDuration)
            .OnComplete(() => gameObject.SetActive(false));
    }

    public class Factory : PlaceholderFactory<DogDetailsPopup> { }
}