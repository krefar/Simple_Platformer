using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Button))]
[RequireComponent(typeof(Image))]
public class ButtonColorer : MonoBehaviour
{
    [SerializeField] private Color _colorClickDown;
    
    private Button _button;
    private Image _image;

    private void Awake()
    {
        _button = GetComponent<Button>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _image.tintColor = _colorClickDown;
        }
    }
}