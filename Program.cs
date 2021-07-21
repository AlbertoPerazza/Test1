using System;

namespace Test1
{
    class Program
    {
        static void Main(string[] args)
        {   
            /*
            Cose da fare :
            Inserimento path da console con controllo (deve essere un file c#); DA FARE
            Cercare i caretteri più utilizzati FATTO
            Cercare la parola più utilizzata facendo decidere all'utente se ignorare i commenti INIZIATO DA FINIRE
            Contare il numero di commenti "//" FATTO
            Stampare la parte del testo non commentata facendo attenzione ai commenti a metà riga DA FARE
            Contare il numero di classi non commentate DA FARE
            Salvare i dati nella classe già creata DA FARE
            */
            string text = System.IO.File.ReadAllText(@"INSERISCI INDIRIZZO DOC PER TESTING");
            string[] lines = System.IO.File.ReadAllLines(@"INSERISCI INDIRIZZO DOC PER TESTING");
            int mostFrequentChar = MostOccurringChar(text);
            Console.WriteLine((char)mostFrequentChar);
            int nComments = CommentsCalculator(lines);
            Console.WriteLine(nComments);
        }

        static int MostOccurringChar (string text) {
            int[] existentChars = new int[1];
            int[] charOccurences = new int[1];
            foreach (char c in text) {
                int charNum = ((int)c);
                for ( int i = 0; i < existentChars.Length; i++){
                    if (charNum == existentChars[i]){
                        charOccurences[i]++;
                    } else {
                        if (existentChars.Length == 1 && charOccurences[i] == 0) {
                            existentChars[0] = charNum;
                            charOccurences[0] = 1;
                        } else {
                            int[] newExistentChars = new int[existentChars.Length +1];
                            int[] newCharOccurences = new int[charOccurences.Length +1];
                            for (int y = 0; y <existentChars.Length; y++) {
                                newExistentChars[y] = existentChars[y];
                                newCharOccurences[y] = existentChars[y];
                            }
                            newExistentChars[^1] = charNum;
                            newCharOccurences[^1] = 1;
                        }   
                    }
                }
            }
            int maxOcc = FindMaxIndex(charOccurences);

            return existentChars[maxOcc];
        }

        static int FindMaxIndex(int[] array) {
            var max = int.MinValue;
            int indexMax = 0;
            for ( int i = 0; i < array.Length; i++) {
                if (array[i] > max) {
                    indexMax = i;
                }
            }
            return indexMax;
        }

        static int CommentsCalculator(string[] lines) {
            int commentCounter = 0;
            for (int i = 0; i < lines.Length; i++) {
                if (lines[i].Contains("//")) {
                    commentCounter++;
                }
            }
            return commentCounter;
        }
        
        static string MostCommonWord(string text) {
            string[] existentWords = new string[1];
            int[] wordOccurences = new int[1];
            char[] wordChars = new char[1];
            string currentWord = "";
            foreach (char c in text) {
                int charNum = ((int)c);
                // CREAZIONE PAROLA (COMPLETATO)
                if (charNum >= 97 && charNum <= 122){
                    if (wordChars.Length == 1 && wordChars[0] == 0){
                        wordChars[0] = c;
                    } else {
                        char[] newWordChars = new char[wordChars.Length + 1];
                        for (int i = 0; i < wordChars.Length; i++) {
                            newWordChars[i] = wordChars[i];
                        }
                        newWordChars[^1] = c;
                        wordChars = newWordChars;
                    }
                } else {
                    currentWord = string.Join("",wordChars);
                }
                // CONTINUARE CON CALCOLO OCCORRENZA DELLA PAROLA             
            }
            return "whatever word is the biggest";
        }
    }
}
