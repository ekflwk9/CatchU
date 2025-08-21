using System;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance { get; private set; }
    private Dictionary<Type, UiBase> ui = new();

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            FindComponent(this.transform);
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            DestroyImmediate(this.gameObject);
        }
    }

    private void FindComponent(Transform _parent)
    {
        for (int i = 0; i < _parent.transform.childCount; i++)
        {
            var child = _parent.transform.GetChild(i);
            var component = child.GetComponent<UiBase>();
            if (component) component.Init();

            FindComponent(child);
        }
    }

    /// <summary>
    /// UiManager에 Ui를 등록하는 메서드
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_ui"></param>
    public void Add<T>(UiBase _ui) where T : UiBase
    {
        var key = typeof(T);

        if (!ui.ContainsKey(key)) ui.Add(key, _ui);
        else Utility.Log($"{key.Name}이라는 Ui는 이미 추가된 상태");
    }

    /// <summary>
    /// 등록된 Ui를 가져오는 메서드
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T Get<T>() where T : UiBase
    {
        var key = typeof(T);

        if (ui.ContainsKey(key)) return ui[key] as T;
        else Utility.Log($"{key.Name}이라는 Ui는 현재 추가되지 않음");

        return null;
    }

    /// <summary>
    /// 해당 Ui를 활성화하는 메서드
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void On<T>() where T : UiBase
    {
        var key = typeof(T);

        if (ui.ContainsKey(key)) ui[key].On();
        else Utility.Log($"{key.Name}이라는 Ui는 현재 추가되지 않음");
    }

    /// <summary>
    /// 해당 Ui를 비활성화하는 메서드
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void Off<T>() where T : UiBase
    {
        var key = typeof(T);

        if (ui.ContainsKey(key)) ui[key].Off();
        else Utility.Log($"{key.Name}이라는 Ui는 현재 추가되지 않음");
    }
}
