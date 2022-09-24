
namespace test {
    static class main{
        static void Main() {
        
        var rand = new Random();

        string? randomized = "RANDOM";
        int health = 0;
        int damage = 0;
        int playerHealth = 0;
        int playerDamage = 0;

        Console.Title = "Small Battle Simulator - Version 1.1.1";

        Console.WriteLine(
            "    ■■■ ■■■ ■■■ ■ ■\n" +
            "     ■   ■  ■ ■ ■■■\n" +
            "     ■  ■■■ ■ ■  ■\n" +
            "\n" +
            "■■■ ■■■ ■■■ ■■   ■  ■■■\n" +
            "■   ■ ■ ■■■ ■■■ ■■■  ■\n" +
            "■■■ ■■■ ■ ■ ■■■ ■ ■  ■\n" +
            "\n" +
            "       ■■ ■■■ ■■■\n" +
            "       ■   ■  ■■■\n" +
            "      ■■  ■■■ ■ ■\n" +
            "\n" +
            "By Strawberry Software\n"
        );

        Console.WriteLine("CUSTOM or RANDOM match?");
        try{
            randomized = Console.ReadLine();
            Console.WriteLine("DEBUG: " + randomized);
        }
        catch {
            Console.WriteLine("Please only write either CUSTOM or RANDOM.\nUsing RANDOM for now");
            randomized = "RANDOM";
        }
        if (randomized.ToUpper().Equals("CUSTOM")){ // Ignore this error, it works
            Console.WriteLine("Enter Enemy Health: ");
            health = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Enemy Base Damage: ");
            damage = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Player Health: ");
            playerHealth = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Player Base Damage: ");
            playerDamage = Convert.ToInt32(Console.ReadLine());
        }
        else {
            health = rand.Next(999); // Keep separate from playerHealth
            damage = rand.Next(50); // Keep separate from playerDamage
            playerHealth = rand.Next(999);
            playerDamage = rand.Next(50);
        }
        
        int action, enemyDamageTemp = 0;
        bool ranAway = false;

        while (true) {
            Console.WriteLine(
                "Enemy Health: " + health +
                "\nYour Health: " + playerHealth + "\n\n" +
                "Actions:\n(1) Attack\n(2) Run\n"
            );
            // Player Turn
            action = Convert.ToInt32(Console.ReadLine());
            switch (action){
                case 1:
                    health -= rand.Next(playerDamage-2, playerDamage+2); // Ass pseudo-random damage to enemy
                    Console.WriteLine("You hit the enemy!");
                    break;
                case 2:
                    if (rand.Next() > 0.5){
                        ranAway = true;
                    }
                    else{
                        Console.WriteLine("Could not get away.");
                    }
                    break;
                default:
                    Console.WriteLine("You stumble and miss your attack window.\n(You input something other than 1 or 2. Plese only input 1 or 2.)");
                    break;
            }
            if (ranAway){
                Console.WriteLine("You successfully ran away.");
                break;
            }
            if (health < 0){ // Don't move down, else the enemy attacks you part runs
                break;
            }
            // Enemy Turn
            if (rand.Next() > 0.5){
                enemyDamageTemp = rand.Next(damage-2, damage+2);
                playerHealth -= enemyDamageTemp;
                Console.WriteLine("Enemy attacked you!\n(-" + enemyDamageTemp + " Health)");
            }
            else{
                Console.WriteLine("Enemy did... nothing? You got spared.");
            }
            if (playerHealth < 0){
                break;
            }
        }
        if (health <= 0){
            Console.WriteLine("Congrats! You won!");
        }
        else if (playerHealth <= 0){
            Console.WriteLine("You lost.");
        }
        Console.WriteLine("Press any button to continue.");
        Console.ReadKey();
        }
    }
}