using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using _Project.Scripts.Clicker;

public class AnimationObjectsPool
{
    private readonly Queue<Image> _pool = new Queue<Image>();
    private readonly Image _prefab;
    private readonly Transform _parent;

    public AnimationObjectsPool(Transform parent, 
        AnimationsData data)
    {
        _parent = parent;
        _prefab = data.PrefabAnimationObject;
        InitializePool(data.CountAnimateObjects);
    }

    private void InitializePool(int size)
    {
        for (int i = 0; i < size; i++)
        {
            CreateNewImage();
        }
    }

    private Image CreateNewImage()
    {
        var image = Object.Instantiate(_prefab, _parent);
        image.gameObject.SetActive(false);
        _pool.Enqueue(image);
        return image;
    }

    public Image Get()
    {
        if (_pool.Count == 0)
        {
            CreateNewImage();
        }

        var image = _pool.Dequeue();
        image.gameObject.SetActive(true);
        return image;
    }

    public void Return(Image image)
    {
        image.gameObject.SetActive(false);
        image.transform.SetParent(_parent);
        _pool.Enqueue(image);
    }

    public void Prewarm(int count)
    {
        for (int i = 0; i < count; i++)
        {
            CreateNewImage();
        }
    }
}