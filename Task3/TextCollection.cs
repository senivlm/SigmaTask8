using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SigmaTask8.Task3
{
    class TextCollection
    {
        //список елементів, бо ми не знаємо наперед
        //скільки буде речень
        List<string> sentences;

        public TextCollection(string path="N/A")
        {
            sentences = new List<string>();
            ReadFromFile(path);
        }

        public void ReadFromFile(string path)
        {
            if (File.Exists(path))
            {
                using (StreamReader reader = new StreamReader(path))
                {
                    //зчитаи всі речення (в кінці речення є крапка)
                    //і не обов'язково, щоб 1 речення було строго в 1 рядку
                    //P.S дивитись вхідний текстовий файл


                    //відповідає за попередній розмір списку речень
                    //необхідний, щоб визначати, чи почалось нове речення
                    int lastCount = 0;

                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        //якщо є у рядку є крапка
                        if (line.Contains('.'))
                        {
                            //розділити по крапках
                            string[] lineSplit = line.Split('.', StringSplitOptions.RemoveEmptyEntries);

                            //якщо список був пустий
                            if (sentences.Count == 0)
                            {
                                //просто додаємо
                                foreach (var text in lineSplit)
                                {
                                    sentences.Add(text);
                                    lastCount++;
                                }
                            }
                            //якщо список вже мав записи, отже може бути
                            //продовженя речення

                            //якщо це початок нового речення, то перша буква велика
                            //інакше продовження старого
                            else
                            {
                                foreach (string text in lineSplit)
                                {
                                    int index = 0;
                                    //якщо якась з частин пуста, то пропустити
                                    if (text.Length == 0)
                                        continue;
                                    //шукаємо першу букву, а не символ
                                    while (!Char.IsLetter(text[index]))
                                    {
                                        index++;
                                    }
                                    //перевіряємо, яка вона є
                                    //якщо велика, це нове речення
                                    if (Char.IsUpper(text[index]))
                                    {
                                        sentences.Add(text);
                                    }
                                    //інакше це продовження старого
                                    else
                                    {
                                        sentences[sentences.Count - 1] += text;
                                    }
                                }
                            }
                        }
                        //якщо список пустий це початкова частинка якогось речення
                        else if (sentences.Count == 0)
                        {
                            sentences.Add(line);
                            lastCount++;
                        }
                        //інакше рядок - продовження існуючого речення або нове речення
                        else
                        {
                            //значить було нове речення, а залишок - це початок нового речення
                            if (lastCount < sentences.Count)
                            {
                                sentences.Add(line);
                                lastCount = sentences.Count;
                            }
                            //інакше продовження існуючого речення
                            else
                            {
                                sentences[sentences.Count - 1] += line;
                            }
                        }
                    }
                }
            }
            else
                throw new FileNotFoundException("Can`t find file");
        }

        //посортувати по довжині у зростання
        public void SortByLenght()
        {
            sentences.Sort((x1,x2)=>x1.Length.CompareTo(x2.Length));
        }
        //глибина - це кількість вкладених дужок
        public string GetGreatestDepth()
        {
            string res = "";

            int max = 0;

            foreach(string sentence in sentences)
            {
                int curr_count = 0;
                for (int i =0; i < sentence.Length;i++)
                {
                    if (sentence[i] == '(')
                    {
                        curr_count++;

                        if (curr_count > max)
                        {
                            max = curr_count;
                            res = sentence;
                        }
                    }
                    else if (sentence[i] == ')')
                        curr_count--;
                }
                //десь пмилка з дужками у реченні
                if (curr_count != 0)
                    throw new InvalidDataException("Sentence has error");
            }
            return res;
        }

        //індексатор
        public string this[int index]
        {
            get
            {
                try
                {
                    return sentences[index];
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Wrong index");
                    return "";
                }
            }
            set
            {
                try
                {
                    sentences[index] = value;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Wrong index");
                }

            }
        }

        

        public override string ToString()
        {
            string res = "";
            foreach (string text in sentences)
            {
                res += string.Format("{0}\n",text);
            }
            return res;
        }
    }
}
