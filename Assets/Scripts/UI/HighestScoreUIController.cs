using UnityEngine;
using UnityEngine.UI;

public class HighestScoreUIController : MonoBehaviour
{
    private Image image;

    [SerializeField] private Sprite score0;
    [SerializeField] private Sprite score100;
    [SerializeField] private Sprite score200;
    [SerializeField] private Sprite score300;
    [SerializeField] private Sprite score400;
    [SerializeField] private Sprite score500;
    [SerializeField] private Sprite score600;
    [SerializeField] private Sprite score700;
    [SerializeField] private Sprite score800;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    private void Update()
    {
        switch (GameManager.Instance.HighestScore)
        {
            case 0: image.sprite = score0; break;
            case 100: image.sprite = score100; break;
            case 200: image.sprite = score200; break;
            case 300: image.sprite = score300; break;
            case 400: image.sprite = score400; break;
            case 500: image.sprite = score500; break;
            case 600: image.sprite = score600; break;
            case 700: image.sprite = score700; break;
            case 800: image.sprite = score800; break;
        }
    }
}
