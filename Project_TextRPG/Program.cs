namespace Project_TextRPG
{
    internal class Program
    {
        // 1. 프로젝트 분석(객체지향 프로젝트 의미 위주로) 
        // 2. 몬스터 2종 추가 -> 완
        // 3. 아이템 2종 추가 -> 완
        // 4. 플레이어 직업시스템 추가 -> 완
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Run();

        }
    }
}