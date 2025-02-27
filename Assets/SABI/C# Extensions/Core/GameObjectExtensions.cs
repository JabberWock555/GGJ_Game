using UnityEngine;

namespace SABI
{
    public static class GameObjectExtensions
    {
        public static T GetOrAddComponent<T>(this GameObject gameObject)
            where T : Component
        {
            if (!gameObject.TryGetComponent<T>(out var attachedComponent))
            {
                attachedComponent = gameObject.AddComponent<T>();
            }

            return attachedComponent;
        }

        public static bool HasComponent<T>(this GameObject gameObject)
            where T : Component => gameObject.TryGetComponent<T>(out _);

        public static void ToggleActive(this GameObject gameObject) =>
            gameObject.SetActive(!gameObject.activeSelf);

        public static void DestroyAllChildren(this GameObject gameObject)
        {
            foreach (Transform child in gameObject.transform)
            {
                if (Application.isPlaying)
                    GameObject.Destroy(child.gameObject);
                else
                    GameObject.DestroyImmediate(child.gameObject);
            }
        }

        public static void AddComponentIfMissing<T>(this GameObject gameObject)
            where T : Component
        {
            if (gameObject.GetComponent<T>() == null)
                gameObject.AddComponent<T>();
        }

        public static bool TryGetComponentInChildren<T>(
            this GameObject gameObject,
            out T component,
            bool includeInactive = false
        )
            where T : Component
        {
            component = gameObject.GetComponentInChildren<T>(includeInactive);
            return component != null;
        }

        public static bool TryGetComponentInParent<T>(
            this GameObject gameObject,
            out T component,
            bool includeInactive = false
        )
            where T : Component
        {
            component = gameObject.GetComponentInParent<T>(includeInactive);
            return component != null;
        }
    }
}
