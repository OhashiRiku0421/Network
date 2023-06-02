using UnityEngine;
using UnityEngine.UI;

public class Sample2 : MonoBehaviour
{
    [SerializeField]
    private int _count = 5;

    private Image[] _array;

    private int _destroyCount = 0;

    private void Start()
    {
        _array = new Image[_count];

        for (var i = 0; i < _array.Length; i++)
        {
            var obj = new GameObject($"Cell{i}");
            obj.transform.parent = transform;
            var image = obj.AddComponent<Image>();
            if (i == 0) { image.color = Color.red; }
            else { image.color = Color.white; }
            _array[i] = image;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)) // 左キーを押した
        {
            for (int i = 0; i < _array.Length - _destroyCount; i++)
            {
                Debug.Log("qq");
                if (_array[i].color == Color.red)
                {
                    if (i <= 0) return;

                    _array[i].color = Color.white;
                    _array[i - 1].color = Color.red;
                    return;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) // 右キーを押した
        {
            for (int i = 0; i < _array.Length - _destroyCount; i++)
            {
                if (_array[i].color == Color.red)
                {
                    if (i >= _array.Length - 1) return;

                    _array[i].color = Color.white;
                    _array[i + 1].color = Color.red;
                    return;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i].color == Color.red)
                {
                    
                    _array[i].color = Color.white;
                    Destroy(_array[i].gameObject);
                    _destroyCount++;
                    for(int j = i; j < _array.Length - _destroyCount; j++)
                    {
                        _array[j] = _array[j + 1];
                    }
                    if(_destroyCount < _array.Length)
                    {
                        _array[0].color = Color.red;
                    }
                    return;
                }
            }
        }
    }
}