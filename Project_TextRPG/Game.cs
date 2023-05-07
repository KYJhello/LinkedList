using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TextRPG
{
    public class Game
    {
        private bool running = true;
        private Scene curScene;
        private MainMenuScene mainMenu;
        private MapScene mapScene;
        private InventoryScene inventoryScene;
        private BattleScene battleScene;

        public void Run()
        {
            // 1. 초기화
            Init();
            //GameStart();

            // 2. 게임 루프
            while (running)
            {
                // 3. 랜더링
                Render();

                // 5. 업데이트(갱신)
                Update();
            }
            // 6. 마무리(게임 끝내기)
            GameOver();
        }
        private void Init()
        {
            Console.CursorVisible = false;
            Data.Init();
            mainMenu = new MainMenuScene(this);
            mapScene = new MapScene(this);
            inventoryScene = new InventoryScene(this);
            battleScene = new BattleScene(this);
            curScene = mainMenu;
        }
        private void Render()
        {
            Console.Clear();
            curScene.Render();
        }
        private void Update()
        {
            curScene.Update();
        }
        public void MainMenu()
        {
            curScene = mainMenu;
        }
        public void Map()
        {
            curScene = mapScene;
        }
        public void Battle(Monster monster)
        {
            curScene = battleScene;
            battleScene.StartBattle(monster);
        }
        public void Inventory()
        {
            curScene = inventoryScene;
        }
        
        public void GameStart()
        {
            Data.LoadLevel();
            curScene = mapScene;
        }
        public void GameOver(string text = "")
        {
            Console.Clear();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine("  ***    *   *   * *****       ***  *   * ***** ****  ");
            sb.AppendLine(" *      * *  ** ** *          *   * *   * *     *   * ");
            sb.AppendLine(" * *** ***** * * * *****      *   * *   * ***** ****  ");
            sb.AppendLine(" *   * *   * *   * *          *   *  * *  *     *  *  ");
            sb.AppendLine("  ***  *   * *   * *****       ***    *   ***** *   * ");
            sb.AppendLine();

            sb.AppendLine();
            sb.Append(text);

            Console.WriteLine(sb.ToString());

            running = false;
        }
    }
}
