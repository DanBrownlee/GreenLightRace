﻿
namespace Settings
{
    class Levels
    {
        public const string MENU = "menu";
		public const string LEVEL_1 = "level_1u5";
    }
    class Net
    {
        public const int MAX_PLAYERS = 5;
        public const int SERVER_PORT = 4000;

        public const string MASTER_SERVER_IP = "188.166.41.249";
        public const int MASTER_SERVER_PORT = 23466;

        public const string FACILITATOR_IP = "188.166.41.249";//188.166.41.249
        public const int FACILITATOR_PORT = 50005;

        public const string GAME_TYPE = "kitvandebunt_testgame";
    }
    class Player
    {
        public static string name = "Player "+UnityEngine.Random.Range(0,10000);
        public static string roomname = "Noir Game";
        public static CarID carID = CarID.thomasCar;
    }
}
