using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArraySample : MonoBehaviour
{
    [SerializeField]
    private int _row = 5;

    [SerializeField]
    private int _column = 5;

    private Image[,] _images;

    private int _selectedIndex;

    private int _selectedIndex2;

    private Image _newImages;

    private void Start()
    {
        _images = new Image[_row, _column];

        for (var r = 0; r < _row; r++)
        {
            for (var c = 0; c < _column; c++)
            {
                var obj = new GameObject($"Cell({r}, {c})");
                obj.transform.parent = transform;

                var image = obj.AddComponent<Image>();
                if (r == 0 && c == 0) { image.color = Color.red; }
                else { image.color = Color.white; }
                _images[r, c] = image;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) && _selectedIndex > 0) // 左キーを押した
        {
            OnSelected(_selectedIndex2, _selectedIndex - 1);
            _selectedIndex--;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && _selectedIndex < _column - 1) // 右キーを押した
        {
            OnSelected(_selectedIndex2, _selectedIndex + 1);
            _selectedIndex++;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && _selectedIndex2 > 0) // 上キーを押した
        {
            OnSelected(_selectedIndex2 - 1, _selectedIndex);
            _selectedIndex2--;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && _selectedIndex2 < _row - 1) // 下キーを押した
        {
            OnSelected(_selectedIndex2 + 1, _selectedIndex);
            _selectedIndex2++;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Destroy(_newImages);
        }
    }

    private void OnSelected(int value2, int value)
    {
        var oldImages = _images[_selectedIndex2, _selectedIndex];
        _newImages = _images[value2, value];
        oldImages.color = Color.white;
        _newImages.color = Color.red;
    }
}
