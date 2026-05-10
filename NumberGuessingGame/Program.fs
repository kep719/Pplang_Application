open System
System.Console.Clear()
System.Console.SetWindowSize(120, 40)
System.Console.SetBufferSize(120, 40)
// Credits to patorjk.com for generating the ascii art
Console.ForegroundColor <- ConsoleColor.Cyan
printfn "  _____                       _______ _            _   _                 _                "
printfn " / ____|                     |__   __| |          | \ | |               | |               "
printfn "| |  __ _   _  ___  ___ ___     | |  | |__   ___  |  \| |_   _ _ __ ___ | |__   ___ _ __  "
printfn "| | |_ | | | |/ _ \/ __/ __|    | |  | '_ \ / _ \ | . ` | | | | '_ ` _ \| '_ \ / _ \ '__| "
printfn "| |__| | |_| |  __/\__ \__ \    | |  | | | |  __/ | |\  | |_| | | | | | | |_) |  __/ |    "
printfn " \_____|\__,_|\___||___/___/    |_|  |_| |_|\___| |_| \_|\__,_|_| |_| |_|_.__/ \___|_|    "
printfn "" 
Console.ResetColor()
printfn "                                 Press Any Key To Continue"                                                                                                                                    

let key = System.Console.ReadKey(true)
let mutable game = true

// Game function. This is the logic for the game
let start_game(difficulty: System.ConsoleKeyInfo) =
    System.Console.Clear()
    let rnd = System.Random()
    let mutable guess = ""
    let mutable value = rnd.Next(0, 0)
    let mutable guesses = 0
    let mutable attempts = 1
    let mutable running = true

    // Adjusting of the difficulty
    if difficulty.Key = System.ConsoleKey.D1 then
        printfn "Easy Difficulty. 3 attempts to guess the number between 1 and 6."
        printfn ""
        guesses <- 3
        value <- rnd.Next(1, 6)
    elif difficulty.Key = System.ConsoleKey.D2 then
        printfn "Medium Difficulty. 4 attempts to guess the number between 1 and 11."
        printfn ""
        guesses <- 4
        value <- rnd.Next(1, 11)
    elif difficulty.Key = System.ConsoleKey.D3 then
        printfn "Hard Difficulty. 5 attempts to guess the number between 1 and 21."
        printfn ""
        guesses <- 5
        value <- rnd.Next(1, 21)
    
    // Guessing logic
    while running  && attempts <= guesses do
        printfn "Attempts left: %d" (guesses - attempts + 1)
        printf "Enter your guess: "
        guess <- System.Console.ReadLine()

        if guess = value.ToString() then
            printfn ""
            printfn "Congratulations! You guessed the number!"
            running <- false
            System.Threading.Thread.Sleep(2000)
        else
            printfn "Try again."
            printfn ""
            attempts <- attempts + 1

    if running then
        printfn "Nice Try! The correct number was %d" value
        System.Threading.Thread.Sleep(2000)

// Menu function
let menu() =
    Console.ForegroundColor <- ConsoleColor.Cyan

    printfn "╔════════════════════════════════════════════════════╗"
    printfn "║                    MAIN MENU                       ║"
    printfn "╚════════════════════════════════════════════════════╝"

    Console.ResetColor()

    printfn "[1] Start Game"
    printfn "[2] Quit"

// Difficulty function
let select_difficulty() =
    Console.ForegroundColor <- ConsoleColor.Cyan
    printfn "╔════════════════════════════════════════════════════╗"
    printfn "║                 SELECT DIFFICULTY                  ║"
    printfn "╚════════════════════════════════════════════════════╝"

    Console.ResetColor()

    printfn "[1] Easy"
    printfn "[2] Medium"
    printfn "[3] Hard"


let starting_game() =
    Console.ForegroundColor <- ConsoleColor.Green
    printfn "╔════════════════════════════════════════════════════╗"
    printfn "║                   STARTING GAME                    ║"
    printfn "╚════════════════════════════════════════════════════╝"
    Console.ResetColor()
    System.Threading.Thread.Sleep(2000)
    System.Console.Clear()

let quitting_game() =
    System.Console.Clear()
    Console.ForegroundColor <- ConsoleColor.Red
    printfn "╔════════════════════════════════════════════════════╗"
    printfn "║                   QUITTING GAME                    ║"
    printfn "╚════════════════════════════════════════════════════╝"
    Console.ResetColor()
    System.Threading.Thread.Sleep(2000)
    System.Console.Clear()

while game do
    if key.Key = key.Key then
        // This is the main menu
        System.Console.Clear()
        Console.ResetColor()
        menu()

        let mutable choice = System.Console.ReadKey(true)
        // If choice is not 1 or 2 it will loop until a valid choice is made
        while choice.Key <> System.ConsoleKey.D1 && choice.Key <> System.ConsoleKey.D2 do
            System.Console.Clear()
            menu()
            printfn "Invalid choice, please select 1 or 2."
            choice <- System.Console.ReadKey(true)

        // It will go here if the choice is within the correct inputs
        if choice.Key = System.ConsoleKey.D1 then
            System.Console.Clear()
            starting_game()         
            select_difficulty()

            // This is the difficulty selection menu
            let mutable difficulty = System.Console.ReadKey(true)
            while difficulty.Key <> System.ConsoleKey.D1 && difficulty.Key <> System.ConsoleKey.D2 && difficulty.Key <> System.ConsoleKey.D3 do
                System.Console.Clear()
                select_difficulty()
                printfn "Invalid choice, please select 1, 2, or 3."
                difficulty <- System.Console.ReadKey(true)
        
            start_game(difficulty)
        // Quitting the game
        elif choice.Key = System.ConsoleKey.D2 then
            System.Console.Clear()
            quitting_game()
            game <- false