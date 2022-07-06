using System.Collections.Generic;
using UnityEngine;

namespace Asteroids__Atari_.Scripts
{
    public abstract class ObjectPool<T> where T : MonoBehaviour, IPoolable
    {
        protected Stack<T> reusableInstances = new Stack<T>();

        protected T prefabAsset;

        protected Transform objectsParent;

        protected int objectsCount;

        public int InUsing()
        {
            return objectsCount - reusableInstances.Count;
        }

        public ObjectPool(Transform objectsParent, int objectsCount)
        {
            this.objectsParent = objectsParent;

            SetPrefabAsset();

            for (int i = 0; i < objectsCount; i++)
            {
                CreateInstance();
            }
        }

        private void CreateInstance()
        {
            T objectInstance = Object.Instantiate(prefabAsset, objectsParent);
            objectInstance.Realized += (t) => { ReturnToPool((T)t); };
            objectInstance.gameObject.SetActive(false);
            reusableInstances.Push(objectInstance);
            objectsCount++;
        }

        protected abstract void SetPrefabAsset();

        public void ReturnToPool(T instance)
        {
            instance.gameObject.SetActive(false);

            reusableInstances.Push(instance);
        }

        public T GetObjectFromPool()
        {
            if (reusableInstances.Count == 0)
            {
                CreateInstance();
            }

            T retComp = reusableInstances.Pop();
            retComp.gameObject.SetActive(true);

            return retComp;
        }
    }
}