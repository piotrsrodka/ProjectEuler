namespace Euler
{
    internal class Euler59 : IEulerProblem
    {
        public void Start()
        {
            using (StreamReader streamReader = new StreamReader(@"Data\\0059_cipher.txt"))
            {
                string data = streamReader.ReadToEnd();
                char[] cypherASCII = data.Split(',').Select(datum => (char)int.Parse(datum)).ToArray();
                char[] decryptedASCII = new char[cypherASCII.Length];
                char[] passwordChars = new char[3];
                string password = "pel";

                for (char a = 'a'; a <= 'z'; a++)
                {
                    passwordChars[0] = a;

                    for (char b = 'a'; b <= 'z'; b++)
                    {
                        passwordChars[1] = b;

                        for (char c = 'a'; c <= 'z'; c++)
                        {
                            passwordChars[2] = c;

                            password = new string(passwordChars);

                            bool isOk = true;

                            for (int i = 0; i < cypherASCII.Length; i++)
                            {
                                int passwordIndex = i % 3;
                                char passwordChar = password[passwordIndex];
                                decryptedASCII[i] = (char)(cypherASCII[i] ^ passwordChar);

                                if (decryptedASCII[i] < 32 || decryptedASCII[i] > 126)
                                {
                                    isOk = false;
                                    break;
                                }
                            }

                            if (isOk) // && password == "exp")
                            {
                                Console.WriteLine($"Good password: {password}");
                                Console.WriteLine("Decrypted message:");
                                string decryptedMessage = new string(decryptedASCII);
                                Console.WriteLine(decryptedMessage);
                                int sum = decryptedASCII.Sum(x => x);
                                Console.WriteLine($"Sum of the original text ASCII numbers: {sum}");
                            }
                        }
                    }
                }
            }
        }
    }
}
