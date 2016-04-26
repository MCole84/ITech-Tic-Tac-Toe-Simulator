using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TicTacToeLibrary;

namespace TicTacToeSimulator
{
    public partial class Form1 : Form
    {
        private TicTacToeGame game = new TicTacToeGame();

        public Form1()
        {
            InitializeComponent();
            PopulateGameBoard();
            GetWinningPlayer();
        }

        /// <summary>
        /// Displays the values for the Tic-Tac-Toe game in their respective boxes on the board
        /// </summary>
        private void PopulateGameBoard()
        {
            for (int i = 0; i < 9; i++)
            {
                string currentBox = "lblBox" + (i + 1);
                foreach (Control ctr in Controls)
                {
                    Label lbl = ctr as Label;
                    if (lbl != null)
                    {
                        if (lbl.Name == currentBox)
                        {
                            lbl.Text = game.getBoxValue(i).ToString();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Generates a new Tic-Tac-Toe game and determines the winner
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGenerate_Click(object sender, EventArgs e)
        {
            game.Run();
            PopulateGameBoard();
            GetWinningPlayer();
        }

        /// <summary>
        /// Determines who won the game or if the game is a draw
        /// </summary>
        private void GetWinningPlayer()
        {
            char winner = game.GetWinningPlayer();
            if (winner == '\0')
            {
                lblWinner.Text = "The game is a draw";
            }
            else
            {
                lblWinner.Text = $"Player {winner} is the winner";
            }
        }

        /// <summary>
        /// Exits the program
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}