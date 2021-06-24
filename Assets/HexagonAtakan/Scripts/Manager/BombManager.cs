using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System;
using HexagonAtakan.Hexagon;

namespace HexagonAtakan.Manager
{
    public class BombManager : MonoBehaviour
    {
        [SerializeField] private GridManager _gridManager;
        [SerializeField] private GridManagerSettings _gridManagerSettings;

        //test
        public int _tempCount;
        private List<HexagonController> _tempHexagonList;


        private void Start()
        {
            _tempHexagonList = new List<HexagonController>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.K))
            {
                SearchSceneHexagonGroup();
            }
        }

        public void SearchSceneHexagonGroup()
        {
            for (int x = 0; x < _gridManagerSettings.Width; x++)
            {
                for (int y = 0; y < _gridManagerSettings.Height; y++)
                {

                    //X is even
                    if (x % 2 == 0)
                    {
                        //Clear Memory
                        _tempCount = 0;
                        _tempHexagonList.Clear();
                        _tempHexagonList.Add(_gridManager._hexagonBaseArray[x, y]);
                        SearchEvenLeftGroup(x, y);


                        //Clear Memory
                        _tempCount = 0;
                        _tempHexagonList.Clear();
                        _tempHexagonList.Add(_gridManager._hexagonBaseArray[x, y]);
                        SearchEvenRightGroup(x, y);

                    }
                    //X is odd
                    else
                    {
                        //Clear Memory
                        _tempCount = 0;
                        _tempHexagonList.Clear();
                        _tempHexagonList.Add(_gridManager._hexagonBaseArray[x, y]);
                        SearchOddLeftGroup(x, y);


                        //Clear Memory
                        _tempCount = 0;
                        _tempHexagonList.Clear();
                        _tempHexagonList.Add(_gridManager._hexagonBaseArray[x, y]);
                        SearchOddRightGroup(x, y);
                    }



                    
                }
            }
        }
        public void SearchEvenLeftGroup(int x, int y)
        {
            //Fix out range
            if (x - 1 >= 0)
            {
                if (_gridManager._hexagonBaseArray[x, y].HexColor == _gridManager._hexagonBaseArray[x - 1, y].HexColor)
                {
                    _tempHexagonList.Add(_gridManager._hexagonBaseArray[x - 1, y]);
                    _tempCount++;
                    SearchOddRightGroup(x - 1, y);
                }
                else
                {
                    if (_tempCount >= 2)
                    {
                        foreach (var item in _tempHexagonList)
                        {
                            item.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }

        public void SearchOddRightGroup(int x, int y)
        {
            //Fix out range
            if (x + 1 < _gridManagerSettings.Width && y + 1 < _gridManagerSettings.Height)
            {
                if (_gridManager._hexagonBaseArray[x, y].HexColor == _gridManager._hexagonBaseArray[x + 1, y + 1].HexColor)
                {
                    _tempHexagonList.Add(_gridManager._hexagonBaseArray[x + 1, y + 1]);
                    _tempCount++;
                    SearchEvenLeftGroup(x + 1, y + 1);
                }
                else
                {
                    if (_tempCount >= 2)
                    {
                        foreach (var item in _tempHexagonList)
                        {
                            item.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }

        public void SearchEvenRightGroup(int x, int y)
        {
            //Fix out range
            if (x + 1 < _gridManagerSettings.Width)
            {
                if (_gridManager._hexagonBaseArray[x, y].HexColor == _gridManager._hexagonBaseArray[x + 1, y].HexColor)
                {
                    _tempHexagonList.Add(_gridManager._hexagonBaseArray[x + 1, y]);
                    _tempCount++;
                    SearchOddLeftGroup(x + 1, y);
                }
                else
                {
                    if (_tempCount >= 2)
                    {
                        foreach (var item in _tempHexagonList)
                        {
                            item.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
        public void SearchOddLeftGroup(int x, int y)
        {
            //Fix out range
            if (x - 1 >= 0 && y + 1 < _gridManagerSettings.Height)
            {
                if (_gridManager._hexagonBaseArray[x, y].HexColor == _gridManager._hexagonBaseArray[x - 1, y + 1].HexColor)
                {
                    _tempHexagonList.Add(_gridManager._hexagonBaseArray[x - 1, y + 1]);
                    _tempCount++;
                    SearchEvenRightGroup(x - 1, y + 1);
                }
                else
                {
                    if (_tempCount >= 2)
                    {
                        foreach (var item in _tempHexagonList)
                        {
                            item.gameObject.SetActive(false);
                        }
                    }
                }
            }
        }


    }
}