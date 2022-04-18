using Hangman.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman.Services
{
    class CurrentPlayer
    {
        Player currrentPlayer;
        public string Username => currrentPlayer.Username;

        public CurrentPlayer(Player player)
        {
            currrentPlayer = player;
        }
    }
}
