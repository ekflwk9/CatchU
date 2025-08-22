using UnityEngine;

public static class Utility
{
    /// <summary>
    /// 특정 자식의 컴포넌트를 가져오는 메서드
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_parent"></param>
    /// <param name="_childName"></param>
    /// <returns></returns>
    public static T TryGetChildComponent<T>(this MonoBehaviour _parent, string _childName) where T : Component
    {
        var child = Utility.Find(_parent.transform, _childName);

        if (!child) Utility.Log($"{_parent.name}에 {_childName}이라는 자식 오브젝트는 존재하지 않음");
        else if (child.TryGetComponent<T>(out var _component)) return _component;
        else Utility.Log($"{_childName}에 {typeof(T).Name}이라는 컴포넌트는 존재하지 않음");

        return null;
    }

    /// <summary>
    /// 특정 컴포넌트를 가져오는 예외처리된 메서드
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="_parent"></param>
    /// <returns></returns>
    public static T TryGetComponent<T>(this MonoBehaviour _parent) where T : Component
    {
        if (_parent.TryGetComponent<T>(out var _component)) return _component;
        else Utility.Log($"{_parent.name}에 {typeof(T).Name}이라는 컴포넌트는 존재하지 않음");

        return null;
    }

    /// <summary>
    /// 특정 자식 오브젝트를 반환하는 메서드
    /// </summary>
    /// <param name="_parent"></param>
    /// <param name="_childName"></param>
    public static void TryFindChild(this MonoBehaviour _parent, string _childName)
    {
        var child = Find(_parent.transform, _childName);

        if (!child) Utility.Log($"{_parent.name}에 {_childName}란 자식 오브젝트는 존재하지 않음");
    }

    private static Transform Find(Transform _parent, string _childName)
    {
        Transform findChild = null;

        for (int i = 0; i < _parent.childCount; i++)
        {
            var child = _parent.GetChild(i);
            findChild = _childName == child.name ? child : Find(child, _childName);
            if (findChild) return findChild;
        }

        return null;
    }

    /// <summary>
    /// 에디터 환경에서만 출력하는 Log
    /// </summary>
    /// <param name="_log"></param>
    public static void Log(string _log)
    {
#if UNITY_EDITOR
        Debug.Log(_log);
#endif
    }
}
