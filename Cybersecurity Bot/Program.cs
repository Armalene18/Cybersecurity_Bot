using System;
using System.Media;
using System.Text;
using System.Threading;

class CybersecurityChatbot
{
    static void Main(string[] args)
    {
        PlayVoiceGreeting();
        DisplayAsciiArt();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("\nPlease enter your name: ");
        Console.ResetColor();
        string userName = Console.ReadLine();

        while (string.IsNullOrWhiteSpace(userName))
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Name cannot be empty. Please enter your name: ");
            Console.ResetColor();
            userName = Console.ReadLine();
        }

        ShowWelcomeMessage(userName);

        while (true)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nAsk me a cybersecurity question (or type 'exit' to quit): ");
            Console.ResetColor();
            string question = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(question))
            {
                ShowTyping("I didn't quite understand that. Could you rephrase?\n");
                continue;
            }

            question = question.ToLower();

            if (question == "exit")
            {
                ShowTyping($"Goodbye, {userName}! Stay safe online!\n");
                break;
            }

            Console.WriteLine();
            ShowTyping(GetResponse(question, userName));
        }
    }

    static void PlayVoiceGreeting()
    {
        try
        {
            using (SoundPlayer player = new SoundPlayer("greeting.wav"))
            {
                player.Load();
                player.PlaySync();
            }
        }
        catch (Exception e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("[Audio Error] " + e.Message);
            Console.ResetColor();
        }
    }

    static void DisplayAsciiArt()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)");
        Console.WriteLine("(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)");
        Console.WriteLine("(\\o/)   ____      _                                        _ _           ____        _    (\\o/)");
        Console.WriteLine("(/|\\)  / ___|   _| |__   ___ _ __ ___  ___  ___ _   _ _ __(_) |_ _   _  | __ )  ___ | |_  (/|\\)");
        Console.WriteLine("(\\o/) | |  | | | | '_ \\ / _ \\ '__/ __|/ _ \\ / __| | | | '__| | __| | | | |  _ \\ / _ \\| __| (\\o/)");
        Console.WriteLine("(/|\\) | |__| |_| | |_) |  __/ |  \\__ \\  __/ (__| |_| | |  | | |_| |_| | | |_) | (_) | |_  (/|\\)");
        Console.WriteLine("(\\o/)  \\____\\__, |_.__/ \\___|_|  |___/\\___|\\___|\\__,_|_|  |_|\\__|\\__, | |____/ \\___/ \\__| (\\o/)");
        Console.WriteLine("(/|\\)       |___/                                                |___/                    (/|\\)");
        Console.WriteLine("(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)(\\o/)");
        Console.WriteLine("(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)(/|\\)");
        Console.ResetColor();
    }

    static void ShowWelcomeMessage(string userName)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"\nWelcome, {userName}! I'm your Cybersecurity Awareness Bot. Let's stay safe online together.\n");
        Console.ResetColor();
    }

    static string GetResponse(string input, string userName)
    {
        if (input.Contains("how are you"))
            return $"I'm doing great, {userName}! Always ready to help you stay secure online.";
        if (input.Contains("what's your purpose") || input.Contains("what is your purpose"))
            return "I'm here to help you learn and practice cybersecurity awareness.";
        if (input.Contains("what can i ask") || input.Contains("what can i ask you"))
            return "You can ask me about password safety, phishing, safe browsing, and more!";
        if (input.Contains("password"))
            return "Always use strong, unique passwords and consider a password manager.";
        if (input.Contains("phishing"))
            return "Watch out for suspicious emails and links. Never share personal info via email.";
        if (input.Contains("safe browsing"))
            return "Use secure websites (https), avoid public Wi-Fi for sensitive tasks, and keep your browser updated.";
        if (input.Contains("exit"))
            return $"Goodbye, {userName}! Thanks for chatting. Stay cyber safe!";

        return "I didn't quite understand that. Could you rephrase?";
    }

    static void ShowTyping(string message)
    {
        foreach (char c in message)
        {
            Console.Write(c);
            Thread.Sleep(30); // Typing effect
        }
        Console.WriteLine();
    }
}
