using HexagonAtakan.Hexagon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HexagonAtakan.Manager
{
    public class SceneManager : MonoBehaviour
    {

        [SerializeField] private SearchManager _searchManager;
        [SerializeField] private GridManager _gridManager;


        private void LateUpdate()
        {
            StartScene();
        }

        //Mini hack (adjustment) :(
        public void StartScene()
        {
            for (int i = 0; i < 20; i++)
            {
                _searchManager.SearchSceneHexagonGroup();
            }
            Destroy(gameObject,2);
        }
    }
}