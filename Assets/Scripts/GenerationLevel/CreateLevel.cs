using System;
using System.Collections.Generic;
using FildPointer;
using UnityEngine;
using Random = System.Random;
namespace GenerationLevel
{
    public class CreateLevel : MonoBehaviour
    {
        [SerializeField] private GameObject _startPlatform;
        [SerializeField] private GameObject[] _platform;
        [SerializeField] private GameObject _player;
        [SerializeField] private GameObject _parentGameObject;
        private List<Vector3> _listPositionCreatPrefabs;

        private void Start()
        {
            _listPositionCreatPrefabs = new List<Vector3>();
            Instantiate(_startPlatform, _parentGameObject.transform);
            Instantiate(_player);
            _listPositionCreatPrefabs.Add(_startPlatform.transform.position);
            SearchForFreePointers(_listPositionCreatPrefabs,_parentGameObject,_platform);
        }

        private void SearchForFreePointers(List<Vector3> listPositionCreatPrefabs, GameObject parentGameObject,GameObject[] platform)
        {
            bool flag = true;
            for (int i = 0; i < 5000; i++)
            {
                var child = parentGameObject.transform.GetChild(i);
                var componentsInChildren = child.GetComponentsInChildren<Pointer>();
                foreach (var item in componentsInChildren)
                {
                    var newPrefabPosition = listPositionCreatPrefabs[i] + (item.transform.localPosition * 2);
                    if (item.transform.localPosition.z < 0)
                    {
                        continue;
                    }
                    foreach (var itemList in listPositionCreatPrefabs)
                    {
                        if (itemList == newPrefabPosition)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (flag == true)
                    {
                        Random random = new Random();
                        Instantiate(platform[random.Next(0,_platform.Length - 1)], newPrefabPosition, Quaternion.identity,_parentGameObject.transform);
                        listPositionCreatPrefabs.Add(newPrefabPosition);
                    }
                    if (flag == false)
                    {
                        flag = true;   
                    }
                }
                
            }
        }
    }
}