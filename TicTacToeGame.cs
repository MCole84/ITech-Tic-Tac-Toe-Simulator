/// Michael Cole
/// I-tech .net class
/// 4.22.2016

using System;
using System.Collections.Generic;
using System.Security;

namespace TicTacToeLibrary
{
    public class TicTacToeGame
    {

        private int[] _boxLocation;
        private int _xCount;
        private int _oCount;
        private bool isAWinner;

        private List<string> winningCombinations = new List<string>();

        public void Run()
        {
            _xCount = 0;
            _oCount = 0;
            Random rand = new Random();
            for (int i = 0; i < _boxLocation.Length; i++)
            {
                _boxLocation[i] = rand.Next(2);
            }
        }

        public char getBoxValue(int location)
        {
            if (_boxLocation[location] == 0)
            {
                if (_oCount < 5)
                {
                    _oCount++;
                    return 'O';
                }
                else
                {
                    _boxLocation[location] = 1;
                    return 'X';
                    
                }
            }
            else
            {
                if (_xCount < 5)
                {
                    _xCount++;
                    return 'X';
                }
                else
                {
                    _boxLocation[location] = 0;
                    return 'O';
                }
            }
        }

        /// <summary>
        /// Returns the winning Character 'X' or 'O'. Returns null character if it is a draw
        /// </summary>
        /// <returns></returns>
        public char GetWinningPlayer()
        {
            isAWinner = false;
            char winner = 'O';
            int[] boxes = new int[3];
            for (int i = 0; i < winningCombinations.Count; i++)
            {
                string[] boxCombo = winningCombinations[i].Split(',');
                for (int j = 0; j < boxes.Length; j++)
                {
                    boxes[j] = int.Parse(boxCombo[j]);
                }
                if (_boxLocation[boxes[0]] == _boxLocation[boxes[1]] && _boxLocation[boxes[0]] == _boxLocation[boxes[2]])
                {
                    winner = _boxLocation[boxes[0]] == 1 ? 'X' : 'O';
                    isAWinner = true;
                    break;
                }
            }
            //TODO determine winner and return the character of the winner
            if (isAWinner == false)
                winner = '\0';
            return winner;
        }

        public TicTacToeGame()
        {
            _boxLocation = new int[9];
            winningCombinations.Add("0,1,2");
            winningCombinations.Add("0,4,8");
            winningCombinations.Add("0,3,6");
            winningCombinations.Add("1,4,7");
            winningCombinations.Add("2,4,6");
            winningCombinations.Add("2,5,8");
            winningCombinations.Add("3,4,5");
            winningCombinations.Add("6,7,8");
            Run();
            GetWinningPlayer();
        }
    }
}