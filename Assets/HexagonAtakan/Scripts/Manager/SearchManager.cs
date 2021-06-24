using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using System;
using HexagonAtakan.Hexagon;

namespace HexagonAtakan.Manager
{
    public class SearchManager : MonoBehaviour
    {
        [SerializeField] private GridManager _gridManager;
        [SerializeField] private GridManagerSettings _gridManagerSettings;

        //test
        public int _groupMemberCount;
        private List<HexagonController> _tempHexagonList;

        public int _rightEnterCount = 0;
        public int _leftEnterCount = 0;

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
                        _groupMemberCount = 0;
                        _rightEnterCount = 1;
                        _leftEnterCount = 0;
                        _tempHexagonList.Clear();
                        _tempHexagonList.Add(_gridManager._hexagonBaseArray[x, y]);
                        SearchEvenLeftGroup(x, y);


                        //Clear Memory
                        _groupMemberCount = 0;
                        _rightEnterCount = 0;
                        _leftEnterCount = 1;
                        _tempHexagonList.Clear();
                        _tempHexagonList.Add(_gridManager._hexagonBaseArray[x, y]);
                        SearchEvenRightGroup(x, y);

                    }
                    //X is odd
                    else
                    {
                        //Clear Memory
                        _groupMemberCount = 0;
                        _rightEnterCount = 1;
                        _leftEnterCount = 0;
                        _tempHexagonList.Clear();
                        _tempHexagonList.Add(_gridManager._hexagonBaseArray[x, y]);
                        SearchOddLeftGroup(x, y);


                        //Clear Memory
                        _groupMemberCount = 0;
                        _rightEnterCount = 0;
                        _leftEnterCount = 1;
                        _tempHexagonList.Clear();
                        _tempHexagonList.Add(_gridManager._hexagonBaseArray[x, y]);
                        SearchOddRightGroup(x, y);
                    }



                    
                }
            }
        }
        public void SearchEvenLeftGroup(int x, int y)
        {
            //Fixed out range
            if (x - 1 >= 0)
            {
                if (_gridManager._hexagonBaseArray[x, y].HexColor == _gridManager._hexagonBaseArray[x - 1, y].HexColor)
                {
                    _tempHexagonList.Add(_gridManager._hexagonBaseArray[x - 1, y]);
                    _groupMemberCount++;
                    _rightEnterCount++;
                    SearchOddRightGroup(x - 1, y);
                }
                else
                {
                    if (_groupMemberCount >= 2)
                    {
                        foreach (var item in _tempHexagonList)
                        {
                            //item.gameObject.SetActive(false);
                        }

                        //DropTop(x, y, _rightEnterCount);
                        //DropTop(x - 1, y, _leftEnterCount);
                    }
                }
            }
        }

        public void SearchOddRightGroup(int x, int y)
        {
            //Fixed out range
            if (x + 1 < _gridManagerSettings.Width && y + 1 < _gridManagerSettings.Height)
            {
                if (_gridManager._hexagonBaseArray[x, y].HexColor == _gridManager._hexagonBaseArray[x + 1, y + 1].HexColor)
                {
                    _tempHexagonList.Add(_gridManager._hexagonBaseArray[x + 1, y + 1]);
                    _groupMemberCount++;
                    _leftEnterCount++;
                    SearchEvenLeftGroup(x + 1, y + 1);
                }
                else
                {
                    if (_groupMemberCount >= 2)
                    {
                        foreach (var item in _tempHexagonList)
                        {
                            //item.gameObject.SetActive(false);
                        }
                        Debug.Log("burd");

                        DropTop(x, y,_leftEnterCount);
                        DropTop(x+1, y,_rightEnterCount);

                    }
                }
            }
        }

        public void SearchEvenRightGroup(int x, int y)
        {
            //Fixed out range
            if (x + 1 < _gridManagerSettings.Width)
            {
                if (_gridManager._hexagonBaseArray[x, y].HexColor == _gridManager._hexagonBaseArray[x + 1, y].HexColor)
                {
                    _tempHexagonList.Add(_gridManager._hexagonBaseArray[x + 1, y]);
                    _groupMemberCount++;
                    _leftEnterCount++;
                    SearchOddLeftGroup(x + 1, y);
                }
                else
                {
                    if (_groupMemberCount >= 2)
                    {
                        foreach (var item in _tempHexagonList)
                        {
                            //item.gameObject.SetActive(false);
                        }
                    }
                   // DropTop(x, y, _leftEnterCount);
                   // DropTop(x + 1, y, _rightEnterCount);
                }
            }
        }
        public void SearchOddLeftGroup(int x, int y)
        {
            //Fixed out range
            if (x - 1 >= 0 && y + 1 < _gridManagerSettings.Height)
            {
                if (_gridManager._hexagonBaseArray[x, y].HexColor == _gridManager._hexagonBaseArray[x - 1, y + 1].HexColor)
                {
                    _tempHexagonList.Add(_gridManager._hexagonBaseArray[x - 1, y + 1]);
                    _groupMemberCount++;
                    _rightEnterCount++;
                    SearchEvenRightGroup(x - 1, y + 1);
                }
                else
                {
                    if (_groupMemberCount >= 2)
                    {
                        foreach (var item in _tempHexagonList)
                        {
                            //item.gameObject.SetActive(false);
                        }
                    }
                    //DropTop(x, y, _rightEnterCount);
                   // DropTop(x - 1, y, _leftEnterCount);
                }
            }
        }

        public void DropTop(int x,int y,int enterCount)
        {
            for (int i = 0; i < y+1; i++)
            {
                int dropArrayLocation = y - enterCount - i;

                if (dropArrayLocation >= 0) {

                    //Write companentsdfsdfsdf
                    Vector3 dropPosition = _gridManager._hexagonBaseArray[x, y - i].transform.position;
                    _gridManager._hexagonBaseArray[x, dropArrayLocation].StartLerpPositionIEnumerator(dropPosition);
                }
            }
        }


    }
}